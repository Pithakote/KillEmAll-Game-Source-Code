using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingMissile : MonoBehaviour {

    Transform target;
   // public Transform miniBoss;
    float speed = 30f;
    float rotateSpeed = 200f;
    public GameObject destroyParticle;
    private Rigidbody2D rb;
    GameObject boss;

    int playerDmg;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        boss = GameObject.FindGameObjectWithTag("boss").gameObject;
        // miniBoss = GameObject.FindGameObjectWithTag("miniBoss").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(destroyAfter());
    }
    private void Update()
    {
        if (!boss.activeSelf)
        {

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate () {

        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotate = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotate * rotateSpeed;

        rb.velocity = transform.up * speed;
	}

    IEnumerator destroyAfter()
    {
        
        yield return new WaitForSeconds(15);
        Destroy(gameObject);

    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.GetComponent<CircleCollider2D>().radius == 1.37f)
            {
                playerDmg = 0;
            }
            else
            {
                playerDmg = 1;
            }
            target.GetComponent<playerMovement>().takeDmg(playerDmg);
            Instantiate(destroyParticle, transform.position, transform.rotation);
            // GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().takeDmg(playerDmg);
            Destroy(gameObject);
            // Destroy(target);
            
        }
        if (collision.tag == "miniBoss")
        {
           // Destroy(collision);
            collision.GetComponent<destoryMiniBoss>().destroyItself();
            Destroy(gameObject);
            Instantiate(destroyParticle, transform.position, transform.rotation);

        }
    }
}
