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
        spawnPosition.x = Random.Range(-2.2f, 2.2f);

        if (countTime >= spawnTime)
        {
            CreatePlatform();
            countTime = 0;

        }
    }

    public void CreatePlatform()
    {
        float[] rateArray = new float[] { 0.4f, 0.25f, 0.25f, 0.1f, 0.1f };

        float rand = Random.Range(0, 100) / 100.0f;

        int index = 0;

        for (var i = 0; i < platforms.Count; i++)
        {
            if (rand - rateArray[i] < 1e-2)
            {
                index = i;
                break;
            }

            rand -= rateArray[i];
        }

        //int spikeNum =0;
        //if(index == 4)
        //{
        //    spikeNum++;
        //}

        //if(spikeNum > 1)
        //{
        //    spikeNum = 0;
        //    countTime = spawnTime;
        //    return;
        //}


        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
