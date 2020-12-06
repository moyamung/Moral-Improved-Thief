using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    MiniMap minimap;
    int index;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMinimap(MiniMap _minimap)
    {
        minimap = _minimap;
    }

    public void SetIndex(int idx)
    {
        index = idx;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            minimap.SetPlayerPos(index);
        }
    }
}
