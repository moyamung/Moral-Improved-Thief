using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float bulletspeed = 8f;
    public GameObject explosionPrefab;
    float bullettime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletspeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate (explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            other.GetComponent<Enemy>().OnHit(5f);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Instantiate (explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(bullettime);
        Destroy(this.gameObject);
    }
}
