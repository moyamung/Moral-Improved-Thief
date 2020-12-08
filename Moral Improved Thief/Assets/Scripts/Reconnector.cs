using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reconnector : MonoBehaviour
{
    public bool activate = false;
    MapGenerator mapGen;
    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteraction()
    {
        mapGen.Reconnect();
    }

    public void Activate(MapGenerator _mapGen)
    {
        activate = true;
        this.gameObject.SetActive(true);
        mapGen = _mapGen;
    }
}
