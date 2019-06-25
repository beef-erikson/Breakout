using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Movement of Paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields

    public int ScaleFactor = 3;

    // intializes at start
    Rigidbody2D rb2d;
    float paddleHalfWidth;

    #endregion

    #region Methods

    /// <summary>
    /// Initializers
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddleHalfWidth = GetComponent<BoxCollider2D>().size.x * 0.5f;
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

//    Write a new CalculateClampedX method that returns an x value that takes a possible
//new x position for the rigidbody, shifts it if necessary to clamp the paddle to stay in the
//screen horizontally, and returns a clamped new x position(which could just be the
//original new x position that was passed in if no clamping was required). Call this method
//if you move the game object in the FixedUpdate method BEFORE you call the
//MovePosition method.The “big idea” is that you have to calculate a valid new x
//position, including the clamping, before you call the method to move the rigidbody.
    float CalculateClampedX(float rigidbodyXValue)
    {
        float boundsBuffer = 0.16f;

        // clamp left
        if (rigidbodyXValue < ScreenUtils.ScreenLeft + paddleHalfWidth * ScaleFactor)
        {
            rigidbodyXValue = ScreenUtils.ScreenLeft + paddleHalfWidth * ScaleFactor + boundsBuffer;
        }
        // clamp right
        if (rigidbodyXValue > ScreenUtils.ScreenRight - paddleHalfWidth * ScaleFactor)
        {
            rigidbodyXValue = ScreenUtils.ScreenRight - paddleHalfWidth * ScaleFactor - boundsBuffer;
        }
        return rigidbodyXValue;
    }
    #endregion
}
