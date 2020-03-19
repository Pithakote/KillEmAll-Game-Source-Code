using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletsNormal : Bullets
{
    //speed 84
    //bossdmg = 5

    public void SetVariables(int speed, int damage, int bossDamage, int GivenLayer, string targetTagName)
    {
        this.speed = speed;
        this.damage = damage;
        this.bossdamage = bossDamage;
        this.givenLayer = GivenLayer;
        this.targetTagName = targetTagName;
    }
}
