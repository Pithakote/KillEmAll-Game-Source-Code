﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileIcon : MonoBehaviour {
    public int lifetime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
