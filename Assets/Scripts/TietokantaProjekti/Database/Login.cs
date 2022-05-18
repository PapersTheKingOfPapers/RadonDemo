using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using TMPro;
using System.Data;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField _pincode;
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private string _nextLevel;

    private string _dbConnectionString;

    public static string _nickname = "";

    //Automatic
    public bool LoginOK { get; set; }

    private void Awake()
    {
        _dbConnectionString = "URI=file:SQLDatabase.db";
        LoginOK = false;
    }

    public void LogIn()
    {
        Debug.Log("Login Called");
        //print($"pincode:{_pincode.text}");

        using(var _connection = new SqliteConnection(_dbConnectionString))
        {
            _connection.Open();
            using (var _command = _connection.CreateCommand())
            {
                _command.CommandText = $"select * from login where pincode = '{_pincode.text}'";
                using (IDataReader _reader = _command.ExecuteReader())
                {
                    while (_reader.Read())
                    {
                        _nickname = _reader["nickname"].ToString();
                        LoginOK = true;
                    }
                    _reader.Close();
                }
                _connection.Close();
            }
        }

        if(!LoginOK)
        {
            _errorText.gameObject.SetActive(true);
            return;
        }
        //print("Kirjautuminen onnistui");
        _errorText.gameObject.SetActive(false);
        PlayerData _playerData = DataManager.LoadPlayerDataFromJSON();
        SceneManager.LoadScene(_playerData._scene);
    }
}
