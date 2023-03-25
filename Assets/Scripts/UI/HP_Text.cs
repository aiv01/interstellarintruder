using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Text : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private PlayerStats _stats;

    void Start()
    {
        _text.text += _stats.HP.ToString();
    }
}
