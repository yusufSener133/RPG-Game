using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    [SerializeField] Slider _healthSlider;
    float _health = 0f;

    private void Start()
    {
        _health = _maxHealth;
        _healthSlider.maxValue = _maxHealth;
    }


    public void UpdateHealth(float _damage)
    {
        _health += _damage;

        if (_health > _maxHealth)
            _health = _maxHealth;
        else if (_health <= 0f)
        {
            _health = 0f;
            _healthSlider.value = _health;
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    private void OnGUI()
    {

        _healthSlider.value = Mathf.Lerp(_healthSlider.value, _health, Time.deltaTime / 1f);

    }
}
