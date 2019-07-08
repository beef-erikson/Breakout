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

    public static float BallLifetimePerSecond
    {
        get => configurationData.BallLifetimePerSecond;
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
