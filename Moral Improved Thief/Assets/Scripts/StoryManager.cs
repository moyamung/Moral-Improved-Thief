using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StoryManager : MonoBehaviour
{
    public string path;
    string currentPath;
    public Text textUI;
    public List<string> texts;
    IEnumerator<string> it;
    public string nextScene;
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        currentPath = ".\\Assets\\Story Texts\\";
        currentPath += path;
        it = ReadText(currentPath);
        it.MoveNext();
        textUI.text = it.Current;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNext()
    {
        if (!it.MoveNext())
        {
            //finish
            if (isEnd)
            {
                GameManager gm = FindObjectOfType<GameManager>();
                gm.Reset();
            }
            SceneManager.LoadScene(nextScene);
        }
        //it.MoveNext();
        textUI.text = it.Current;
    }

    public void OnSkip()
    {
        if (isEnd)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.Reset();
        }
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator<string> ReadText(string path)
    {
        string text = File.ReadAllText(path);
        string[] texts = text.Split(new char[] { '\t' });
        //List<string> _texts = new List<string>();
        foreach (string paragraph in texts)
        {
            //paragraph.Replace("\t\n", "");
            string _paragraph = paragraph.Substring(2);
            //_texts.Add(_paragraph);
            yield return _paragraph;
        }
    }
}
