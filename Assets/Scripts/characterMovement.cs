using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{

    public float speed;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    //private float crouchSpeed = 0.025f;
    public float turnSpeed = 90f;
    public float jumpHeight = 7f;
    private float rotateAmount;
    private bool isSprinting;

    private Rigidbody rb;
    public BoxCollider col;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(52.1f, 23.6f, 23.28f);
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        speed = walkSpeed;
        isSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {

    	//movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(direction * speed);
        rotateAmount = turnSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.A)) 
        {
            transform.Rotate(0, -rotateAmount, 0);
            //direction.x = 1;
          //  Debug.Log("Pressed A. I move left!");
        }
        if(Input.GetKey(KeyCode.D))
        {
          //  Debug.Log("Pressed D. I move right!");
          //  direction.x = -1;
            transform.Rotate(0, rotateAmount, 0);
        }
        if(Input.GetKey(KeyCode.W)) 
        {
          //  Debug.Log("Pressed W. I move forward!");
            direction.z = 1;
        }
        if(Input.GetKey(KeyCode.S)) 
        {
         //   Debug.Log("Pressed S. I move back!");
            direction.z = -1;
        }

        transform.Translate(direction.normalized * Time.deltaTime * speed);


        //toggle jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
        }

        //toggle sprint
        if(Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == false)
        {
            speed = runSpeed;
            isSprinting = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && isSprinting == true)
        {
            speed = walkSpeed;
            isSprinting = false;
        }
    }

    private bool isGrounded()
    {
        return true;
    }
}
