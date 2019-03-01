using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpov : MonoBehaviour
{

	private const float Y_ANGLE_MIN = 0.0f;
	private const float Y_ANGLE_MAX = 30.0f;

	public Transform lookAt;
	public Transform camTransform;

	private Camera cam;

	//set camera distance and angle from player
	private float distance = 15.0f; //between player and camera
	private float currentX = 0.0f;
	private float currentY = 3.0f;
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

   void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
    	Vector3 direction = new Vector3(0, 0, -distance);
    	Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
    	camTransform.position = lookAt.position + rotation * direction;
    	camTransform.LookAt(lookAt.position);
    }

 
}
