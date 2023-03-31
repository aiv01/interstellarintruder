using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon.Projectile;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GranadierStats _stats;
    [SerializeField]
    private EnemyAI enemyPrefab;

    private int poolSize = 10;
    private List<EnemyAI> pool = new List<EnemyAI>();

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
            CreateInstance();
    }

    private EnemyAI CreateInstance()
    {
        EnemyAI instance = Instantiate<EnemyAI>(enemyPrefab);
        instance.gameObject.SetActive(false);
        instance.transform.SetParent(transform);
        pool.Add(instance);
        return instance;
    }

    public EnemyAI GetBullet()
    {
        EnemyAI val = null;
        foreach (EnemyAI eneemy in pool)
            if (!eneemy.gameObject.activeSelf)
            {
                val = eneemy;
                break;
            }
        if (val == null)
            val = CreateInstance();
        val.gameObject.SetActive(true);
        return val;
    }
}
