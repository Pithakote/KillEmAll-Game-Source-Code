using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
public class playerMovement : MonoBehaviour {

    public GameObject playerShield;
    public GameObject player;
    public GameObject sceneManager;
    public GameObject bullets;
   // public bool isShieldOn;
    public int seconds ;
    public GameObject playerMissileCarrier;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject deathParticle;
    public int health ;
    public TMP_Text healthtext;
    //public GameObject healthText;
    // Use this for initialization

    

    void Start () {
        //isShieldOn = false;
        sceneManager = GameObject.FindGameObjectWithTag("transitionScene").gameObject;
        health = 10;
        bullets.transform.localScale = new Vector3(39.34698f, 39.34698f, 39.34698f);
        playerShield.GetComponent<SpriteRenderer>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
       
    }
    public void takeDmg(int damage)
    {
        health -= damage;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shieldIcon")
        {
            Destroy(collision.gameObject);
            //isShieldOn = true;
            playerShield.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<CircleCollider2D>().radius = 1.37f;
            StartCoroutine(disableShield(seconds));
            //playerShield.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (collision.tag == "missileIcon")
        {
             Destroy(collision.gameObject);
            speed = 80;
            bullets.transform.localScale = new Vector3(55, 55, 55);
            bullets.GetComponent<bulletTravel>().dmg = 2;
            bullets.GetComponent<bulletTravel>().bossDmg = 6;
            player.GetComponent<shooterScript>().startDelayShot = 0.05f;
            StartCoroutine(disableMissile());
        }



        }
    IEnumerator disableMissile()
    {
        yield return new WaitForSeconds(3);

        bullets.transform.localScale = new Vector3(39.34698f, 39.34698f, 39.34698f);
        bullets.GetComponent<bulletTravel>().dmg = 1;
        bullets.GetComponent<bulletTravel>().bossDmg = 5;
        player.GetComponent<shooterScript>().startDelayShot = 0.1f;
        speed = 40;
    }
    // Update is called once per frame
    void Update () {
        
        healthtext.text = "Health:" + health;
        if (health <= 0)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(changeScene());
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            
            
        }
        if (health >= 10)
        {
            health = 10;
        }
        /*if (isShieldOn == true)
        {
            
        }
        if (isShieldOn == false)
        {
        }*/


        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = move.normalized * speed;
       
    }
    IEnumerator changeScene()
    {
        sceneManager.GetComponent<sceneTransition>().changeScene();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("gameOver");
        Destroy(gameObject);
    }
    IEnumerator disableShield(int time)
    {
        yield return new WaitForSeconds(time);

        playerShield.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<CircleCollider2D>().radius = 0.91f;
        //StopCoroutine(disableShield(1));
        //playerShield.GetComponent<SpriteRenderer>().enabled = false;
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
