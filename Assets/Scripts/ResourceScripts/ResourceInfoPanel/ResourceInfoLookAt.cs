﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfoLookAt : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = _camera.transform.eulerAngles;
    }
}
