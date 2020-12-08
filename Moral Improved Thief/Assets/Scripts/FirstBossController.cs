using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : MonoBehaviour
{
    enum State {Left, Right};
    [SerializeField] State state;
    [SerializeField] FirstBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteraction()
    {
        //Debug.LogError("hello");
        if (state == State.Left)
        {
            boss.LaserOff(0);
        }
        else
        {
            boss.LaserOff(1);
        }
    }
}
