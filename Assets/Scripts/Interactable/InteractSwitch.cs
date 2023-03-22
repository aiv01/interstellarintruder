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
    private void OnTriggerStay(Collider other)
    {
        if (input.Input.Interaction.ReadValue<float>() > 0 && other.CompareTag("Player"))
        {
            
            ChangeStatus();
            myEvent.Invoke(status);
        }
    }
}
