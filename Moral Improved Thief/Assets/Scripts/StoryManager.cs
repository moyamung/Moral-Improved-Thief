using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StoryManager : MonoBehaviour
{
    public string path;
    public Text textUI;
    // Start is called before the first frame update
    void Start()
    {
        string currentPath = ".\\Assets\\Story Texts\\";
        currentPath += path;
        ReadText(currentPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadText(string path)
    {
        string text = File.ReadAllText(path);
        string[] texts = text.Split(new char[] { '\t' });
        foreach (string paragraph in texts)
        {
            Debug.Log(paragraph);
        }
    }
}
