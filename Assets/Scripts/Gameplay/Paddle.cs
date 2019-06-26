using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Movement of Paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields

    // Change this to equal scale change to sprite
    public int ScaleFactor = 3;

    // Intializes at start
    Rigidbody2D rb2d;
    float paddleHalfWidth;
    float colliderHalfHeight;

    // Used to mimic block as a convex
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    #endregion

    #region Methods

    /// <summary>
    /// Initializers
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddleHalfWidth = GetComponent<BoxCollider2D>().bounds.size.x * 0.5f;
        colliderHalfHeight = GetComponent<BoxCollider2D>().bounds.size.y * 0.5f;
    }

    /// <summary>
    /// Movement of Paddle
    /// </summary>
    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond, 0);

        if (Input.GetAxis("Horizontal") != 0)
        {
            // move left
            if (Input.GetAxis("Horizontal") < 0)
            {
                rb2d.position = new Vector2(CalculateClampedX(rb2d.position.x), rb2d.position.y);
                rb2d.MovePosition(rb2d.position - velocity * Time.deltaTime);
            }
            // move right
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb2d.position = new Vector2(CalculateClampedX(rb2d.position.x), rb2d.position.y);
                rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
            }
        }
    }

    /// <summary>
    /// Clamps the paddle inside window
    /// </summary>
    /// <param name="rigidbodyXValue">rigidbody2d x position</param>
    /// <returns>clamped value</returns>
    float CalculateClampedX(float rigidbodyXValue)
    {
        // clamp left
        if (rigidbodyXValue < ScreenUtils.ScreenLeft + paddleHalfWidth)
        {
            rigidbodyXValue = ScreenUtils.ScreenLeft + paddleHalfWidth;
        }
        // clamp right
        if (rigidbodyXValue > ScreenUtils.ScreenRight - paddleHalfWidth)
        {
            rigidbodyXValue = ScreenUtils.ScreenRight - paddleHalfWidth;
        }

        return rigidbodyXValue;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="collision">collision info</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && IsPaddleTop(collision))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                collision.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = collision.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Determines whether collision is top of paddle
    /// </summary>
    /// <param name="collision">collision2d to test against</param>
    /// <returns>whether top or not</returns>
    bool IsPaddleTop(Collision2D collision)
    {
        // grabs contact points to compare against a tolerance    
        float topOfPaddle = transform.position.y + colliderHalfHeight;
        float contactPoint = collision.GetContact(collision.contactCount - 1).point.y;
        float tolerance = 0.05f;      
        
        // compares points
        if (contactPoint >= topOfPaddle - tolerance
            && contactPoint <= topOfPaddle + tolerance)
        {
            return true;
        }

        return false;
    }

    #endregion
}
