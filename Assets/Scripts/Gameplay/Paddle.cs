using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Movement of Paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields

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
                rb2d.MovePosition(rb2d.position - velocity * Time.deltaTime);
            }
            // move right
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
            }
        }
    }

    #endregion
}
