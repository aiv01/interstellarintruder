
using UnityEngine;
using UnityEngine.Events;

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
    private bool inTrigger = false;
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
        if (roomManager == null) roomManager = RoomManager.FindObjectOfType<RoomManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    private void Update()
    {
        if(input.Input.Interaction.WasPerformedThisFrame() && inTrigger && doorOpen)
        {
            inTrigger = false;
            doorEvent.Invoke(doorDirection);
        }
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
