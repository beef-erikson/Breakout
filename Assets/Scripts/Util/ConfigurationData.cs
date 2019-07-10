using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "Config.csv";

    // default configuration data if csv cannot be found
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifetimePerSecond = 4;
    static float ballMinimumSpawnTime = 10;
    static float ballMaximumSpawnTime = 20;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get => paddleMoveUnitsPerSecond;
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get => ballImpulseForce;
    }

    /// <summary>
    /// Lifetime of the ball before self destruction
    /// </summary>
    public float BallLifetimePerSecond
    {
        get => ballLifetimePerSecond;
    }

    /// <summary>
    /// Mimimum time in seconds before spawning a new ball
    /// </summary>
    public float BallMinimumSpawnTime
    {
        get => ballMinimumSpawnTime;
    }

    /// <summary>
    /// Maximum spawn time in seconds before spawning a new ball
    /// </summary>
    public float BallMaximumSpawnTime
    {
        get => ballMaximumSpawnTime;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Reads configuration data from a file. If the file read fails, contains default values for
    /// the configuration data.
    /// </summary>
    public ConfigurationData()
    {
        StreamReader configFile = null;

        try
        {
            // reads in file and sets fields from .csv, ignoring descriptive first line
            configFile = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            configFile.ReadLine();
            SetConfigurationFields(configFile.ReadLine());
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (configFile != null)
            {
                configFile.Close();
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the configuration fields generated from the .csv file
    /// </summary>
    /// <param name="csvValues">csv values</param>
    void SetConfigurationFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifetimePerSecond = float.Parse(values[2]);
        ballMinimumSpawnTime = float.Parse(values[3]);
        ballMaximumSpawnTime = float.Parse(values[4]);
    }

    #endregion
}
