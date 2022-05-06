using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] _position;
    public int _health;
    public int _wires;

    public PlayerData(Player _player)
    {
        _health = _player.Health;
        _position = new float[3];
        _position[0] = _player.transform.position.x;
        _position[1] = _player.transform.position.y;
        _position[2] = _player.transform.position.z;

        _wires = _player.Wires;
    }
}
