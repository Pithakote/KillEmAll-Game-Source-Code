using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class playerMovement : MonoBehaviour {


    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject deathParticle;
    public int health = 3;
    public TMP_Text healthtext;
    //public GameObject healthText;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    public void takeDmg(int damage)
    {
        health -= damage;
    }
	// Update is called once per frame
	void Update () {
        
        healthtext.text = "Health:" + health;
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            SceneManager.LoadScene("gameOver");
            Destroy(gameObject);
            
        }
   

            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = move.normalized * speed;
       
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
