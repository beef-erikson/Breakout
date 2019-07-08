using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns a ball
/// </summary>
public class BallSpawner : MonoBehaviour
{
    #region Fields

    public Ball ball;

    #endregion

    #region Methods

    /// <summary>
    /// Spawns a ball
    /// </summary>
    public void SpawnBall()
    {
        Instantiate(ball);
    }

    #endregion
}
