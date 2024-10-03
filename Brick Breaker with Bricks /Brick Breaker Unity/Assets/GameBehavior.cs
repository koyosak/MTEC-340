using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameBehavior : MonoBehaviour
{
   public static GameBehavior Instance;
   [SerializeField] Player[] _player;

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

}


