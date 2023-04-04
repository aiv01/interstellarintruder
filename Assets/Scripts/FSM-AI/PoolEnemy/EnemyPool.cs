using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private List<EnemyAI> enemyPrefabs;
    private int level;
    private int poolSize = 10;
    private List<EnemyAI> pool = new List<EnemyAI>();

    private void Awake()
    {
        level = GameObject.Find("GameMgr").GetComponent<GameManager>().level;
    }
    private void Start()
    {
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
            CreateInstance();
    }

    private EnemyAI CreateInstance()
    {
        EnemyAI instance = Instantiate(enemyPrefabs[level-1],transform);
        pool.Add(instance);
        return instance;
    }

    public EnemyAI GetEnemy()
    {
        EnemyAI val = null;
        foreach (EnemyAI eneemy in pool)
            if (!eneemy.gameObject.activeSelf)
            {
                val = eneemy;
                break;
            }
        return val;
    }
}
