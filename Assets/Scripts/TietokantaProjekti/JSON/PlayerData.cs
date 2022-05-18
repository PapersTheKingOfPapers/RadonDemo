using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
[System.Serializable]
public class PlayerData
{
    public float[] _position;
    public int _health;
    public int _level;
    public int _score;
    public string _scene;

    //Constructor, Establishes variables
    public PlayerData(Player _player)
    {
        Scene temp = SceneManager.GetActiveScene();
        _health = _player.Health;
        _level = _player.Level;
        _score = _player.Score;
        _scene = temp.name;
        _position = new float[3];
        _position[0] = _player.transform.position.x;
        _position[1] = _player.transform.position.y;
        _position[2] = _player.transform.position.z;
    }
}
