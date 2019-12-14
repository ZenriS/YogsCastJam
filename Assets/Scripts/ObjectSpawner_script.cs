using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_script : MonoBehaviour
{
    public GameObject[] HousePrefabs;
    public GameObject[] ObstaclePrefabs;
    public Transform ObjectHolder;
    public float HouseSpawnRate;
    public float ObjectSpawnRate;
    public GameObject GameManger;
    public Transform Player;

    void Start()
    {
        StartCoroutine(SpawnHouse());
        StartCoroutine(SpawnObstcle());
    }

    IEnumerator SpawnHouse()
    {
        float timer = Random.Range(HouseSpawnRate / 2, HouseSpawnRate * 1.25f);
        yield return new WaitForSeconds(timer);

        int previus = 0;
        int r = GetRandom(previus, HousePrefabs.Length);

        GameObject go = Instantiate(HousePrefabs[r],ObjectHolder.transform.position,Quaternion.identity,ObjectHolder);
        StartCoroutine(SpawnHouse());
    }

    IEnumerator SpawnObstcle()
    {
        float timer = Random.Range(ObjectSpawnRate / 2, ObjectSpawnRate * 2);
        yield return new WaitForSeconds(timer);
        
        int previus = 0;
        int r = GetRandom(previus, ObstaclePrefabs.Length);

        Vector2 spawnPos = new Vector2(ObjectHolder.transform.position.x, Player.transform.position.y);
        GameObject go = Instantiate(ObstaclePrefabs[r], spawnPos, Quaternion.identity, ObjectHolder);
        
        StartCoroutine(SpawnObstcle());
    }

    private int GetRandom(int previus, int max)
    {
        int r = Random.Range(0, max);
        if (r == previus)
        {
            if (r == max)
            {
                r--;
            }
            else
            {
                r++;
            }
        }

        return r;
    }
}
