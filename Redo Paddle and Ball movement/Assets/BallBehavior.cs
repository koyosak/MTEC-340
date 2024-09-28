using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float Speed = 2.0f;
    public float YLimit = 4.8f;
    public float XLimit = 5.8f;


    private Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
       _direction = new Vector2(5.8f, 4.8f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3
        (
            Speed * _direction.x,
            Speed * _direction.y,
            0.0f
        ) * Time.deltaTime;

        if (Mathf.Abs(transform.position.y) >= YLimit)
        {
            _direction.y *= -1;
        }

        if (Mathf.Abs(transform.position.y) <= -YLimit)
        {
            _direction.y *= -1;
        }
 
        if (Mathf.Abs(transform.position.x) >= XLimit)
        {
            ///ResetBall();
            _direction.x *= -1;
            
        }

        if (Mathf.Abs(transform.position.x) <= -XLimit)
        {
            ///ResetBall();
            _direction.x *= -1;
            
        }        
    }

    ///void ResetBall()
    ///{
    ///    transform.position = new Vector3(0.3f, -3.8f, 0f);
///
    ///    _direction = new Vector2(
    ///         Random.value > 0.5f ? 1 : -1,
    ///         Random.value > 0.5f ? 1 : -1
    ///    );
    ///}


}
