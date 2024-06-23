using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credit for for the code within this script that makes the camera rotation move with the mouse goes to https://www.youtube.com/watch?v=W70n_bXp7Dc&ab_channel=Unity3DSchool

public class CameraScript : MonoBehaviour
{
    public Transform target;
    float rotationX = 0f;
    float rotationY = -90f;

    public float sensitivity = 15f;

    private Vector3 heading;

    //)

    void Update() {
        rotationY += (Input.GetAxis("Mouse X") * sensitivity);
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
        

        
        
        
        
        
        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        //ratates around it twenty degrees per second. we need to rotate the thing to a specdific degreess around the object. 
       // transform.LookAt(new Vector3(target.position.x, transform.position.y, transform.position.z)); 
        //from https://stackoverflow.com/questions/56000766/transform-lookat-but-only-in-x-axis
        
        
        //so the rotation is fine, we actually just need to position the thing behind the object. i say we do rotate around / position of the camera is the local position of the walk thing minus 2

        //heading = target.position - transform.position;
       // Quaternion rotation = Quaternion.LookRotation(heading, Vector3.up);
        //transform.rotation = rotation;
        //target actually needs to be a vector from the camera to the player target. 

    }
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0f);


    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
