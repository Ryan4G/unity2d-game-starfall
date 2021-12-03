using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float spawnTime;
    private float countTime;
    private Vector3 spawnPosition;

    
    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-2.2f,2.2f);

        if ( countTime >= spawnTime )
        {
            CreatePlatform();
            countTime = 0;

        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0,platforms.Count);
        int spikeNum =0;
        if(index == 4)
        {
        spikeNum++;
        }
        if(spikeNum > 1)
        {
            spikeNum = 0;
            countTime = spawnTime;
            return;
        }

       GameObject newPlatform = Instantiate(platforms[index],spawnPosition,Quaternion.identity);
       newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
