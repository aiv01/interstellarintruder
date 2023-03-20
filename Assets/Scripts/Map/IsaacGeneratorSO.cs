using System;
using System.Collections.Generic;
using UnityEngine;


    
    public class IsaacGeneratorSO : MonoBehaviour{
        public string folderPath = "";
        public Transform tr;
        public Vector2 offset;
        private IsaacTileInfo[,] tileInfo;
        public IsaacTileInfo[,] TileInfo
    {
        get { return tileInfo; }
    }
        IsaacTile[,] tiles;
        Queue<Vector2Int> tilesQueue;
        int CellNum = 0;
        public int level = 1;
    private void Start()
    {
        Generate(tr, 10, 10);
    }
    public void Generate(Transform container, int width, int height)
        {
            
            tiles = new IsaacTile[width, height];
            tilesQueue = new Queue<Vector2Int>();
            IsaacTile startingTile = new IsaacTile();
            startingTile.SetDoor(isaacDoorDirection.NoDoor);
            CellNum = UnityEngine.Random.Range(0, 2) + 5 + level * 2;
            tiles[width / 2, height / 2] = startingTile;
            tilesQueue.Enqueue(new Vector2Int(width / 2, height / 2));
            IsaacTile newTile;
            IsaacTile oldTile;
            Vector2Int tilePosition;
            Vector2Int newTilePosition;
            while (CellNum > 0)
            {
                tilePosition = tilesQueue.Dequeue();
                for (int x = 1; x < 9; x *= 2)
                {
                    
                    oldTile = tiles[tilePosition.x, tilePosition.y];
                    if (oldTile.HasDoor((isaacDoorDirection)x))
                    {
                        continue;
                    }
                    newTilePosition = NewTilePosition((isaacDoorDirection)x, tilePosition);
                    if (HasNeibourg(newTilePosition))
                    {
                        continue;
                    }
                    if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
                    {
                        continue;
                    }
                    Debug.Log(CellNum);
                    oldTile.SetDoor((isaacDoorDirection)x);
                    newTile = new IsaacTile();
                    newTile.SetOppositeDoor((isaacDoorDirection)x);
                    tiles[newTilePosition.x, newTilePosition.y] = newTile;
                    tilesQueue.Enqueue(newTilePosition);
                    CellNum--;
                    if (CellNum < 1) break;

                }
                tilesQueue.Enqueue(tilePosition);
            }
        
            for(int y = 0; y < width; y++)
            {
                for(int x = 0; x < height; x++)
                {
                    
                    if (tiles[y, x] != null)
                    {

                    //var path = folderPath + " " + tiles[y, x].doors;
                    var path = folderPath;
                        var tilePrefabs = Resources.LoadAll<IsaacTileInfo>(path);
                        var tilePrefab = tilePrefabs[UnityEngine.Random.Range(0, tilePrefabs.Length)];
                        tiles[y, x].info = tilePrefab;
                    }
                    
                    
                }
                
            }
            
            DrawMap(container, width, height);
        }
        private void DrawMap(Transform container, int width, int height)
        {
        tileInfo = new IsaacTileInfo[width, height];
        for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    if (tiles[col, row] != null)
                    {
                        var go = Instantiate(tiles[col, row].info, container);
                        go.gameObject.SetActive(false);
                        go.name = "Tile " + col + ", " + row;
                        go.transform.localPosition = new Vector3(col * offset.x, 0, row * offset.y);
                        tileInfo[col,row] = go;
                    }
                }
            }
        }
        public bool HasNeibourg(Vector2Int pos)
        {
            Vector2Int newpos;
            int neibourgCount = 0;
            for (int x = 1; x < 9; x *= 2)
            {
                newpos = NewTilePosition((isaacDoorDirection)x, pos);
                if (newpos.x > tiles.GetLength(0)-1 || newpos.x < 0 || newpos.y > tiles.GetLength(1)-1 || newpos.y < 0) 
                    return true;
                if(tiles[newpos.x , newpos.y] != null) neibourgCount++;
            }
            return neibourgCount > 1;
        }
        public Vector2Int NewTilePosition(isaacDoorDirection door, Vector2Int oldPos)
        {
            switch (door){
                case isaacDoorDirection.North:
                        return oldPos += Vector2Int.up;
                case isaacDoorDirection.East:
                        return oldPos += Vector2Int.right;
                case isaacDoorDirection.South:
                        return oldPos += Vector2Int.down;
                case isaacDoorDirection.West:
                        return oldPos += Vector2Int.left;
                default:
                    return oldPos;
            }
        }
    }
        [Flags]
        public enum isaacDoorDirection : int
        {
            NoDoor = 0,
            North = 1,
            East = 2,
            South = 4,
            West = 8,
        }
        class IsaacTile
        {
            public int doors = 0;
            public IsaacTileInfo info;
            public void SetDoor(isaacDoorDirection door)
            {
                doors |= (int)door;
            }

            public void Remove(isaacDoorDirection door)
            {
                doors &= (int)~door;
            }
            public void SetOppositeDoor(isaacDoorDirection door)
        {
            switch (door)
            {
                case isaacDoorDirection.North:
                    this.SetDoor(isaacDoorDirection.South);
                    break;
                case isaacDoorDirection.East:
                    this.SetDoor(isaacDoorDirection.West);
                    break;
                case isaacDoorDirection.South:
                    this.SetDoor(isaacDoorDirection.North);
                    break;
                case isaacDoorDirection.West:
                    this.SetDoor(isaacDoorDirection.East);
                    break;
                default:
                    this.SetDoor(isaacDoorDirection.NoDoor);
                    break;
                    
            }
        }
            public bool HasDoor(isaacDoorDirection door)
            {
                switch (door)
                {
                    case isaacDoorDirection.North:
                        return (doors & 1) == 1;
                    case isaacDoorDirection.East:
                        return (doors & 2) == 2;
                    case isaacDoorDirection.South:
                        return (doors & 4) == 4;
                    case isaacDoorDirection.West:
                        return (doors & 8) == 8;
                    default:
                        return false;
                }
            }

        }
    
