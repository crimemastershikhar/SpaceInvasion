using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    private void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    void FireEnemyBullet() //reffrence to player's ship
    {
        GameObject playerShip = GameObject.Find("PlayerGO");
        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - bullet.transform.position; //compute bullet's dorection towards player ship
            bullet.GetComponent<EnemyBullet>().SetDirection(direction); //Set bullet's direction
        }
    }   

}
