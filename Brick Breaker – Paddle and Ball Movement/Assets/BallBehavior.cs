using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed = 3.0f;
    public float YLimit = 4.86f;
    public float XLimit = 6.14f;

    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Speed * _direction.x,
            Speed * _direction.y,
            0.0f
        ) * Time.deltaTime;

        if (Mathf.Abs(transform.position.y) >= YLimit)
        {
            _direction.y *= -1;
        }
        
        if (Mathf.Abs(transform.position.x) >= XLimit)
        {
            ResetBall();
        }
    }
    
    void ResetBall()
    {
        transform.position = Vector3.zero;

        _direction = new Vector2(
            Random.value > 0.5f ? 1 : -1,
            Random.value > 0.5f ? 1 : -1
        );
    }
}
