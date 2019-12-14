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
    private int _previusO;
    private int _previusH;
    private List<GameObject> _objects;

    void Start()
    {
        _objects = new List<GameObject>();
    }

    IEnumerator SpawnHouse()
    {
        int r = GetRandom(_previusH, HousePrefabs.Length - 1);
        _previusH = r;

        GameObject go = Instantiate(HousePrefabs[r],ObjectHolder.transform.position,Quaternion.identity,ObjectHolder);
        r = Random.Range(0, 2);
        r = (r == 0) ? -1: 1;
        go.transform.localScale = new Vector3(r,1,1);
        _objects.Add(go);

        float timer = Random.Range(HouseSpawnRate / 2, HouseSpawnRate * 1.25f);
        yield return new WaitForSeconds(timer);

        StartCoroutine(SpawnHouse());
    }

    IEnumerator SpawnObstcle()
    {
        float timer = Random.Range(ObjectSpawnRate / 2, ObjectSpawnRate * 2);
        yield return new WaitForSeconds(timer);

        int r = GetRandom(_previusO, ObstaclePrefabs.Length - 1);
        _previusO = r;

        Vector2 spawnPos = new Vector2(ObjectHolder.transform.position.x, Player.transform.position.y);
        GameObject go = Instantiate(ObstaclePrefabs[r], spawnPos, Quaternion.identity, ObjectHolder);

        _objects.Add(go);
        StartCoroutine(SpawnObstcle());
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnHouse());
        StartCoroutine(SpawnObstcle());
    }

    public void CleanUp()
    {
        foreach (GameObject go in _objects)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }

        _objects = new List<GameObject>();
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
