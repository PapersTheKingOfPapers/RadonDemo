using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DataManager
{
    //Save Data to JSON file
    public static void SavePlayerDataToJSON(Player _player)
    {
        //Create playerData object
        PlayerData _playerData = new PlayerData(_player);

        //Convert data to JSON
        string _json = JsonUtility.ToJson(_playerData);

        //Save JSON as a file
        File.WriteAllText($"{Application.dataPath}/playerData.json", _json);
    }

    public static PlayerData LoadPlayerDataFromJSON()
    {
        //Load JSON file
        string _json = File.ReadAllText($"{Application.dataPath}/playerData.json");
        //Insert JSON content to PlayerData
        PlayerData _playerData = JsonUtility.FromJson<PlayerData>(_json);
        return _playerData;
    }
    public static void ResetPlayerDataToJSON()
    {
        DefaultPlayerData _playerData = new DefaultPlayerData();

        //Convert data to JSON
        string _json = JsonUtility.ToJson(_playerData);

        //Save JSON as a file
        File.WriteAllText($"{Application.dataPath}/playerData.json", _json);
    }

}
