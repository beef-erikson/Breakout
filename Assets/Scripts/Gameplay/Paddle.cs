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

    #endregion

    #region Methods

    /// <summary>
    /// Grabs rigidbody
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb2d.MovePosition(new Vector2(transform.position.x + ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime,
                transform.position.y));
        }
    }

    #endregion
}
