using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;
    public float XLimit = 4.7f;

    public KeyCode RightKey;
    public KeyCode LeftKey;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
      {
          if (Input.GetKey(RightKey) && transform.position.x < XLimit)
        { 
          transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }

         if (Input.GetKey(LeftKey) && transform.position.x > -XLimit)
        { 
          transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        }  
          float clampedX = Mathf.Clamp(transform.position.x, -XLimit, XLimit);
      }


    }

    
}
