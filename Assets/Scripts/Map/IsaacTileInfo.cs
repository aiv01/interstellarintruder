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
    [SerializeField] private List<Spawner> Spawners;
    [SerializeField] public List<Door> Doors;
    public int enemyCounter = 0;
    public bool interactable = true;
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

    public void OnInteract(bool interacted)
    {
        interactable = interacted;
    }
}
