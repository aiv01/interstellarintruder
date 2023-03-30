using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextLevel : UnityEvent
{

}
public class WarpNextLevel : MonoBehaviour
{
    private NextLevel nextlevel;
    public void nextLevel(bool status)
    {
        if (status)
        {
            GameObject.Find("GameMgr").SendMessage("ChangeLevel");
        }
    }
    
}
