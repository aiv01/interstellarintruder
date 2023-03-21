using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : Interactable
{
    
    private void OnTriggerStay()
    {
        if (false)
        {
            
            ChangeStatus();
            myEvent.Invoke(status);
        }
    }
}
