using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [SerializeField] LineRenderer laser;
    [SerializeField] float freq;
    float theta;
    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
        laser = transform.Find("Laser").GetComponent<LineRenderer>();
        freq = 0.04f;
    }

    // Update is called once per frame
    void Update()
    {
        Laser(theta);
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
            laser.SetPosition(0, hitInfo.point);
        }
        if (Physics.Raycast(transform.position, -dir, out hitInfo, 100f, mask))
        {
            laser.SetPosition(1, hitInfo.point);
        }
    }
}
