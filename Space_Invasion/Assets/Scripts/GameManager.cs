using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Refrence to our game objects
    public GameObject playButton;
    public GameObject playerShip;
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
                break;
            case GameManagerState.GamePlay:
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControl>().Init();
                break;
            case GameManagerState.GameOver:
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

}
