using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class InteractSwitch : Interactable
{
    public PlayerInput input;
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
    private void OnTriggerStay()
    {
        if (input.Input.Interaction.ReadValue<bool>())
        {
            
            ChangeStatus();
            myEvent.Invoke(status);
        }
    }
}
