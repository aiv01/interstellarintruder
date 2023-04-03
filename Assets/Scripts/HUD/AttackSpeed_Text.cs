using UnityEngine;
using UnityEngine.UI;

public class AttackSpeed_Text : Text_StatsPlayer
{
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = StatsPlayer.SpeedAttack.ToString();
    }
}
