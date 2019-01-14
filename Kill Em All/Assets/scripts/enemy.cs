using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public int health;

    public GameObject deathParticle;
	// Use this for initialization
	void Start () {
		
	}
    public void takesDmg(int damage)
    {
        health -= damage;
    }
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
