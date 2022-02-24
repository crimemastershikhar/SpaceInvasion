using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Refrence to our game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGo;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitileGO;
    public GameObject ShootButton; 

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }
    GameManagerState GMState;
    private void Start()
    {
        GMState = GameManagerState.Opening; 
    }
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                playButton.SetActive(true);
                GameOverGo.SetActive(false); 
                GameTitileGO.SetActive(true); 
                break;

            case GameManagerState.GamePlay:
                playButton.SetActive(false);
                GameTitileGO.SetActive(false);  
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter(); 
                ShootButton.SetActive(true); 
                break;

            case GameManagerState.GameOver:
                GameOverGo.SetActive(true);
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner(); 
                Invoke("ChangeToOpeningState", 4f);
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                ShootButton.SetActive(false); 
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
