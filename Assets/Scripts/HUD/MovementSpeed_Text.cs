using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpeed_Text : Text_StatsPlayer
{
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = StatsPlayer.SpeedMovement.ToString();
    }
}
