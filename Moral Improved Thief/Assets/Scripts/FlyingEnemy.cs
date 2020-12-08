using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // Start is called before the first frame update
    float stopDistance = 2f;
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Attack)
        {
            if ((target.transform.position - this.transform.position).magnitude < stopDistance)
            {
                Attack();
            }
            else
            {
                MoveTo(target.transform.position);
            }
        }
    }

    protected override void MoveTo(Vector3 x)
    {
        //this.transform.Translate((x - this.transform.position).normalized * speed * Time.deltaTime);
        this.transform.forward = (x - this.transform.position).normalized;
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        base.Attack();
    }
}
