using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class InteractTimerSwitch : Interactable
{
    private float timeRemaining = 0.0f;
    public float timeTotal = 1.0f;
    public bool testBool;
    private void OnTriggerStay()
    {
        if (false)
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
