using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.Save(gm.nowstage, GameManager.GameState.Open);
        if (gm.nowstage != 3) SceneManager.LoadScene("Lobby");
    }
    
    public void NO()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.Save(gm.nowstage, GameManager.GameState.Unopen);
        if (gm.nowstage != 3) SceneManager.LoadScene("Lobby");
    }
}
