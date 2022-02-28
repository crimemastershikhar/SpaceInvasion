using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector2 _direction; 
    private bool isReady; 
    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    public void SetDirection(Vector2 direction) 
    {
        _direction = direction.normalized;
        isReady = true;
    }
    private void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //Destroy bullet if goes out of bounds
            if((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag"))
        {
            Destroy(gameObject);
        }
    }
}
