using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02 ;
    public float speed;

    private void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom point corner of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //top right point corner of screen
        max.x = max.x - 0.225f; //subtracting player ship half width  
        min.x = min.x + 0.225f; //add player ship half width
        max.y = max.y - 0.285f; //subtracting player ship half height  
        min.y = min.y + 0.285f; //add player ship half height
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //fire bullet
        {
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
        /*        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
                pos.y = Mathf.Clamp(pos.y, min.y, max.y);*/
        transform.position = pos;//update player position
    }
}
