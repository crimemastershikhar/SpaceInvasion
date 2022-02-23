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
    public GameObject ShootButton; // FOR ANDROID

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
                playButton.SetActive(true);//Set Play button visible
                GameOverGo.SetActive(false); //Hiding gameover screen
                GameTitileGO.SetActive(true); //DIsplay game title
                break;

            case GameManagerState.GamePlay:
                playButton.SetActive(false);
                GameTitileGO.SetActive(false); //Hide Game title 
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter(); //Start the time counter
                ShootButton.SetActive(true); // FOR ANDROID
                break;

            case GameManagerState.GameOver:
                GameOverGo.SetActive(true);
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner(); //stop enemy spawner
                Invoke("ChangeToOpeningState", 4f);//change game managr state to openign state after 4 seconds
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter(); //Stop time counter
                ShootButton.SetActive(false); // FOR ANDROID
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)//Funct to set game manager state
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
