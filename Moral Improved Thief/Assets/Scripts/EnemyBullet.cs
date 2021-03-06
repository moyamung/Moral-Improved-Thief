using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 2f;
    public GameObject explosionPrefab;
    float bulletLife = 5f;
    void Start()
    {
        
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
            Instantiate (explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            other.GetComponent<PlayerController>().OnHit(5f);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Instantiate (explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(this.gameObject);
    }
}
