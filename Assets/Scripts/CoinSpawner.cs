using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public List<GameObject> Coins = new List<GameObject>();
    public float spawntime;
    private float counttime;
    private Vector3 spawnPosition;
    
    void Update()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        counttime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-1.5f,1.5f);

        Vector2 pos = new Vector2(spawnPosition.x, spawnPosition.y);

        Collider2D hit = Physics2D.OverlapCircle(pos, 0.05f);

        if (hit == null && counttime >= spawntime)
        {
            CreateCoin();
            counttime =0;
        }
    }

    public void CreateCoin()
    {
        int index = Random.Range(0,Coins.Count);
        int coinNum = 0;
        if(index == 4)
        {
            coinNum++;
        }
        if(coinNum > 1)
        {
            coinNum = 0;
            counttime = spawntime;
            return;
        }
        GameObject newcoin = Instantiate(Coins[index],spawnPosition,Quaternion.identity);
        newcoin.transform.SetParent(this.gameObject.transform);
    }
}
