using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffect : MonoBehaviour
{
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color underwaterColor;
    [SerializeField]
    private float fogDensity;

    private float waterHeight;
    private bool isUnderwater;

    // Use this for initialization
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
        fogDensity = 0.005f;
        waterHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //waterHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if ((transform.position.y < waterHeight) != isUnderwater)
        {
            isUnderwater = transform.position.y < waterHeight;
            if (isUnderwater) SetUnderwater();
            if (!isUnderwater) SetNormal();
        }
    }

    void SetNormal()
    {
        RenderSettings.fog = false;
        //RenderSettings.fogColor = normalColor;
        //RenderSettings.fogDensity = 0.01f;
    }

    void SetUnderwater()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = fogDensity;
    }
}
