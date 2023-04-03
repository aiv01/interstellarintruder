using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Text : Text_StatsPlayer
{
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = StatsPlayer.Health.ToString();
    }
}
