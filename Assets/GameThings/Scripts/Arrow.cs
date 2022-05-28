using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float _arrowVelocity;
    float _arrowDamage;
    public float ArrowVelocity { 
        get 
        { 
            return _arrowVelocity; 
        }
        set
        {
            _arrowVelocity = value;
        }
    }
    public float ArrowDamage {
        get
        {
            return _arrowDamage;
        }
        set
        {
            _arrowDamage = value;
        }
    }
    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, 4f);
    }
    private void FixedUpdate()
    {
        _rb.velocity = transform.up * _arrowVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(_arrowDamage);
        }
        Destroy(gameObject);
    }
}
