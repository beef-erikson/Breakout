using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns a ball
/// </summary>
public class BallSpawner : MonoBehaviour
{
    #region Fields

    public GameObject prefabBall;

    // spawn overlap checking support
    bool retrySpawn = true;
    Vector2 ballBottomLeftPoint;
    Vector2 ballTopRightPoint;

    #endregion

    #region Private Methods

    /// <summary>
    /// Spawns a temporary ball to grab spawning positions
    /// </summary>
    void Start()
    {
        // Grabs corners of ball
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        Vector2 size = tempBall.GetComponent<BoxCollider2D>().size;
        Vector2 position = tempBall.transform.position;

        ballTopRightPoint = new Vector2(position.x + size.x * 0.5f, position.y + size.y * 0.5f);
        ballBottomLeftPoint = new Vector2(position.x - size.x * 0.5f, position.y - size.y * 0.5f);
        Destroy(tempBall);
    }

    /// <summary>
    /// Spawns ball if retrySpawn is true
    /// </summary>
    void Update()
    {
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Spawns a ball if spawn area is clear
    /// </summary>
    public void SpawnBall()
    {
        if (Physics2D.OverlapArea(ballBottomLeftPoint, ballTopRightPoint) == null)
        {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }

    #endregion
}
