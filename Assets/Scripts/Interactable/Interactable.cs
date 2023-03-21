using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnInteract : UnityEvent<bool> { }

public abstract class Interactable : MonoBehaviour
{
    public OnInteract myEvent;
    protected bool status = false;
    public void Spawn()
    {
        status = false;
        myEvent.Invoke(status);
    }
    protected void ChangeStatus()
    {
        status = !status;
    }
}
