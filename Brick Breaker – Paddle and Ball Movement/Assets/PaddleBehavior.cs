using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float YLimit = 4.15f;

    public KeyCode UpKey;
    public KeyCode DownKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(UpKey) && transform.position.y < YLimit)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        }
        if (Input.GetKey(DownKey) && transform.position.y > -YLimit)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        }       
    }
}
