using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    private Transform player;
    private int playerDmg;
    private Vector2 target;
    public float distance;
    public LayerMask solid;
    public GameObject explosionParticle;
    private GameObject explosionClone;
    // Use this for initializatio
    private cameraShake shake;
    void Start () {
        playerDmg = 1;
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();

        //  Invoke("destroyProjectile", lifeTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;

            target = new Vector2(player.position.x, player.position.y);
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
  //      RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
           // GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health -= 1;
            DestroyProjectile();
        }

    /*    if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<playerMovement>().takeDmg(1);
            }
        }*/
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            shake.CamShake2();
            Debug.Log("player detected");
            removeHealth();
            DestroyProjectile();
        }
       
    }

    void removeHealth()
    {
        if (player.GetComponent<CircleCollider2D>().radius == 1.37f)
        {
            playerDmg = 0;
        }
        else
        {
            playerDmg = 1;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().takeDmg(playerDmg);
    }
    void DestroyProjectile()
    {
        explosionClone = (GameObject) Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(explosionClone,1f);
      //  GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health -= 1;
        Destroy(gameObject);
    }
}
