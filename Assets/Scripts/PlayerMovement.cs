using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //mouse movement
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            foreach(Camera cam in Camera.allCameras)
            {
                //rotate camera but not player for vertical offset
                cam.transform.Rotate(-v, 0, 0);
            }
            //rotate camera and player for horizontal offset
            transform.Rotate(0, h, 0);
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //player move
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float angle = Camera.main.transform.rotation.eulerAngles.y;
        Vector3 rMove = Quaternion.AngleAxis(angle, Vector3.up) * move;
        controller.Move(rMove * Time.deltaTime * playerSpeed);
        // Changes the height position of the player...
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // debug stuff

    // if movement would take player closer to center of collided object, dont move
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("HIT: " + hit.collider.name);
    }

}
