using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBG : MonoBehaviour
{
    Vector2 _startPos;
    [SerializeField] int _moveModifier;

    private void Start()
    {
        _startPos = transform.position;
    }
    private void Update()
    {
        Vector2 _pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, _startPos.x + (_pz.x * _moveModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, _startPos.y + (_pz.y * _moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, transform.position.z);

    }
}
