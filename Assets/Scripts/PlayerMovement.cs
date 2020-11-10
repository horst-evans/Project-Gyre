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
        transform.rotation = Quaternion.Euler(0, 0, 0);
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            foreach(Camera cam in Camera.allCameras)
            {
                cam.transform.Rotate(-v, h, 0);
            }
            //transform.Rotate(-v, h, 0);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float angle = Camera.main.transform.rotation.eulerAngles.y;
        Vector3 rMove = Quaternion.AngleAxis(angle, Vector3.up) * move;
        controller.Move(rMove * Time.deltaTime * playerSpeed);
        //transform.rotation = Camera.main.transform.rotation;

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
