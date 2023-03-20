
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class MyDoorEvent : UnityEvent<isaacDoorDirection>
{
}
public class Door : MonoBehaviour
{
    public isaacDoorDirection doorDirection;
    public bool doorOpen = false;
    private MyDoorEvent doorEvent;
    public RoomManager roomManager;

    public void Start()
    {
        doorEvent.AddListener(roomManager.DoorWarp);
    }
    public Vector3 SpawnPlayer()
    {
        switch (doorDirection)
        {
            case isaacDoorDirection.North:
                return transform.position + Vector3.down;
                ;
            case isaacDoorDirection.South:
                return transform.position + Vector3.up;
                ;
            case isaacDoorDirection.East:
                return transform.position + Vector3.left;
                
            case isaacDoorDirection.West:
                return transform.position + Vector3.right;
               
        }
        return transform.position;
    }
    public void OnDestroy()
    {
        doorEvent.RemoveAllListeners();
    }

    private void OnTriggerStay(Collider other)
    {
        //If Input
        doorEvent.Invoke(doorDirection);
        
    }

}
