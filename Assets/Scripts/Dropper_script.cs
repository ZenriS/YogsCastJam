using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper_script : MonoBehaviour
{
    public GameObject GameManger;
    public Transform DroppObjectHolder;
    public GameObject GiftPrefab;
    private Transform _dropPoint;
    public int GiftCount;
    private ScoreMananger_script _scoreMananger;
    private UIMananger_script _uiMananger;
    
    void Start()
    {
        _scoreMananger = GameManger.GetComponent<ScoreMananger_script>();
        _uiMananger = GameManger.GetComponent<UIMananger_script>();
        _dropPoint = transform.GetChild(1);
        _uiMananger.UpdateGift(GiftCount);
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DoDrop();
        }
    }

    void DoDrop()
    {
        if (GiftCount > 0)
        {
            GameObject go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity,DroppObjectHolder);
            DropObject_script  drop = go.GetComponent<DropObject_script>();
            drop.Config(GameManger);
            //GiftCount--;
            DoGiftCheck();
        }
    }

    public void DmgDrop()
    {
        float dirVel = 10;
        GameObject go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
        DropObject_script drop = go.GetComponent<DropObject_script>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        drop.Config(GameManger);
        Vector3 dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(-dirVel, dirVel), 0);
        rb.velocity = dir;
        GiftCount--;

        go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
        drop = go.GetComponent<DropObject_script>();
        rb = go.GetComponent<Rigidbody2D>();
        drop.Config(GameManger);
        dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(-dirVel, dirVel), 0);
        rb.velocity = dir;
        GiftCount--;

        go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
        drop = go.GetComponent<DropObject_script>();
        rb = go.GetComponent<Rigidbody2D>();
        drop.Config(GameManger);
        dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(-dirVel, dirVel), 0);
        rb.velocity = dir;
        GiftCount--;

        go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
        drop = go.GetComponent<DropObject_script>();
        rb = go.GetComponent<Rigidbody2D>();
        drop.Config(GameManger);
        dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(-dirVel, dirVel), 0);
        rb.velocity = dir;
        GiftCount--;

        go = Instantiate(GiftPrefab, _dropPoint.transform.position, Quaternion.identity, DroppObjectHolder);
        drop = go.GetComponent<DropObject_script>();
        rb = go.GetComponent<Rigidbody2D>();
        drop.Config(GameManger);
        dir = new Vector3(Random.Range(-dirVel, dirVel), Random.Range(-dirVel, dirVel), 0);
        rb.velocity = dir;
        GiftCount--;

        DoGiftCheck();
    }

    private void DoGiftCheck()
    {
        if (GiftCount <= 0)
        {
            //GameOver
            
        }
        _uiMananger.UpdateGift(GiftCount);

    }
}
