
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

[System.Serializable]
public class MyDoorEvent : UnityEvent<isaacDoorDirection>
{
}
public class Door : MonoBehaviour
{
    public PlayerInput input;
    public isaacDoorDirection doorDirection;
    private bool doorOpen = false;
    private MyDoorEvent doorEvent;
    public RoomManager roomManager;
    private Animator animator;
    private Animator Animator
    {
        get
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }
            return animator;
        }
    }

    public void Awake()
    {
        input = new PlayerInput();
    }
    public void Start()
    {
        if(roomManager == null) roomManager = RoomManager.FindObjectOfType<RoomManager>();
        animator = GetComponent<Animator>();
        doorEvent = new MyDoorEvent();
        doorEvent.AddListener(roomManager.DoorWarp);
    }
    public Vector3 SpawnPlayer()
    {
        switch (doorDirection)
        {
            case isaacDoorDirection.North:
                return transform.position + Vector3.back;
                ;
            case isaacDoorDirection.South:
                return transform.position + Vector3.forward;
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
        if(input.Input.Interaction.ReadValue<float>() > 0 && other.CompareTag("Player"))
        doorEvent.Invoke(doorDirection);
        
    }

   

    public void OpenCloseDoor(bool status)
    {
        doorOpen = status;
        Animator.SetBool("open", doorOpen);
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
}
