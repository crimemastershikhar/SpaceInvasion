using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; //Array of PlanetsGO prefab

    Queue<GameObject> avaialblePlanets = new Queue<GameObject>(); //Queue to hold game objects
    private void Start()
    {//Adding planets to Queue
        avaialblePlanets.Enqueue(Planets[0]);
        avaialblePlanets.Enqueue(Planets[1]);
        avaialblePlanets.Enqueue(Planets[2]);
        InvokeRepeating("MovePlanetDown", 0, 20f); //Call move planet down every 20 seconds
    }
    void MovePlanetDown()
    {
        EnqueuePlanets();
        if(avaialblePlanets.Count == 0)
            return;

            GameObject aPlanet = avaialblePlanets.Dequeue(); //Get a planet from queue
            aPlanet.GetComponent<Planet>().isMoving = true; //Set planet flag to true
    }
    void EnqueuePlanets() //func to enqueu planets that are below screen and not moving
    {
        foreach(GameObject aPlanet in Planets)
        {
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving)) //if planet is below screen and not moving
            {
                aPlanet.GetComponent<Planet>().ResetPosition();
                avaialblePlanets.Enqueue(aPlanet); //Enqueu the planet
            }
        }

    }
}
