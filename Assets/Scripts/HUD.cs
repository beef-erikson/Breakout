using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles HUD elements - Score and Balls Left text
/// </summary>
public class HUD : MonoBehaviour
{
    #region Fields

    static Text scoreText;
    static int score;

    #endregion

    #region Private Methods

    /// <summary>
    /// Initializers
    /// </summary>
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds points to score and updates UI
    /// </summary>
    /// <param name="points">number of points to add to score</param>
    static public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    #endregion
}
