using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    // [Header("Bools")]
    public bool flag; // = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if(flag is true)
        {
            Debug.Log("Boolean flag is set");
        }
        else 
        {
            Debug.Log("Boolean flag isn't set");
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
