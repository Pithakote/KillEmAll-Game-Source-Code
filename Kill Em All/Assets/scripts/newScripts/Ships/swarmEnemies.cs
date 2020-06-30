using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmEnemies : enemies
{
    protected override void move()
    {
        base.move();
        Direction = playerinstance.transform.position - transform.position;
        //angle will rotate ship to the direction of the ship
        //need to rotate the sprite by -90 for it to work
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        rb.rotation = Angle;
    }
}
