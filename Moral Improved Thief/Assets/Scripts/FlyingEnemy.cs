using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // Start is called before the first frame update
    float stopDistance = 4f;
    public GameObject bulletPrefab;
    private float attackCoolDown = 1.5f;
    private bool attackAble;
    void Start()
    {
        speed = 2f;
        attackAble = true;
        maxHp = 10f;
        hp = maxHp;
        isDead = false;
        //Spawn();
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
        //base.Attack();
        if (!attackAble) return;
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bullet.transform.up = this.transform.forward;
        _ = StartCoroutine("AttackCool");
    }

    IEnumerator AttackCool()
    {
        attackAble = false;
        yield return new WaitForSeconds(attackCoolDown);
        attackAble = true;
    }
}
