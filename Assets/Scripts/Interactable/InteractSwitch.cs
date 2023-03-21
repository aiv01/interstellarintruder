using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : Interactable
{
    
    private void Update()
    {
        if (false)
        {
            
            ChangeStatus();
            myEvent.Invoke(status);
        }
    }
}
