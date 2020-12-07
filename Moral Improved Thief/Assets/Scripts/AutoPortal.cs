using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPortal : PortalController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsConnected) return;
            other.transform.position = new Vector3(other.transform.position.x, _connectedPortal.gameObject.transform.position.y, other.transform.position.z);
        }
    }

}
