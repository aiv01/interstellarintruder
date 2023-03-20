
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public IsaacTileInfo[,] isaacTileInfos;
    public Transform player;
    private Vector2Int tilePos;
    private IsaacTileInfo currentTile;
    private IsaacTileInfo nextTile;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        isaacTileInfos = GameObject.FindObjectOfType<IsaacGeneratorSO>().TileInfo;
        tilePos = new Vector2Int(isaacTileInfos.GetLength(0), isaacTileInfos.GetLength(1));
        currentTile = isaacTileInfos[tilePos.x, tilePos.y];
        currentTile.gameObject.SetActive(true);
        currentTile.SpawnAll();
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
                    if(door.doorDirection == isaacDoorDirection.South)
                        player.transform.position = door.SpawnPlayer();
                    break;
                case isaacDoorDirection.South:
                    if(door.doorDirection == isaacDoorDirection.North)
                        player.transform.position = door.SpawnPlayer();
                    break;
                case isaacDoorDirection.East:
                    if(door.doorDirection == isaacDoorDirection.West)
                        player.transform.position = door.SpawnPlayer();
                    break;
                case isaacDoorDirection.West:
                    if(door.doorDirection == isaacDoorDirection.East)
                        player.transform.position = door.SpawnPlayer();
                    break;
            }
        }
        currentTile.DespawnAll();
        currentTile.gameObject.SetActive(false);
        nextTile = currentTile;
        nextTile = null;
    }
}
