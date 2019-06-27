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

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
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
    }

    #endregion
}
