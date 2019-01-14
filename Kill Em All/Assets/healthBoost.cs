using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBoost : MonoBehaviour {

    public GameObject health;
    // public Vector3 spawnValues;
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x, transform.position.x + 50), Random.Range(transform.position.y, transform.position.y - 50), transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(health, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            //  GameObject.Find("player").GetComponent<playerMovement>().health += 2;
            //spawnCount += 1;
            spawnWait -= 0.02f;
            health.GetComponent<healthItem>().lifeTime -= 0.2f;
        }
    }

    private void Update()
    {
        if (health.GetComponent<healthItem>().lifeTime <= 3)
        {
            health.GetComponent<healthItem>().lifeTime = 3;
        }
    }

}
