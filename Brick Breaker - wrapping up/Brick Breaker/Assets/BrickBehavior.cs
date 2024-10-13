using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            Destroy(gameObject, 0.1f);
            GameBehavior.Instance.ScorePoint(1);
        }
    }
}
