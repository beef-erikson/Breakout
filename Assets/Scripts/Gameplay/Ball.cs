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
    bool isBallMoving = false;

    #endregion

    #region Methods

    /// <summary>
    /// Moves ball
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timerBallLife = gameObject.AddComponent<Timer>();
        timerSpawnDelay = gameObject.AddComponent<Timer>();

        // Starts spawn timer
        timerSpawnDelay.Duration = 2f;
        timerSpawnDelay.Run();

        // Destroys ball after timer expires
        timerBallLife.Duration = ConfigurationUtils.BallLifetimePerSecond;
        timerBallLife.Run();
    }
  
    /// <summary>
    /// Changes the direction of the Ball on Paddle hit
    /// </summary>
    /// <param name="direction">direction to head</param>
    public void SetDirection(Vector2 direction)
    {
        rb2d.velocity = rb2d.velocity.magnitude * direction;
    }

    /// <summary>
    /// Timer logic for both spawner and ball life
    /// </summary>
    void Update()
    {
        // When timer expires, instantiates and destroys ball.
        if (!timerBallLife.Running)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

        // TODO: NOT WORKING
        // When spawn timer expires, gets ball moving
        if (!timerSpawnDelay.Running && !isBallMoving)
        {
            float angle = 270 * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
            isBallMoving = true;
        }
    }
    #endregion
}
