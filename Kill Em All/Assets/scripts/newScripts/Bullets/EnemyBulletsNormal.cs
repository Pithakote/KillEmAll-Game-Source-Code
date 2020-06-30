using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsNormal : Bullets
{
    //speed 48
    //life 15
    //distance = 20

    protected override void move()
    {
      //  base.move();
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerinstance.transform.position.x, playerinstance.transform.position.y), speed * Time.deltaTime);
        DestroyBullet(2f);

    }
    public void SetVariables(int speed, int GivenLayer, string targetTagName)
    {
        this.speed = speed;
        this.givenLayer = GivenLayer;
        this.targetTagName = targetTagName;
    }
}
