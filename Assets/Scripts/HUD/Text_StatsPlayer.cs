using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_StatsPlayer : MonoBehaviour
{
    private PlayerStats _stats;
    public PlayerStats StatsPlayer
    {
        get
        {
            if(_stats == null)
                _stats = GameObject.Find("Ellen").GetComponent<PlayerStats>();
            return _stats;
        }
    }
}
