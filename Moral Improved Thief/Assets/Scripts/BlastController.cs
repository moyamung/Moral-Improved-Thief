using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour
{
    public float life = 1.0f;
    public Vector3 size = new Vector3(5.0f, 5.0f, 5.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0.0f) {
            Destroy(gameObject);
        }
        life -= Time.deltaTime * 2.0f;
        transform.localScale = size * life * life;
    }
}
