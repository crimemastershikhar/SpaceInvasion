using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        Vector2 position = transform.position; //Get pos of star
        position = new Vector2(position.x, position.y - speed * Time.deltaTime); //compute new pos
        transform.position = position; //update star pos
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if star gies out from bottom > pos star on top edge
        //randpm spawn b/w left and right of screen
        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }

}
