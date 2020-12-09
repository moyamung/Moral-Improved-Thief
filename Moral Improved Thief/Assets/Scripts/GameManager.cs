using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GameState { Unseen, Open, Unopen};
    public GameState[] stage;
    public int nowstage;
    void Start()
    {
        stage = new GameState[4];
        DontDestroyOnLoad(this.gameObject);
        //nowstage = 0;
        stage[1] = GameState.Unseen;
        stage[2] = GameState.Unseen;
        stage[3] = GameState.Unseen;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(int _stage, GameState state)
    {
        stage[_stage] = state;
    }

    public void Reset()
    {
        nowstage = 0;
        stage[1] = GameState.Unseen;
        stage[2] = GameState.Unseen;
        stage[3] = GameState.Unseen;
    }
}
