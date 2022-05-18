using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void Update()
    {
        //Update GUI
        UpdateScoreGUI();
    }

    private void UpdateScoreGUI()
    {
        //Update GUI? (hit = true --> want to update)
        if (CollectGem._hit)
        {
            //Update score shown on screen
            _scoreText.text = $"Score: {Player.Instance.Score}";

            //Reset hit
            CollectGem._hit = false;
        }
    }
}
