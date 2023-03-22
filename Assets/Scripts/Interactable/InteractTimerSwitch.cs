using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InteractTimerSwitch : Interactable
{
    public PlayerInput input;
    private float timeRemaining = 0.0f;
    public float timeTotal = 1.0f;
    public bool testBool;
    public void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void OnTriggerStay(Collider other)
    {
        if (input.Input.Interaction.ReadValue<float>() >0 && other.CompareTag("Player"))
        {
            
            ChangeStatus();
            myEvent.Invoke(status);
            timeRemaining = timeTotal;
        }

       
    }

    

    private void Update()
    {
        if (testBool && !status)
        {

            ChangeStatus();
            myEvent.Invoke(status);
            timeRemaining = timeTotal;
        }
        if (status)
        {
            if (timeRemaining <= 0.0f)
            {
                ChangeStatus();
                myEvent.Invoke(status);
                testBool = false;
            }
            timeRemaining -= Time.deltaTime;
        }
    }
}
