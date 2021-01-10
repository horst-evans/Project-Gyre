using UnityEngine;

public class TriggerStick : MonoBehaviour
{
    //should be deeper than player
    public float depthCheckDistance = 3;
    public float playerHeight = 1;

    private void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, depthCheckDistance, ~layerMask))
        {
            Debug.DrawLine(transform.position, Vector3.down * depthCheckDistance, Color.red);
            //Debug.Log("Adjusting player pos");
            // if player is jumping, do not lock onto ship
            if (Input.GetAxisRaw("Jump") == 0)
            {
                transform.position = new Vector3(hit.point.x, hit.point.y + playerHeight, hit.point.z);
            }
            //Debug.Log(transform.position.ToString());
        }
    }

}
