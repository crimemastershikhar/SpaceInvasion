using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Refrence to our game objects
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject playerShip;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject GameOverGo;
    [SerializeField] private GameObject scoreUITextGO;
    [SerializeField] private GameObject TimeCounterGO;
    [SerializeField] private GameObject GameTitileGO;
    [SerializeField] private GameObject ShootButton; 

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
