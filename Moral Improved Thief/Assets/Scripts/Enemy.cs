using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected float hp;
    protected float attack;
    protected float speed;

    protected GameObject target;

    public enum State { Idle, Patrol, Move, Attack};
    protected State state;

    void Start()
    {
        state = State.Idle;
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
