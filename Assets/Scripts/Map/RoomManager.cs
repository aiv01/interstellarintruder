
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class WarpPlayer : UnityEvent<Vector3>  { }
public class RoomManager : MonoBehaviour
{
    public IsaacTileInfo[,] isaacTileInfos;
    public Save saveMgr;
    public Transform player;
    private Vector2Int tilePos;
    private IsaacTileInfo currentTile;
    private IsaacTileInfo nextTile;
    private float secondToWait = 0.5f;
    private float secondPassed = 0.0f;
    public WarpPlayer myWarp;
    private void Start()
    {
        if(!GameObject.Find("GameMgr").GetComponent<GameManager>().onLoad)
            Init();
    }
    public void Init()
    {
        isaacTileInfos = GetComponent<IsaacGeneratorSO>().TileInfo;
        tilePos = new Vector2Int(isaacTileInfos.GetLength(0)/2, isaacTileInfos.GetLength(1)/2);
        currentTile = isaacTileInfos[tilePos.x, tilePos.y];
        currentTile.gameObject.SetActive(true);
        myWarp.Invoke(currentTile.transform.position);
        currentTile.SpawnAll();
        ActivateDoors(currentTile.visited);
    }
    public void Load(Vector2Int pos)
    {
        isaacTileInfos = GetComponent<IsaacGeneratorSO>().TileInfo;
        tilePos = new Vector2Int(isaacTileInfos.GetLength(0) / 2, isaacTileInfos.GetLength(1) / 2);
        currentTile = isaacTileInfos[pos.x,pos.y];
        currentTile.gameObject.SetActive(true);
        myWarp.Invoke(currentTile.transform.position);
        currentTile.SpawnAll();
        ActivateDoors(currentTile.visited);
    }
    public void DoorWarp (isaacDoorDirection doorDirection)
    {
        switch (doorDirection)
        {
            case isaacDoorDirection.North:
                tilePos += Vector2Int.up;
                break;
            case isaacDoorDirection.South:
                tilePos += Vector2Int.down;
                break;
            case isaacDoorDirection.East:
                tilePos += Vector2Int.right;
                break;
            case isaacDoorDirection.West:
                tilePos += Vector2Int.left;
                break;
        }
        nextTile = isaacTileInfos[tilePos.x, tilePos.y];
        nextTile.gameObject.SetActive(true);
        nextTile.SpawnAll();
        foreach (Door door in nextTile.Doors)
        {
            switch (doorDirection)
            {
                case isaacDoorDirection.North:
                    if (door.doorDirection == isaacDoorDirection.South)
                        myWarp.Invoke(door.SpawnPlayer());
                    break;
                case isaacDoorDirection.South:
                    if(door.doorDirection == isaacDoorDirection.North)
                        myWarp.Invoke(door.SpawnPlayer());
                    break;
                case isaacDoorDirection.East:
                    if(door.doorDirection == isaacDoorDirection.West)
                        myWarp.Invoke(door.SpawnPlayer());
                    break;
                case isaacDoorDirection.West:
                    if(door.doorDirection == isaacDoorDirection.East)
                        myWarp.Invoke(door.SpawnPlayer());
                    break;
            }
        }
        currentTile.DespawnAll();
        currentTile.gameObject.SetActive(false);
        currentTile = nextTile;
        
        ActivateDoors(currentTile.visited);
        
        saveMgr.SaveGen();
        saveMgr.SavePlayer(tilePos);
    }

    public void ActivateDoors(bool status)
    {
        foreach(Door door in currentTile.Doors)
        {
            door.OpenCloseDoor(status);
        }
    }
    private void Update()
    {
        if(secondPassed > secondToWait)
        {
            if(currentTile.enemyCounter <= 0 && currentTile.interactable)
            {
                ActivateDoors(true);
                currentTile.visited = true;
            }
            secondPassed = 0.0f;
        }
        secondPassed += Time.deltaTime;
    }
}
