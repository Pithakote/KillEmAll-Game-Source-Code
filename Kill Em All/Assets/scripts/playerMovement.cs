using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
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
        Vector2 moveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector2 moveVelocity2 = moveVector.normalized * speed;
       
        // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveVelocity2 * Time.fixedDeltaTime);
        Vector3 lookVector = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"), 5000);
        if(lookVector.x != 0 && lookVector.y != 0)
        transform.rotation = Quaternion.LookRotation(lookVector, Vector3.back);
        
        // transform.LookAt(transform.position.toVector2() + lookVector);

    }
}
