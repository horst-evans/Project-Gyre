using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchControl : MonoBehaviour
{
    public Collider playerCol;
    public GameObject controlEndpoint;
    public UnityEvent OnControlStarted;
    public UnityEvent OnControlEnded;

    private bool isInControl;

    private void Start()
    {
        isInControl = false;
    }

    private void Update()
    {
        if (isInControl && Input.GetButtonDown("Jump"))
        {
            OnControlEnded.Invoke();
            isInControl = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == playerCol)
        {
            if (!isInControl)
            {
                OnControlStarted.Invoke();
                isInControl = true;
            }
        }
    }

    public void SpawnPlayerAtEndpoint(GameObject pl)
    {
        pl.transform.position = controlEndpoint.transform.position;
        pl.SetActive(true);
    }

}
