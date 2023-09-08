using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectAtMouseClickLocation : MonoBehaviour
{
    public SpawnGameObjectAtMouseClickLocation spawnGameObjectAtMouseClickLocation;
    //this class will spawn a game object on any other game object in the scene at the point that is clicked with a mouse
    //you may choose to debug log the string results, or feel free to output information about the click or raycast if needed

    public string spawnObjectAtClickLocation(GameObject objectToSpawn, Camera mainCamera, Ray ray, RaycastHit hit)
    {
        string results = "";

        //if it hits a game object within 100 of the camera, spawn the game object prefab at that point.
        // you can use math.infinity as the range if needed.
        if (Physics.Raycast(ray, out hit, 100))
        {
            //output any results you want here...
            //example you could debug log the name of the object hit and the point where it was hit at
            results = "Object spawned onto " + hit.transform.name + " at point " + hit.point.ToString() + " for a distance of " + hit.distance.ToString();

            //spawn the game object
            var obj = GameObject.Instantiate(objectToSpawn);
            //place it in the correct location
            obj.transform.position = hit.point;
            //rotate to look at camera
            obj.transform.LookAt(mainCamera.transform);
        }

        return results;
    }
}
