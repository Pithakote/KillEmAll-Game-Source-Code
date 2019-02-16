using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossController : MonoBehaviour {
    GameObject boss;
    public Transform miniBoss1;
    public Transform miniBoss2;
    // Use this for initialization
    void Start () {
        boss = GameObject.FindGameObjectWithTag("boss").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
       
	}
}
