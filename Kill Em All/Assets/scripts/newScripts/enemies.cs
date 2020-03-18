using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : Ships
{
    [SerializeField]
    private float stopDist;
    [SerializeField]
    private float retreatDist;
    [SerializeField]
    private cameraShake shake;
     Player playerinstance;
    
    public virtual void setVariables(int enemyHealth, int speed, int stopDistance, float retreatDistance, float starttimebetweenshots)
    {
        Debug.Log("Constructor");
        this.health = enemyHealth;
        this.speed = speed;
        this.stopDist = stopDistance;
        this.retreatDist = retreatDistance;
        this.startDelayShot = starttimebetweenshots;
    }
    protected override void Start()
    {
        base.Start();
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();

        playerinstance = manager.managerInstance.playerInstance;
        delayShot= startDelayShot;
    }

    protected override void move()
    {
        if (!playerinstance.IsDead)
        {
            if (Vector2.Distance(transform.position, playerinstance.transform.position) > stopDist)//if the enemies are far from the player/stopping distance enemies move towards the player
            {
                transform.position = Vector2.MoveTowards(transform.position, playerinstance.transform.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, playerinstance.transform.position) < stopDist && Vector2.Distance(transform.position, playerinstance.transform.position) > retreatDist)//doesnt move for a while
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, playerinstance.transform.position) < retreatDist)//if the enemy comes very close to the player, it starts to move away
            {
                transform.position = Vector2.MoveTowards(transform.position, playerinstance.transform.position, -speed * Time.deltaTime);
            }

        }
    }

    public override void takeDamage(int damageAmount)
    {
        shake.CamShake();
        base.takeDamage(damageAmount);

    }

}
