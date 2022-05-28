using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] SpriteRenderer _arrowGFX;
    [SerializeField] Transform _bow;
    [SerializeField] Slider _bowPowerSlider;

    [SerializeField] [Range(0, 10)] float _bowPower;
    [SerializeField] [Range(0, 3)] float _maxBowCharge;

    float _bowCharge;
    bool _canFire = true;

    void Start()
    {
        _bowPowerSlider.value = 0f;
        _bowPowerSlider.maxValue = _maxBowCharge;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && _canFire)
            ChargeBow();
        else if (Input.GetMouseButtonUp(0) && _canFire)
            FireBow();
        else
        {
            if (_bowCharge > 0)
                _bowCharge -= 1f * Time.deltaTime;
            else
            {
                _bowCharge = 0;
                _canFire = true;
            }
        }
    }
    private void ChargeBow()
    {
        _arrowGFX.enabled = true;
        _bowCharge += Time.deltaTime;
        _bowPowerSlider.value = _bowCharge;

        if (_bowCharge > _maxBowCharge)
            _bowPowerSlider.value = _maxBowCharge;
    }
    private void FireBow()
    {
        if (_bowCharge > _maxBowCharge)
            _bowCharge = _maxBowCharge;

        float arrowSpeed = _bowCharge + _bowPower;
        float arrowDamage = _bowCharge * _bowPower;
        float angle = Utility.AngleTowardsMouse(_bow.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        Arrow arrow = Instantiate(_arrowPrefab, _bow.position, rot).GetComponent<Arrow>();
        arrow.ArrowVelocity = arrowSpeed;
        arrow.ArrowDamage = arrowDamage;

        _canFire = false;
        _arrowGFX.enabled = false;


    }
}
