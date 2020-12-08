using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationCurve ac;
    public float duration;
    public float bias;
    float time;
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().color = Color.Lerp(Color.clear, Color.white, ac.Evaluate(time / duration - bias));
        time += Time.deltaTime;
    }

    public void Play()
    {
        SceneManager.LoadScene("StoryTest");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
