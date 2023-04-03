using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private EnemyAI myEnemy;
    [SerializeField]
    private List<Transform> myWaypoints;
    private EnemyPool _enemyPool;


    protected override void Start()
    {
        _enemyPool = FindObjectOfType<EnemyPool>();
        TileInfo.enemyCounter++;
        base.Start();
    }

    public override void Despawn()
    {
        myEnemy.gameObject.SetActive(false);
        myEnemy.waypoints = null;
        myEnemy = null;
    }

    public override void Spawn()
    {
        myEnemy = _enemyPool.GetEnemy();
        myEnemy.transform.position = transform.position;
        myEnemy.waypoints = myWaypoints;
        myEnemy.myTile = TileInfo;
        myEnemy.gameObject.SetActive(true);
        TileInfo.enemyCounter += 1;
    }
    
}
