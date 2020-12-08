using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Transform startPos;
    Transform endPos;
    Transform elevator;
    public float period;
    //bool goingUp;
    public AnimationCurve ac;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.Find("StartPos");
        endPos = transform.Find("EndPos");
        elevator = transform.Find("Elevator");
        elevator.position = endPos.position;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elevator.position = Vector3.Lerp(startPos.position, endPos.position, ac.Evaluate(time / period));
        time += Time.deltaTime;
        if (time > period) time -= period;

    }
}
