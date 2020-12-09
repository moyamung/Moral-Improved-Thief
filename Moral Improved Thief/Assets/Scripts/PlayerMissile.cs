using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
   // Start is called before the first frame update
    float bulletspeed = 3f;
    public GameObject explosionPrefab;
    float bullettime = 1f;
    void Start()
    {
        bullettime = Random.Range(1.0f,1.5f);
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
            other.GetComponent<Enemy>().OnHit(10f);
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
