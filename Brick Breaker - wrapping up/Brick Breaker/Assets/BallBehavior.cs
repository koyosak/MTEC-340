using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallBehavior : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _yLimit = 4.8f;
    [SerializeField] float _xLimit = 6.3f;

    [SerializeField] AudioClip Wall;
    [SerializeField] AudioClip Brick;
    [SerializeField] AudioClip Paddle;

    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        // Start the ball in a random normalized direction for smooth movement
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
        // Move the ball
            transform.position += new Vector3(
                _speed * _direction.x,
                _speed * _direction.y,
                0.0f
            ) * Time.deltaTime;

            // Bounce the ball off screen boundaries
            if (Mathf.Abs(transform.position.y) >= _yLimit)
            {
                _direction.y *= -1;
                transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * _yLimit, transform.position.z);
                 _source.clip = Wall;
                 _source.Play();
            }

            if (Mathf.Abs(transform.position.x) >= _xLimit)
            {
                _direction.x *= -1;
                transform.position = new Vector3(Mathf.Sign(transform.position.x) * _xLimit, transform.position.y, transform.position.z);
                 _source.clip = Wall;
                 _source.Play();
            }

        
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Bounce off the paddle
        if (other.transform.CompareTag("Paddle"))
        {
            Vector2 contactPoint = other.contacts[0].point;
            Vector2 paddleCenter = other.transform.position;

            // Calculate offset to adjust the bounce based on hit position on paddle
            float offset = contactPoint.x - paddleCenter.x;
            _direction = new Vector2(offset, _direction.y).normalized;
            _direction.y *= -1;
             _source.clip = Paddle;
             _source.Play();            
        }

        // Bounce off bricks
        if (other.transform.CompareTag("Bricks"))
        {
            Debug.Log("Collision with Brick Detected");
            // Use the collision normal to reflect the ball
            ContactPoint2D contact = other.contacts[0];
            Vector2 normal = contact.normal;

            // Reflect the ball’s direction
            _direction = Vector2.Reflect(_direction, normal);
             _source.clip = Brick;
             _source.Play();
        }
    
    
    }


}
