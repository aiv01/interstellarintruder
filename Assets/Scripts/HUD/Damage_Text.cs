using UnityEngine;
using UnityEngine.UI;

public class Damage_Text : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = _stats.Damage.ToString();
    }
}
