using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacTileInfo : MonoBehaviour
{
    string id = "";
    bool visited = false;
    [SerializeField] private List<Transform> enemySpawns;
    [SerializeField] private List<Transform> powerUpsSpawns;
    [SerializeField] public List<Door> Doors;
    public void SpawnAll()
    {

    }

    public void DespawnAll()
    {

    }
}
