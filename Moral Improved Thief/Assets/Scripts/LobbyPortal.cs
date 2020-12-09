using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyPortal : MonoBehaviour
{
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UsePortal(GameObject Player)
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (number == 4)
        {
            if (gm.stage[1] == GameManager.GameState.Open && gm.stage[2] == GameManager.GameState.Open && gm.stage[3] == GameManager.GameState.Open)
            {
                SceneManager.LoadScene("LastMap");
            }
        }
        else 
        {
            if (gm.stage[number] == GameManager.GameState.Unseen)
            {
                SceneManager.LoadScene("First");
            }
        }
    }
}
