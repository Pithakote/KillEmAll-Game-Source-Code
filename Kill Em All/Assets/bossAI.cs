using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bossAI : MonoBehaviour {
    private float timeBetShots;
    public float startTimeBetShots;
    public Transform spawner1;
    public Transform spawner2;
    public GameObject enemyBullet;
    public int healthBoss = 100;
    private cameraShake shake;
    public bool bossDefeat = false;
    public Transform homingSpawner;

    public GameObject homingMissiles;
    // public Vector3 spawnValues;
    public int missilesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int healthincrease;
     GameObject smallEnemySpawn;
    public int waveNumber = 1;
    public Transform player;
    // Use this for initialization
    void Start () {
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();
       
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetShots = startTimeBetShots;
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < missilesCount; i++)
            {
                // Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x, transform.position.x + 150), Random.Range(transform.position.y, transform.position.y - 100));//, transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(homingMissiles, homingSpawner.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }

    
    // Update is called once per frame
    void Update () {
        if (timeBetShots <= 0)
        {
            Instantiate(enemyBullet, spawner1.position, Quaternion.identity);
            Instantiate(enemyBullet, spawner2.position, Quaternion.identity);
            timeBetShots = startTimeBetShots;
        }
        else
        {
            timeBetShots -= Time.deltaTime;
        }

        if (healthBoss <= 0)
        {
            SceneManager.LoadScene("yes");
            bossDefeat = true;
            

        }
        if (bossDefeat == true)
        {
            gameObject.SetActive(false);
        }
    }

   public void bossDecreaseHealth()
    {
        healthBoss -= 5;
    }
}
