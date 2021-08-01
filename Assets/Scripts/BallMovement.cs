using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed; 
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _radius;

    private bool _isJumping;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _isJumping = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        transform.position +=  Vector3.right * _speed * Time.deltaTime;
        _rigidbody.rotation += _rotationSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isJumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<GroundPart>(out _))
            _isJumping = false;
    }
}
