using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeZoneText : MonoBehaviour
{
    public Text zoneText;
    public string zoneName;
    public bool isSubZone;
    public string parentName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            zoneText.text = zoneName;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isSubZone && other.gameObject.name == "Player")
        {
            zoneText.text = parentName;
        }

    }
}
