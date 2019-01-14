using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    private Transform player;
    private Vector2 target;
    public float distance;
    public LayerMask solid;
    // Use this for initialization
    void Start () {
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
            Debug.Log("player detected");
            removeHealth();
            DestroyProjectile();
        }
    }

    void removeHealth()
    {
        GameObject.Find("player").GetComponent<playerMovement>().takeDmg(1);
    }
    void DestroyProjectile()
    {
      //  GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health -= 1;
        Destroy(gameObject);
    }
}
