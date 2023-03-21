using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class IsaacTileInfo : MonoBehaviour
{
    public string id = "";
    public bool visited = false;
    [SerializeField, DoNotSerialize] private List<Spawner> Spawners;
    [SerializeField, DoNotSerialize] public List<Door> Doors;
    public void SpawnAll()
    {
        if (!visited)
            foreach (Spawner spawner in Spawners)
            {
                spawner.Spawn();
            }
    }

    public void DespawnAll()
    {
        if (!visited)
            foreach (Spawner spawner in Spawners)
            {
                spawner.Despawn();
            }
    }
}
