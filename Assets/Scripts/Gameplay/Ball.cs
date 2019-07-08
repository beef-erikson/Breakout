using UnityEngine;

/// <summary>
/// Ball logic
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    Rigidbody2D rb2d;
    Timer timer;

    #endregion

    #region Methods

    /// <summary>
    /// Moves ball
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timer = gameObject.AddComponent<Timer>();

        // Starts ball moving directly down
        float angle = 270 * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);

        // Destroys ball after timer expires
        timer.Duration = ConfigurationUtils.BallLifetimePerSecond;
        timer.Run();
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
    /// When timer expires, instantiates and destroys ball.
    /// </summary>
    void Update()
    {
        if (!timer.Running)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }
    #endregion
}
