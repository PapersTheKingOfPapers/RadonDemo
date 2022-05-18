using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    public static bool _hit = false;

    [SerializeField] private int _scorePoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hit = true;

            Player.Instance.Score += _scorePoints;

            Destroy(gameObject);
        }
    }
}
