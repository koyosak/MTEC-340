using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
        private int _score = 0;
    public int Score
    {
        get => _score;

        set
        {
            _score = value;

            _scoreGUI.text = Score.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreGUI;


}

