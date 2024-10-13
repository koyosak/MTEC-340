using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameBehavior : MonoBehaviour
{
   public static GameBehavior Instance;

   [SerializeField] private int _scoreToVictory = 9;
   
   [SerializeField] Player[] _player;

   public Utilities.GameplayState State = Utilities.GameplayState.Play;

   private void Awake()
   {
    if (Instance != null && Instance != this)
    {
        Destroy(this);
    }
    else
    {
        Instance = this;
    }
    
   }

   private void Start()
   {
    
    foreach (Player p in _player)
    {
        p.Score = 0;
    }

   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           State = State == Utilities.GameplayState.Play?
               Utilities.GameplayState.Pause: 
               Utilities.GameplayState.Play;
       }
   }

   public void ScorePoint(int playerNumber)
   {
       _player[playerNumber - 1].Score += 1;
   }

   private void CheckWinner()
   {
       foreach (Player p in _player)
       {
           if (p.Score >= _scoreToVictory)
           {
               ResetGame();
           }
       }
   }

   void ResetGame()
   {
       foreach (Player p in _player)
       {
           p.Score = 0;
       }
   }

}


