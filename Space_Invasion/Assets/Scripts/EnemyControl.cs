using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ExplosionGO;
    [SerializeField] private GameObject scoreUITextGo;
    private void Start()
    {
        speed = 2f;
        scoreUITextGo = GameObject.FindGameObjectWithTag("ScoreTextTag");   
    }
    private void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGo.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion() 
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position; 
    }
}
