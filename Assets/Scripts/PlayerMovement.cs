using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpForce = 1.0f;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float gravity = -9.81f;
    public float distanceToCheck = 0.5f;

    private bool isGrounded = false;
    private float velocity;

    private void Start()
    {
        
    }

    void Update()
    {
        //mouse movement
        float cam_h = horizontalSpeed * Input.GetAxis("Mouse X");
        float cam_v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            foreach(Camera cam in Camera.allCameras)
            {
                //rotate camera but not player for vertical offset
                cam.transform.Rotate(-cam_v, 0, 0);
            }
            //rotate camera and player for horizontal offset
            transform.Rotate(0, cam_h, 0);
        }

        //player move
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float angle = Camera.main.transform.rotation.eulerAngles.y;
        Vector3 rMove = Quaternion.AngleAxis(angle, Vector3.up) * move;
        //transform.Translate(playerSpeed * Time.deltaTime * transform.forward * Input.GetAxis("Vertical"));
        Vector3 trans = playerSpeed * Time.deltaTime * rMove;
        transform.Translate(trans,Space.World);

        // jump + gravity
        if (!isGrounded) velocity += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = jumpForce;
            //rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            // detach from ship (don't want to sway if jumping to a non-ship obj)
            transform.parent = null;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime, Space.Self);

        // ground check
        if (Physics.Raycast(transform.position, -transform.up, distanceToCheck))
        {
            isGrounded = true;
            velocity = 0;
        }
        else
        {
            isGrounded = false;
            transform.parent = null;
        }
    }

    // Set As Child
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("HIT: " + collision.collider.name);
        // 9 == ship
        if (collision.gameObject.layer == 9)
        {
            float y_diff = transform.rotation.eulerAngles.y;
            transform.parent = collision.transform.root;
            transform.up = transform.parent.up;
            transform.Rotate(transform.up, y_diff);
        }
        else
        {
            transform.parent = null;
        }
    }

}
