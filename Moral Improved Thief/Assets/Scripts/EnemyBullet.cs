using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 2f;
    float bulletLife = 3f;
    void Start()
    {
        StartCoroutine("BulletLife");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OnHit(5f);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(this.gameObject);
    }
}
