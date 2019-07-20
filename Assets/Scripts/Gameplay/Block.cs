using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Block destruction
/// </summary>
public class Block : MonoBehaviour
{
    #region Fields

    protected int pointsWorth;

    #endregion

    #region Private Methods

    /// <summary>
    /// Destroys block
    /// </summary>
    /// <param name="collision">collision</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        HUD.AddPoints(pointsWorth);
        Destroy(gameObject);    
    }

    #endregion
}
