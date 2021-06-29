using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //defining the camera and character contoller
    private Camera playerCam;

    private CharacterController controller;


    //tunable values for movement
    [SerializeField] private float speed = 5;

    [SerializeField] private float gravity = 1;

    [SerializeField] private float jumpHeight = 3;

    //storage data to calculate movement
    [SerializeField] private float yVel = 0;
    [SerializeField] private Vector3 velocity, direction;

    public bool onLadder = false;

    public bool mouseLock = true;


    //tunable values for sensitivity and clamping
    [SerializeField] private float sensitivityX, sensitivityY, clampAngle;

    //for calculating rotation
    private float rotationY;
    private float rotationX;
    private Vector3 Angles;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCam = transform.GetChild(0).gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    //process the movement then the look rotation
    void Update()
    {
        KeyboardMovement();
        MouseRotation();


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = true;
            yVel = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onLadder = false;
    }

    /// <summary>
    /// Detects Keyboard or axis input to calculate the movement.
    /// Calculates a velocity and applies it to the character controller/
    /// Applies gravity when in the air.
    /// </summary>
    private void KeyboardMovement() {
        direction = Vector3.zero;
        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Vertical");

        if (controller.isGrounded && !onLadder)
        {
            direction += transform.right * horizontal;
            direction += transform.forward * depth;
            velocity = direction * speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVel = 0;
                yVel = jumpHeight;
            }
        }
        else if (!onLadder)
        {
            yVel -= gravity;
        } else
        {
            velocity = Vector3.zero;
            if (depth != 0)
            {
                yVel = (jumpHeight / 2) * depth;
            } else
            {
                yVel = 0;
            }
        }

        velocity.y = yVel;
        controller.Move(velocity * Time.deltaTime);

    }

    /// <summary>
    /// Detects Mouse movement to update the rotation of the player.
    /// ClampAngle limits the up and down rotation.
    /// </summary>
    private void MouseRotation() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            mouseLock = !mouseLock;
        }

        if (mouseLock)
        {
            rotationY = Input.GetAxis("Mouse Y") * sensitivityX;
            rotationX = Input.GetAxis("Mouse X") * sensitivityY;
            if (rotationY > 0)
            {
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, -clampAngle, rotationY), Angles.y + rotationX, 0);
            }
            else
            {
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, clampAngle, -rotationY),
                Angles.y + rotationX, 0);
            }
            transform.localEulerAngles = Angles;
        }
    }
}
