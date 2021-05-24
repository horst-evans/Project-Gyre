using UnityEngine;

public class StickToSurface : MonoBehaviour
{
    //should be deeper than player
    public float depthCheckDistance = 3;
    public float objectHeight = 1;
    public bool isPlayer = false;

    private void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, depthCheckDistance, ~layerMask))
        {
            Debug.DrawLine(transform.position, Vector3.down * depthCheckDistance, Color.red);
            // if player is jumping, do not lock onto ship
            if (!isPlayer || Input.GetAxisRaw("Jump") == 0)
            {
                transform.position = new Vector3(hit.point.x, hit.point.y + objectHeight, hit.point.z);
            }
            //Debug.Log(transform.position.ToString());
        }
    }

}
