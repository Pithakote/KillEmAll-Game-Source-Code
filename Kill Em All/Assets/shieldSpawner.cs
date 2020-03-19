using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSpawner : MonoBehaviour
{

    public GameObject shield;
    // public Vector3 spawnValues;
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x, transform.position.x + 150), Random.Range(transform.position.y, transform.position.y - 110), transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(shield, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            //  GameObject.Find("player").GetComponent<playerMovement>().health += 2;
            //spawnCount += 1;
            spawnWait -= 0.02f;
           // player.GetComponent<playerMovement>().seconds += 1;
           // shield.GetComponent<healthItem>().lifeTime -= 0.2f;

        }
    }
    public void Update()
    {
       /* if (player.GetComponent<Player>().seconds >= 8)
        {
            player.GetComponent<playerMovement>().seconds = 8;
        }*/
    }




}
