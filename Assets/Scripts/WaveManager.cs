﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    public float scale;

    private void Awake()
    {
        if(instance == null)
        { 
            instance = this;
        }
        else if(instance != this)
        {
            Debug.Log("instance already exists, destroying object");
            Destroy(this);
        }
    }

    private void Start()
    {
        scale = transform.localScale.x;
    }

    private void Update()
    {
        offset += speed * Time.deltaTime;
    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }
}
