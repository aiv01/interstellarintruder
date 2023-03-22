using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public IsaacGeneratorSO gen;
    public PlayerStats stats;
    private string file = "map.sav";
    private string playerSav = "player.sav";
    public bool save;
    public bool load;

    private void Update()
    {
        if (save)
        {
            save = false;
            SaveGen();
        }
        if (load)
        {
            load = false;
            LoadGen();
        }
    }
    public void SaveGen()
    {
        TileMapData data = new TileMapData(new Vector2Int(gen.tiles.GetLength(0), gen.tiles.GetLength(1)), gen.level);
        TileInfo info;
        for (int y = 0; y < gen.tiles.GetLength(0); y++)
        {
            for (int x = 0; x < gen.tiles.GetLength(1); x++)
            {

                if (gen.tiles[y, x] != null && gen.tiles[y, x].info != null)
                {
                    var tile = gen.tiles[y, x];
                    info = new TileInfo(tile.doors, tile.info.id, tile.info.visited, new Vector2Int(y, x));
                    data.tiles.Add(info);
                }
            }
        }
        FileHandler.SaveToJSON(data, file);
    }
    public void SavePlayer()
    {
        PlayerInfo info = new PlayerInfo(stats.HP, stats.Attack, stats.SpeedAttack, stats.SpeedMovement);
        FileHandler.SaveToJSON(info, playerSav);
    }
    public void LoadPlayer()
    {
        PlayerInfo info = FileHandler.ReadFromJSON<PlayerInfo>(playerSav);
        stats.HP = info.hp;
        stats.Attack = info.attackDamage;
        stats.SpeedAttack = info.attackSpeed;
        stats.SpeedMovement = info.speedMovement;
    }
    public void LoadGen()
    {
        TileMapData data = FileHandler.ReadFromJSON<TileMapData>(file);
        //gamemanager.level = data.level;
        gen.LoadMap(gen.tr, data);
    }

}

[Serializable]
public class TileMapData
{
    public List<TileInfo> tiles;
    public Vector2Int dimensions;
    public int level;
    public TileMapData(Vector2Int dimensions, int level)
    {
        tiles = new List<TileInfo>();
        this.dimensions = dimensions;
        this.level = level;
    }
}

[Serializable]
public class TileInfo
{
    public int doors;
    public string tileId;
    public bool visitedTile;
    public Vector2Int pos;

    public TileInfo(int doors, string tileId, bool visitedTile, Vector2Int pos)
    {
        this.doors = doors;
        this.tileId = tileId;
        this.visitedTile = visitedTile;
        this.pos = pos;
    }
}
[Serializable]
public class PlayerInfo
{
    public float hp;
    public float attackDamage;
    public float attackSpeed;
    public float speedMovement;

    public PlayerInfo(float hp, float attackDamage, float attackSpeed, float speedMovement)
    {
        this.hp = hp;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
        this.speedMovement = speedMovement;
    }
}

