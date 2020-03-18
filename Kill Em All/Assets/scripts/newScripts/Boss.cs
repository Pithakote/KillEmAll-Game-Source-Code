using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : enemies
{
    [SerializeField]
    GameObject homingSpawner;
    [SerializeField]
    Animator bossAnim;
    [SerializeField]
    GameObject homingMissiles;
    [SerializeField]
    bool isMove;
    [SerializeField]
    GameObject miniBoss;
    [SerializeField]
    GameObject enemyBullet;
    // Start is called before the first frame update
    public void setVariables(int health, int delaytime, int startdelaytime)
    {
        this.health = health;
        this.delayShot = delaytime;
        this.startDelayShot = startdelaytime;
    }
    protected override void Start()
    {
        bossAnim = GetComponent<Animator>();
        gameObject.GetComponent<hmissileScript>().enabled = false;
        miniBoss.SetActive(false);
        base.Start();
    }
    protected override void shoot()
    {
        base.shoot();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void move()
    {
        if (this.health <= 1000)
        {

            bullets.GetComponent<enemyBullet>().speed = 42;
            //enemyBullet.GetComponent<enemyBullet>().distance = 30;
            miniBoss.SetActive(true);
            gameObject.GetComponent<hmissileScript>().enabled = true;
            isMove = true;
            // miniBoss.SetActive(true);
            startDelayShot = 0.3f;
            Debug.Log("Health boss 50");

        }
        if (this.health <= 1500)
        {
            bullets.GetComponent<enemyBullet>().speed = 35;
            bullets.GetComponent<enemyBullet>().distance = 30;
            startDelayShot = 0.5f;
            bossAnim.SetTrigger("moveTrigger");

        }
    }
}
