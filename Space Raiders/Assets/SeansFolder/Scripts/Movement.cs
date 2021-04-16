using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;


    public float speed = 12f;

    public float gravity = -19.62f;

    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float SprintBoost = 2.5f;

    Vector3 velocity;
    
    private bool isGrounded;
   
    private bool isSprinting;

    //Camera bobbing Variables
    public Transform headTransform;
    public Transform cameraTransform;

    public float bobFrequency = 3f;
    public float bobHorizontalAmplitude = 0.1f;
    public float bobVerticalAmplitude = 0.1f;
    [Range(0, 1)] public float headBobSmoothing = 0.1f;

    public bool isWalking;
    private float walkingTime;
    private Vector3 targetCameraPosition;

 

    void Start()
    {
        controller.GetComponent<CharacterController>();
        isWalking = false;
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (move.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (!isGrounded)
        {
            isWalking = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = true;
            speed += SprintBoost;
            bobFrequency = 6;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
        {
            isSprinting = false;
            speed -= SprintBoost;
            bobFrequency = 3f;
        }


        //Camera Bobbing

        // Set time and offset to 0
        if (!isWalking)
        {
            walkingTime = 0;
        }
        else
        {
            walkingTime += Time.deltaTime;
        }

        targetCameraPosition = headTransform.position + CalculateHeadBobOffset(walkingTime);

        // interpolate position
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCameraPosition, headBobSmoothing);
        //snap to position if it's close enough
        if ((cameraTransform.position - targetCameraPosition).magnitude <= 0.001) cameraTransform.position = targetCameraPosition;

    }

    //CameraBobbing

    private Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontalOffset = 0;
        float verticalOffset = 0;
        Vector3 offset = Vector3.zero;

        if (t > 0)
        {
            // calculate offsets
            horizontalOffset = Mathf.Cos(t * bobFrequency) * bobHorizontalAmplitude;
            verticalOffset = Mathf.Sin(t * bobFrequency * 2) * bobVerticalAmplitude;

            // combine offsets relative to the heads position and calculate the cameras target position
            offset = headTransform.right * horizontalOffset + headTransform.up * verticalOffset;
        }
        return offset;
    }
}

