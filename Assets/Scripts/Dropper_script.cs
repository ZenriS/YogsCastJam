using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper_script : MonoBehaviour
{
    public GameObject GameManger;
    public Transform DroppObjectHolder;
    public GameObject[] GiftPrefabs;
    private Transform _dropPoint;
    public int StarGiftCount;
    public int GiftCount;
    private ScoreMananger_script _scoreMananger;
    private UIMananger_script _uiMananger;
    private DropObject_script _activeGift;
    public float SpawnTimer;
    private int _previus;
    private GameController_script _gameController;
    private List<GameObject> _drops;
    
    void Start()
    {
        _scoreMananger = GameManger.GetComponent<ScoreMananger_script>();
        _gameController = GameManger.GetComponent<GameController_script>();
        _dropPoint = transform.GetChild(1);
        _drops = new List<GameObject>();
    }

    void OnEnable()
    {
        _uiMananger = GameManger.GetComponent<UIMananger_script>();
        
    }

    public void StartGifting()
    {
        StopAllCoroutines();
        GiftCount = StarGiftCount;
        _uiMananger.UpdateGift(GiftCount);
        StartCoroutine("CreateGift");
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _activeGift != null && !_gameController.IsGameOver)
        {
            DoDrop();
        }
    }

    IEnumerator CreateGift()
    {
        yield return new WaitForSeconds(SpawnTimer);
        if (GiftCount > 0)
        {
            int r = GetRandom(_previus, GiftPrefabs.Length);
            _previus = r;
            GameObject go = Instantiate(GiftPrefabs[r], _dropPoint.transform.position, Quaternion.identity, _dropPoint);
            _activeGift = go.GetComponent<DropObject_script>();
            _drops.Add(go);
        }
    }

    void DoDrop()
    {
        _activeGift.Config(GameManger, this.transform.position.y);
        GiftCount--;
        DoGiftCheck();
        _activeGift.transform.SetParent(DroppObjectHolder);
        _activeGift = null;
        StartCoroutine("CreateGift");
    }

    public void DmgDrop()
    {
        float dirVel = 30;
        for (int i = 0; i < 4; i++)
        {
            GiftCount--;
            if (GiftCount < 0)
            {
                DoGiftCheck();
                return;
            }
            float y = this.transform.position.y;
            int r = GetRandom(_previus, GiftPrefabs.Length);
            _previus = r;
            GameObject go = Instantiate(GiftPrefabs[r], _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
            DropObject_script drop = go.GetComponent<DropObject_script>();
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            drop.Config(GameManger, y);
            Vector3 dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(dirVel /2, dirVel), 0);
            rb.velocity = dir;
            if (GiftCount < 0)
            {
                GiftCount = 0;
            }
            DoGiftCheck();
        }
        
    }

    private void DoGiftCheck()
    {
        if (GiftCount <= -1)
        {
            GiftCount = 0;
            _gameController.GameIsOver();
            //GameOver

        }
        _uiMananger.UpdateGift(GiftCount);
    }

    private int GetRandom(int previus, int max)
    {
        int r = Random.Range(0, max);
        int tries = 0;

        while (r == previus)
        {
            r = Random.Range(0, max);
            tries++;
            if (tries == 5)
            {
                break;
            }
        }

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

    public void CleanUp()
    {
        foreach (GameObject go in _drops)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }

        _drops = new List<GameObject>();
        GiftCount = StarGiftCount;
        _uiMananger.UpdateGift(GiftCount);
    }
}
