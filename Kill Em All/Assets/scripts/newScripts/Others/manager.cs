using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
   
    static manager m_managerInstance;
    public static manager managerInstance
    {
        get
        {
            if (m_managerInstance == null)
            {
                m_managerInstance = new manager();
              // var playerholder = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
              // m_managerInstance = playerholder;
            }
            return m_managerInstance;
        }

    }
    private void Start()
    {
        Debug.Log("Manager start");
        playerInstance.setVariables(500,40,5000,0,0.1f);
        enemyInstance.setVariables(35,20,50,45,0.6f);
        bossInstance.setVariables(2000,0,1);

       playerNormalBulletInstance.SetVariables(84,3,5,8, "Enemy");
       enemyNormalBulletInstance.SetVariables(48,10, "Player");
       //set the player health, speed, turning speed, delayshot and startdelayshot

    }
   [SerializeField]
    Player m_playerInstanceInctance;
    [SerializeField]
    swarmEnemies m_enemyInstance;
    [SerializeField]
    Boss bossInstance;
    [SerializeField]
    EnemyBulletsNormal enemyNormalBulletInstance;
    [SerializeField]
    PlayerBulletsNormal playerNormalBulletInstance;
    public swarmEnemies enemyInstance
    {
        get
        {
            if (m_enemyInstance == null)
            {
                var enemyHolder = GameObject.FindGameObjectWithTag("enemySwarm").GetComponent<swarmEnemies>();
                m_enemyInstance = enemyHolder;
            }

            return m_enemyInstance;
        }

    }
    public Player playerInstance
    {
        get
        {
            if (m_playerInstanceInctance == null)
            {
                var playerHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                m_playerInstanceInctance = playerHolder;
            }
           
            return m_playerInstanceInctance;
        }
        
    }
}
