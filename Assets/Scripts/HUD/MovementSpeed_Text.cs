using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpeed_Text : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;
    [SerializeField]
    private Text _text;

    private void Update()
    {
        _text.text = _stats.SpeedMovement.ToString();
    }
}
