﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }
}
