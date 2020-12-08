using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EnemyController
{
    private void Awake()
    {
        base.Awake();
        InvokeRepeating("Spawn", 0f, 20f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.isDead)
            {
                enemy.Spawn();
            }
        }
    }
}
