using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; 

    Queue<GameObject> avaialblePlanets = new Queue<GameObject>(); 
    private void Start()
    {//Adding planets to Queue
        avaialblePlanets.Enqueue(Planets[0]);
        avaialblePlanets.Enqueue(Planets[1]);
        avaialblePlanets.Enqueue(Planets[2]);
        InvokeRepeating("MovePlanetDown", 0, 20f); 
    }
    void MovePlanetDown()
    {
        EnqueuePlanets();
        if(avaialblePlanets.Count == 0)
            return;

            GameObject aPlanet = avaialblePlanets.Dequeue(); 
            aPlanet.GetComponent<Planet>().isMoving = true; 
    }
    void EnqueuePlanets() 
    {
        foreach(GameObject aPlanet in Planets)
        {
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving)) 
            {
                aPlanet.GetComponent<Planet>().ResetPosition();
                avaialblePlanets.Enqueue(aPlanet); 
            }
        }

    }
}
