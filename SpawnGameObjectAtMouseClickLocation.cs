using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectAtMouseClickLocation : MonoBehaviour
{
    //this class will spawn a game object on any other game object in the scene at the point that is clicked with a mouse
    
    //in the inspector, set a prefab as the game object to spawn.
    public GameObject objectToSpawn;

    //in the inspector, set the camera variable
    public Camera cam;
    
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray in from the users screen (the camera) into the 3D scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            //if it hits a game object within 100 of the camera, spawn the game object prefab at that point.
            // you can use math.infinity as the range if needed.
            if (Physics.Raycast(ray, out hit, 100))
            {
                //debug log the name of the object hit and the point where it was hit at
                Debug.Log("I have hit " + hit.transform.name + " at point " + hit.point.ToString());

                //spawn the game object
                var obj = GameObject.Instantiate(objectToSpawn);
                //place it in the correct location
                obj.transform.position = hit.point;
                //rotate to look at camera
                obj.transform.LookAt(cam.transform);
            }
        }
    }
}
