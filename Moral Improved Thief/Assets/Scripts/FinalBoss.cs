using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LineRenderer laser;
    public List<GameObject> servers;
    float radius = 10f;
    (int, int)[] laserPos = { (0, 1), (0, 2), (0, 3), (0, 4), (1, 2), (1, 3), (1, 4), (2, 3), (2, 4), (3, 4) };
    (int, int) nowLaserPos;
    void Start()
    {
        servers = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            servers.Add(transform.GetChild(i).gameObject);
            float angle = 2f * Mathf.PI * i / 5f;
            servers[i].transform.localPosition = new Vector3(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle), 0f);
        }
        InvokeRepeating("Laser", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Vector3 dir = servers[nowLaserPos.Item2].transform.position - servers[nowLaserPos.Item1].transform.position;
        if (Physics.Raycast(servers[nowLaserPos.Item1].transform.position, dir.normalized, out hitInfo, dir.magnitude))
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                //hit;
                hitInfo.collider.GetComponent<PlayerController>().OnHit(10f);
            }
        }
        int cnt = 0;
        foreach (GameObject server in servers)
        {
            if (server.GetComponent<Enemy>().isDead == true)
            {
                cnt++;
            }
        }
        if (cnt == 5) Dead();
    }

    void Laser()
    {
        int r = UnityEngine.Random.Range(0, 10);
        nowLaserPos = laserPos[r];
        laser.SetPosition(0, servers[nowLaserPos.Item1].transform.position);
        laser.SetPosition(1, servers[nowLaserPos.Item2].transform.position);
    }

    void Dead()
    {
        SceneManager.LoadScene("LastEndingSuccess");
    }
}
