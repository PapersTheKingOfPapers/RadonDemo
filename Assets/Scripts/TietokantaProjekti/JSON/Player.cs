using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using Fragsurf.Movement;

public class Player : MonoBehaviour
{
    //Singles
    private static Player _instance;

    //State information
    [SerializeField] private int _health;
    [SerializeField] private int _level;
    //Score from bulletBoxes
    private int _score;

    //Properties
    public int Health { get => _health; set => _health = value; }
    public int Level { get => _level; set => _level = value; }
    public int Score { get => _score; set => _score = value; }

    [SerializeField] private InventoryManager _inventoryManager;

    [SerializeField] private TMP_Text _playerName;

    private Scene _currentScene;
    public static Player Instance 
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(message: "Error 0-0, No Player Instance!");
            }
            return _instance;
        } 
    }
    private void Awake()
    {
        _instance = this;
    }

    //Save Player Character Data to JSON file
    public void SavePlayerDataToJSON()
    {
        //print("Saving in progress...");
        DataManager.SavePlayerDataToJSON(this);
    }

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        _playerName.text = Login._nickname;
        Debug.Log("Player Start method worked");
        LoadPlayerDataFromJSON();
    }

    private void LoadPlayerDataFromJSON()
    {
        SurfCharacter _surfChar = this.gameObject.GetComponent<SurfCharacter>();
        PlayerData _playerData = DataManager.LoadPlayerDataFromJSON();

        _health = _playerData._health;
        _level = _playerData._level;
        _score = _playerData._score;

        Vector3 _position = new Vector3()
        {
            x = _playerData._position[0],
            y = _playerData._position[1],
            z = _playerData._position[2]
        };

        //transform.position = _position;
        //Debug.Log(_position);

        CollectGem._hit = true;

        if(_currentScene.name != _playerData._scene)
        {
            Debug.Log("Loading Scene " + _playerData._scene + " Current Scene: " + _currentScene.name);
            SceneManager.LoadScene(_playerData._scene);
        }
        Debug.Log("Player Load Method Worked");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K)) SavePlayerDataToJSON();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            PickUp _item = other.GetComponent<PickUp>();
            _inventoryManager.Add(_item);
            Destroy(other.gameObject);
        }
    }
}
