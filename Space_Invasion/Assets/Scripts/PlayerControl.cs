using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject GameManagerGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02 ;
    public float speed;
    public GameObject ExplosionGO;
    public GameObject ExplosionPlayerGO;
    public Text LivesUIText; 
    const int MaxLives = 3; 
    int Lives; 

    public void Init()
    {
        Lives = MaxLives;
        LivesUIText.text = Lives.ToString();
        gameObject.SetActive(true); 
        transform.position = new Vector2(0, 0);
    }
    private void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 
        max.x = max.x - 0.225f;   
        min.x = min.x + 0.225f; 
        max.y = max.y - 0.285f;   
        min.y = min.y + 0.285f; 
    }

    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)) 
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position;
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = BulletPosition02.transform.position;
        }
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(x, y).normalized;

            Move(direction);
        }
        void Move(Vector2 direction)
        {
            Vector2 pos = transform.position; 
            pos += direction * speed * Time.deltaTime; 
            transform.position = pos;
        }
        private void OnTriggerEnter2D (Collider2D col)
        {
            if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
            {
                PlayPlayerExplosion();
                Lives--;
                LivesUIText.text = Lives.ToString(); 
                if (Lives == 0) 
                {
                    GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                    gameObject.SetActive(false); 
                }
            }
        }
        void PlayPlayerExplosion()
        {
            GameObject explosionplayer = (GameObject)Instantiate(ExplosionPlayerGO);
            explosionplayer.transform.position = transform.position;
        }
    }

