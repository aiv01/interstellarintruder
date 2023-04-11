using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image[] _goHealth;

    private PlayerStats _playerStats;
    private int index;
    private float health;

    private void Start()
    {
        _playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        index = Mathf.FloorToInt(_playerStats.Health / 10);
        for(int i = 0; i < _goHealth.Length; i++)
        {
            if(i < index)
            {
                _goHealth[i].fillAmount = 1;
            }
            else if(i == index)
            {
                health = (_playerStats.Health / 10) - index;
                _goHealth[i].fillAmount = health;
            }
            else if(i > index)
                _goHealth[i].fillAmount = 0;
        }
    }
}
