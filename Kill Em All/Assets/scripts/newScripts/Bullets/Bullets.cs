using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField]
    protected float speed, lifeTime, distance;
    [SerializeField]
    protected int damage, bossdamage;
    [SerializeField]
    protected GameObject explosion, destroyParticle;
    [SerializeField]
    protected LayerMask solid;
    protected int givenLayer;
    [SerializeField]
    protected string targetTagName;
    protected Player playerinstance;
    protected virtual void Start()
    {
        damage = 2;
        playerinstance = manager.managerInstance.playerInstance;

        // targetTagName = "Player2";       
    }
    protected virtual void Update()
    {
        move();
    }
    protected virtual void move()
    {
        //   RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
           transform.Translate(Vector2.up * speed * Time.deltaTime); //in order for this to work, the bullets need to access the vector2.up of the enemy it is spawning from
      
     
        DestroyBullet(2f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTagName != "Untagged")
        {
            if (collision.gameObject.CompareTag(targetTagName))
            {
                collision.gameObject.GetComponent<ITakeDamage>().takeDamage(damage);
                DestroyExplosion(0.5f);
                DestroyBullet(0.1f);
            }
        }
     
    }
    protected virtual void DestroyExplosion(float timeToExplode)
    {
        explosion = (GameObject)Instantiate(destroyParticle, transform.position, Quaternion.identity);

        Destroy(explosion, timeToExplode);
    }
    protected virtual void DestroyBullet(float timeToExplode)
    {
        
        Destroy(gameObject, timeToExplode);
    }
  

}
