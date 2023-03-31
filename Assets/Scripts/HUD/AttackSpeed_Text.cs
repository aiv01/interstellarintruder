using UnityEngine;
using UnityEngine.UI;

public class AttackSpeed_Text : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = _stats.SpeedAttack.ToString();
    }
}
