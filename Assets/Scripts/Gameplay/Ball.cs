using UnityEngine;

/// <summary>
/// Ball logic
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    Rigidbody2D rb2d;

    #endregion

    #region Methods

    /// <summary>
    /// Moves ball
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Starts ball moving directly down
        float angle = 270 * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
    }
  
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
