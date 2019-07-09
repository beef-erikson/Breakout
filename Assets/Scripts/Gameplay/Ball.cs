using UnityEngine;

/// <summary>
/// Ball logic
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    Rigidbody2D rb2d;
    Timer timerBallLife;
    Timer timerSpawnDelay;
    Timer timerBallSpawn;

    bool isBallMoving = false;

    #endregion

    #region Private Methods

    /// <summary>
    /// Destroys and spawns a new ball whenever it leaves the screen.
    /// Only spawns if the ball is actually below the screen
    /// </summary>
    void OnBecameInvisible()
    {
        float topOfBall = transform.position.y - gameObject.GetComponent<BoxCollider2D>().bounds.size.y * 0.5f;

        if (topOfBall <= ScreenUtils.ScreenBottom)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Moves ball
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timerBallLife = gameObject.AddComponent<Timer>();
        timerSpawnDelay = gameObject.AddComponent<Timer>();
        timerBallSpawn = gameObject.AddComponent<Timer>();

        // Starts spawn timer
        timerSpawnDelay.Duration = 2f;
        timerSpawnDelay.Run();

        // Starts ball life timer
        timerBallLife.Duration = ConfigurationUtils.BallLifetimePerSecond;
        timerBallLife.Run();

        // Starts ball spawn timer
        timerBallSpawn.Duration = Random.Range(
            ConfigurationUtils.BallMinimumSpawnTime, ConfigurationUtils.BallMaximumSpawnTime);
        timerBallSpawn.Run();
    }

    /// <summary>
    /// Timer logic handling life, spawn, and movement of ball
    /// </summary>
    void Update()
    {
        // When life timer expires, instantiates and destroys ball.
        if (!timerBallLife.Running)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

        // When spawn delay timer expires, gets ball moving
        if (!timerSpawnDelay.Running && !isBallMoving)
        {
            float angle = 270 * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
            isBallMoving = true;
        }

        // Spawns new ball after time expires
        if (!timerSpawnDelay.Running)
        {
            Instantiate(gameObject);

            timerBallSpawn.Duration = Random.Range(
                ConfigurationUtils.BallMinimumSpawnTime, ConfigurationUtils.BallMaximumSpawnTime);
            timerBallSpawn.Run();
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Changes the direction of the Ball on Paddle hit
    /// </summary>
    /// <param name="direction">direction to head</param>
    public void SetDirection(Vector2 direction)
    {
        rb2d.velocity = rb2d.velocity.magnitude * direction;
    }

    #endregion
}
