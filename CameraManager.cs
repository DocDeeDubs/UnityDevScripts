using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	//*********variable declaration***********************
	//using the inspector, assign the cameras you wish to have available.
	//*note: disable the camera component of all but the main one that you will start with
	public Camera[] cameras;
	//store the array index number of the current camera. this will be updated via script
    public int currentCamNum = 0;
	//---------------------------------------------------
	
	
	//********************************************************************
	//**** call one or both of these public methods from a button in your app***
	
	//this method will change to a specific camera in the array specified by the integer "cameraNum"
	public void changeCamera(int cameraNum)
    {
        currentCamNum = cameraNum;
        // setting this var mainly for debug to watch in editor
        currentCam = cameras[currentCamNum];
        toggleCameras();

    }
	//---------------------------------------------------
	
	//this method will toggle between all cameras in the array one after the next, starting over when it reaches the end of the array.
	public void toggleCamera()
	{
		//Debug.Log(cameras.Length);
		currentCamNum++;
		if(currentCamNum==cameras.Length){currentCamNum=0;}
		// setting this var mainly for debug to watch in editor
        currentCam = cameras[currentCamNum];
        toggleCameras();
	}
	//-----------------------------------------------------------
	//--------- end publicly accessible methods ---------------------
	//----------------------------------------------
	
	//this internal method handles the actual toggling of cameras on and off
	void toggleCameras()
	{
		//loop through the cams and disableall but the desired one
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == currentCamNum) ? true : false;
        }
	}
		
}
