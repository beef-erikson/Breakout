using System.Collections;
using System.Collections.Generic;
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

        // Starts ball moving at a 20 degree angle
        float angle = 20 * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
