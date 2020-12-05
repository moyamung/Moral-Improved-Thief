using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Enemy> enemyList;
    // Start is called before the first frame update
    void Awake()
    {
        enemyList = new List<Enemy>();
        Transform[] enemyChild = GetComponentsInChildren<Transform>();
        foreach(Transform enemy in enemyChild)
        {
            if (!enemy.GetComponent<Enemy>()) continue;
            enemyList.Add(enemy.GetComponent<Enemy>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(Enemy enemy in enemyList)
            {
                enemy.SetTarget(other.gameObject);
                enemy.SetState(Enemy.State.Attack);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.SetState(Enemy.State.Idle);
                enemy.SetTarget(null);
            }
        }
    }
}
