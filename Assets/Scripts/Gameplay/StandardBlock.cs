using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Standard Block Class - Sets sprite and point value (based off csv)
/// </summary>
public class StandardBlock : Block
{
    #region Fields

    [SerializeField]
    Sprite standardBlock1;
    [SerializeField]
    Sprite standardBlock2;
    [SerializeField]
    Sprite standardBlock3;
    [SerializeField]
    Sprite standardBlock4;
    [SerializeField]
    Sprite standardBlock5;

    #endregion

    #region Private Methods

    /// <summary>
    /// Initializers
    /// </summary>
    void Start()
    {
        // Sets point value of block
        pointsWorth = ConfigurationUtils.StandardBlockPoints;

        // Sets Sprite to a random sprite from the serialized fields
        int randomSprite = Random.Range(0, 5);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        switch (randomSprite)
        {
            case 0:
                spriteRenderer.sprite = standardBlock1;
                break;
            case 1:
                spriteRenderer.sprite = standardBlock2;
                break;
            case 2:
                spriteRenderer.sprite = standardBlock3;
                break;
            case 3:
                spriteRenderer.sprite = standardBlock4;
                break;
            case 4:
                spriteRenderer.sprite = standardBlock5;
                break;
            default:
                print("Danger! Sprite not found.");
                break;
        }
    }

    #endregion
}
