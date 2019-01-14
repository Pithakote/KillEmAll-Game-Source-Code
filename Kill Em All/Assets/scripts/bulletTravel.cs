﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTravel : MonoBehaviour {


    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask solid;
    public GameObject destroyParticle;

    public int dmg;
    // Use this for initialization
    void Start () {
        Invoke("bulletDestroy", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
 

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy dead");
                hitInfo.collider.GetComponent<enemy>().takesDmg(dmg);
            }
            bulletDestroy();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void bulletDestroy()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
