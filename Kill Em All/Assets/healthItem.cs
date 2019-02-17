using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItem : MonoBehaviour
{

 //   public float speed;
    public float lifeTime ;
   // private int healthincrease;
  //  private Transform player;
 //   private Vector2 target;
 //   public float distance;
 //   public LayerMask solid;
    // Use this for initialization
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player detected");
            addHealth();
            DestroyProjectile();
        }
    }

    void addHealth()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health += 1 ;
    }
    void DestroyProjectile()
    {
        //  GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health -= 1;
        Destroy(gameObject);
    }
}
