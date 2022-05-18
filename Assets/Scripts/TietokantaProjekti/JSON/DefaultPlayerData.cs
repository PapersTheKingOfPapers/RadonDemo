using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
[System.Serializable]
public class DefaultPlayerData
{
    public float[] _position;
    public int _health;
    public int _level;
    public int _score;
    public string _scene;

    //Constructor, Establishes variables
    public DefaultPlayerData()
    {
        _health = 100;
        _level = 0;
        _score = 0;
        _scene = "ch_1_tunnels_1";
        _position = new float[3];
        _position[0] = 2;
        _position[1] = 1.5f;
        _position[2] = 0;
    }
}
