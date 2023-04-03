using UnityEngine;
using UnityEngine.UI;

public class Damage_Text : Text_StatsPlayer
{
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = StatsPlayer.Damage.ToString();
    }
}
