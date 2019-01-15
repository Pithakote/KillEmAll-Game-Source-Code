using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemy : MonoBehaviour {
    public int health;
    
    public GameObject deathParticle;
    // Use this for initialization
    public AudioClip music;
    public AudioSource damageSound;

    void Start () {

        damageSound.clip = music;
    }
    public void takesDmg(int damage)
    {
        health -= damage;
        damageSound.Play();
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
