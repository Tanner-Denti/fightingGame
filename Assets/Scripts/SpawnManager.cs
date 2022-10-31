using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
 
    private float spawnLimitXLeft = -3;
    private float spawnLimitXRight = 3;
    private float spawnPosY = 10;
 
    private float startDelay = 2.0f;
    //private float spawnInterval;
    private float targetTime;
 
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        targetTime = 2;
    }
    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            SpawnRandomBall();
            targetTime = Random.Range(3, 6);
            //Debug.Log(targetTime);
        }
        Debug.Log(targetTime);
 
    }
 
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
 
        int ballIndex = Random.Range(0, ballPrefabs.Length);
 
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
 
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
 
 
        //Debug.Log(targetTime);
        //targetTime = 0;
 
    }
 
}
 