using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        groundedPlayer = true;
    }

    void Update()
    {
        Vector3 transverse = new Vector3();
        float distance = playerSpeed * Time.deltaTime;
        float sides = Input.GetAxis("Horizontal") * distance;
        float forward = Input.GetAxis("Vertical") * distance;
        float vertical = Mathf.Sqrt(Input.GetAxis("Jump") * jumpHeight * -3.0f * gravityValue);
        transverse.x = sides;
        transverse.y = vertical;
        transverse.z = forward;
        gameObject.transform.Translate(transverse, Space.Self);
    }
}
