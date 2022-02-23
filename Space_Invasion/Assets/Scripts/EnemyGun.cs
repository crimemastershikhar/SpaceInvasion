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

    void FireEnemyBullet() 
    {
        GameObject playerShip = GameObject.Find("PlayerGO");
        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - bullet.transform.position; 
            bullet.GetComponent<EnemyBullet>().SetDirection(direction); 
        }
    }   

}
