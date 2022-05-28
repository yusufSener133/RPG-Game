using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1,10)] float _moveSpeed = 1;
    [SerializeField] Transform _hand;

    Rigidbody2D _rb;
    Vector2 _movement;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovementInput();
        RotateHand();
    }

    void FixedUpdate()
    {
        _rb.velocity = _movement * _moveSpeed;    
    }
    void RotateHand()
    {
        float angle = Utility.AngleTowardsMouse(_hand.position);
        _hand.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void MovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(horizontal, vertical).normalized;
    }
}
