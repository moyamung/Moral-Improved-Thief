using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [SerializeField] LineRenderer laser;
    [SerializeField] float freq;
    float theta;
    bool rightLaser;
    bool leftLaser;
    IEnumerator enumerator;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
        laser = transform.Find("Laser").GetComponent<LineRenderer>();
        freq = 0.04f;
        rightLaser = true;
        leftLaser = true;
    }

    // Update is called once per frame
    void Update()
    {
        Laser(theta);
        LaserHit(theta);
        theta += 2f * Mathf.PI * freq * Time.deltaTime;
        if (theta > 2f * Mathf.PI) theta -= 2f * Mathf.PI;
    }

    void Laser(float theta)
    {
        //Debug.Log(theta);
        Vector3 dir = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0f);
        RaycastHit hitInfo;
        int mask = 1 << 9;
        //Debug.DrawRay(transform.position, dir * 100f, Color.red);
        if (Physics.Raycast(transform.position, dir, out hitInfo, 100f, mask))
        {
            //Debug.Log(hitInfo.collider.gameObject.name);
            if (rightLaser == false)
            {
                laser.SetPosition(0, transform.position);
            }
            else
            {
                laser.SetPosition(0, hitInfo.point);
            }
        }
        if (Physics.Raycast(transform.position, -dir, out hitInfo, 100f, mask))
        {
            if (leftLaser == false)
            {
                laser.SetPosition(1, transform.position);
            }
            else
            {
                laser.SetPosition(1, hitInfo.point);
            }
        }
    }

    void LaserHit(float theta)
    {
        Vector3 dir = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0f);
        RaycastHit hitInfo;
        //int mask = 1 << 9;
        //Debug.DrawRay(transform.position, dir * 100f, Color.red);
        if (rightLaser == true)
        {
            if (Physics.Raycast(transform.position, dir, out hitInfo, 100f))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    //hit;
                }
            }
        }
        if (leftLaser == true)
        {
            if (Physics.Raycast(transform.position, -dir, out hitInfo, 100f))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    //hit;
                }
            }
        }
    }

    public void LaserOff(int x)
    {
        if (x == 0)
        {
            //left
            enumerator = LeftLaserOff();
            StartCoroutine(enumerator);
        }
        else
        {
            enumerator = RightLaserOff();
            StartCoroutine(enumerator);
        }
    }

    IEnumerator RightLaserOff()
    {
        rightLaser = false;
        yield return new WaitForSeconds(4f);
        rightLaser = true;
    }

    IEnumerator LeftLaserOff()
    {
        leftLaser = false;
        yield return new WaitForSeconds(4f);
        leftLaser = true;
    }
}
