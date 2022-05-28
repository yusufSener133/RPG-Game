using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 4, _attackDamage = 10f;
    float _attackSpeed = 1f,_canAttack = 1f;

    [Header("Health")]
    [SerializeField] float _maxHealth;
    float _health;

    Transform _target;

    void Start()
    {
        _health = _maxHealth;   
    }
    void FixedUpdate()
    {
        if (_target != null)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_attackSpeed <= _canAttack)
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-_attackDamage);
                _canAttack = 0;
            }
            else
                _canAttack += Time.deltaTime;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        _canAttack = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _target = collision.transform;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _target = null;
        }
    }

    public void TakeDamage(float _damage)
    {
        _health -= _damage;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
