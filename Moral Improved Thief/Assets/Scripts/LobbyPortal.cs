using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyPortal : MonoBehaviour
{
    public int number;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm.nowstage < number) this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UsePortal(GameObject Player)
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (number == 3)
        {
            gm.nowstage = 4;
            SceneManager.LoadScene("LastMap");
        }
        else if (number == 2)
        {
            gm.nowstage = 3;
            SceneManager.LoadScene("ThirdMap");
        }
        else if (number == 1)
        {
            gm.nowstage = 2;
            SceneManager.LoadScene("SecondMap");
        }
        else if (number == 0)
        {
            gm.nowstage = 1;
            SceneManager.LoadScene("FirstMap");
        }
    }
}
