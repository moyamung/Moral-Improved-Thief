using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        ControlbyMap(player.transform.position);
    }

    void ControlbyMap(Vector3 playerPosition)
    {
        transform.position = new Vector3(Mathf.FloorToInt((playerPosition.x + 12.5f) / 25) * 25, 0f, -15f);
    }
}
