using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State { Idle, Patrol, Move, Attack };

    protected float hp;
    public float maxHp;
    protected float attack;
    protected float speed;
    [SerializeField] protected GameObject target;
    [SerializeField] protected State state;
    public bool isDead;
    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        Spawn();
    }

    public void Spawn()
    {
        state = State.Idle;
        hp = maxHp;
        isDead = false;
        transform.position = spawnPoint;
    }

    public void OnHit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }

    virtual public void Dead()
    {
        isDead = true;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void MoveTo(Vector3 x)
    {

    }

    virtual protected void Attack()
    {

    }

    virtual public void SetState(State _state)
    {
        state = _state;
    }

    virtual public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }
}
