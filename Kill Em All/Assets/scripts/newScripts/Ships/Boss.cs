using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : enemies
{
    [SerializeField]
    GameObject homingSpawner;
    [SerializeField]
    Animator bossAnim;//the game object 9B uses animationcontroller 9B1. Use 9B gameobject in this. the boss animator uses 9B, that is responsible for bringing the boss to the screen
    [SerializeField]
    GameObject homingMissiles;
    [SerializeField]
    bool isMove;
    [SerializeField]
    GameObject miniBoss;
    [SerializeField]
    Transform initialPosition;
    [SerializeField]
    bool isInitialPos;
  //  Vector2 screenBoundray;
   
    // Start is called before the first frame update
    public void setVariables(int health, int delaytime, int startdelaytime)
    {
        this.health = health;
        this.delayShot = delaytime;
        this.startDelayShot = startdelaytime;
    }
    protected override void Start()
    {
       // screenBoundray = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        isInitialPos = false;
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
        if (!isInitialPos)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, initialPosition.position, 10f * Time.deltaTime);
            if(transform.position == initialPosition.position)
            isInitialPos = true;
        }//  isInitialPos = true;
        

        if (health <= 1500)
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
        if (health <= 1800)
        {
            bullets.GetComponent<enemyBullet>().speed = 35;
            bullets.GetComponent<enemyBullet>().distance = 30;
            startDelayShot = 0.5f;
            transform.position = Vector2.Lerp(new Vector2(leftScreen.x,transform.position.y), new Vector2(screenBounds.x, transform.position.y) , Mathf.PingPong(Time.time * 0.25f , 1f));//ping pong, second parameter determines how long the ship stays at the end, first parameter determines how long should it take to go to and from the two positions, larger number is faster and lowernumber is slower
           // bossAnim.SetTrigger("moveTrigger");

        }
    }
}
