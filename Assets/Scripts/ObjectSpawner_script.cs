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
    public float BaseMoveSpeed;
    public int HouseCount;

    void Start()
    {
        Time.timeScale = 1;
        _objects = new List<GameObject>();
    }

    IEnumerator SpawnHouse()
    {
        int r = GetRandom(_previusH, HousePrefabs.Length - 1);
        _previusH = r;

        GameObject go = Instantiate(HousePrefabs[r],ObjectHolder.transform.position,Quaternion.identity,ObjectHolder);
        ObjectMovement_script om = go.GetComponent<ObjectMovement_script>();
        om.Config(this);

        r = Random.Range(0, 2);
        r = (r == 0) ? -1: 1;

        go.transform.localScale = new Vector3(r,1,1);
        _objects.Add(go);

        float timer = Random.Range(HouseSpawnRate / 2, HouseSpawnRate * 1.25f);
        yield return new WaitForSeconds(timer);

        HouseCount++;
        CheckSpeed();
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

        ObjectMovement_script om = go.GetComponent<ObjectMovement_script>();
        om.Config(this);

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
        Time.timeScale = 1;
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

    private float CheckSpeed()
    {
        float newSpeed = 0;
        switch (HouseCount)
        {
            case 10:
                Time.timeScale = 1.1f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 30:
                Time.timeScale = 1.2f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 50:
                Time.timeScale = 1.3f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 70:
                Time.timeScale = 1.4f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 90:
                Time.timeScale = 1.5f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            /*case 35:
                Time.timeScale = 1.6f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 40:
                Time.timeScale = 1.7f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 45:
                Time.timeScale = 1.8f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 50:
                Time.timeScale = 1.9f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;
            case 55:
                Time.timeScale = 2f;
                //newSpeed = BaseMoveSpeed * 1.1f;
                break;*/
        }
        
        return newSpeed;
    }
}
