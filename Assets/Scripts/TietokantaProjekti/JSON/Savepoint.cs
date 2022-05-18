using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint : MonoBehaviour
{
    [SerializeField] private bool _startSave = false;

    private void Awake()
    {
        if(_startSave == true)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject i in temp)
            {
                if (i.GetComponent<Player>())
                {
                    DataManager.SavePlayerDataToJSON(i.GetComponent<Player>());
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_startSave == false)
        {
            if (other.CompareTag("Player"))
            {
                GameObject temp = other.transform.parent.gameObject;
                DataManager.SavePlayerDataToJSON(temp.GetComponent<Player>());
                this.gameObject.SetActive(false);
            }
        }
    }
}
