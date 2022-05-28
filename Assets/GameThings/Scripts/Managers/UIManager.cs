using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _deathPanel;
    public void ToggleDeathPanel()
    {
        _deathPanel.SetActive(!_deathPanel.activeSelf);
    }
}
