using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressF : MonoBehaviour
{
    private GameObject playerTarget;
    private GameObject stairTarget;
    [SerializeField]
    private Text _text;

    private void Awake()
    {
        playerTarget = GameObject.Find("Ellen");
        stairTarget = GameObject.Find("Stairs");
    }

    private void FixedUpdate()
    {
        float dist = (playerTarget.transform.position - stairTarget.transform.position).magnitude;
        if(dist <= 6.5f)
            _text.gameObject.SetActive(true);
        else
            _text.gameObject.SetActive(false);
    }
}
