using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeZoneText : MonoBehaviour
{
    public Text zoneText;
    public string zoneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            zoneText.text = zoneName;
        }
    }
}
