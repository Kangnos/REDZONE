using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

 //   public Transform target;

 //   public float smoothSpeed = 0.125f;

 //   public Vector3 offset;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void FixedUpdate () {
 //       Vector3 desiredPosition = target.position + offset;
 //       Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

 //       transform.position = smoothedPosition;
 //       transform.LookAt(target);
	//}
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.

    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
