using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private EnemyAI enemyToSpawn;
    [SerializeField]
    private List<Transform> myWaypoints;
    private EnemyPool _enemyPool;
    private EnemyAI myEnemy;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        _enemyPool = FindObjectOfType<EnemyPool>();
        TileInfo.enemyCounter++;
        base.Init();
    }
    public override void Despawn()
    {
        myEnemy.gameObject.SetActive(false);
        myEnemy.Agent.Warp(_enemyPool.transform.position);
        myEnemy.transform.SetParent(_enemyPool.transform, true);
        myEnemy.waypoints = null;
        myEnemy = null;
    }

    public override void Spawn()
    {
        myEnemy = _enemyPool.GetEnemy();
        myEnemy.Agent.Warp(transform.position);
        myEnemy.transform.SetParent(transform, true);
        myEnemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        myEnemy.waypoints = myWaypoints;
        myEnemy.myTile = TileInfo;
        myEnemy.gameObject.SetActive(true);
        TileInfo.enemyCounter += 1;
    }
    
}
