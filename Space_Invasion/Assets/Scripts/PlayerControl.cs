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
    public Text LivesUIText; //Refering to live UI text
    const int MaxLives = 3; //max player per lives
    int Lives; //curr player lives


    public void Init()
    {
        Lives = MaxLives;
        LivesUIText.text = Lives.ToString();// Update the lives UI Text
        gameObject.SetActive(true); //Set player game object to active
        transform.position = new Vector2(0, 0);//Reset the pos to centre
    }
    private void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom point corner of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //top right point corner of screen
        max.x = max.x - 0.225f; //subtracting player ship half width  
        min.x = min.x + 0.225f; //add player ship half width
        max.y = max.y - 0.285f; //subtracting player ship half height  
        min.y = min.y + 0.285f; //add player ship half height
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //fire bullet
        {
            gameObject.GetComponent<AudioSource>().Play();
            //Instantiate and start first bullet position
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position;
            //Instantiate and start second bullet position
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
        Vector2 pos = transform.position; //find the position
        pos += direction * speed * Time.deltaTime; //calculate position

        //making sure that playe pos is not outside of screen
/*                pos.x = Mathf.Clamp(pos.x, min.x, max.x);
                pos.y = Mathf.Clamp(pos.y, min.y, max.y);*/
        transform.position = pos;//update player position
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            //            PlayExplosion();
            PlayPlayerExplosion();
            Lives--;//Subtract one live
            LivesUIText.text = Lives.ToString(); //Update lives UI Text
            if(Lives == 0) // If player lives is 0
            {
                //changing game manager stat to gameoverstate
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false); //Hide instead of destroy  
            }
        }
    }
/*    void PlayExplosion() //Instantiate explosion effect
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position; //Set position of explosion
    }*/
    void PlayPlayerExplosion()
    {
        GameObject explosionplayer = (GameObject)Instantiate(ExplosionPlayerGO);
        explosionplayer.transform.position = transform.position;
    }
}
