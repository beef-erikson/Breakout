using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    public static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get => configurationData.PaddleMoveUnitsPerSecond;
    }

    /// <summary>
    /// Gets the Impulse Force to be applied to the ball
    /// </summary>
    public static float BallImpulseForce
    {
        get => configurationData.BallImpulseForce;
    }

    /// <summary>
    /// Gets the lifetime of the ball before it destroys itself
    /// </summary>
    public static float BallLifetimePerSecond
    {
        get => configurationData.BallLifetimePerSecond;
    }

    /// <summary>
    /// Gets the minimum spawn time for spawning new balls
    /// </summary>
    public static float BallMinimumSpawnTime
    {
        get => configurationData.BallMinimumSpawnTime;
    }

    /// <summary>
    /// Gets the maximum spawn time for spawning new balls
    /// </summary>
    public static float BallMaximumSpawnTime
    {
        get => configurationData.BallMaximumSpawnTime;
    }

    /// <summary>
    /// Gets the point value for standard blocks
    /// </summary>
    public static float StandardBlockPoints
    {
        get => configurationData.StandardBlockPoints;
    }

    #endregion

    #region Methods 

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

    #endregion
}
