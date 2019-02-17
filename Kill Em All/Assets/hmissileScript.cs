using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hmissileScript : MonoBehaviour {
    public GameObject homingMissiles;
    public GameObject homingSpawner;
    public int missilesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    // Use this for initialization
    void Start ()
    {

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
                Instantiate(homingMissiles, homingSpawner.transform.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }
}
