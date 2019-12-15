using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_script : MonoBehaviour
{
    private UIMananger_script _uiMananger;
    public Dropper_script Player;
    private ScoreMananger_script _scoreMananger;
    public ObjectSpawner_script ObjectSpawner;
    public bool IsGameOver;
    public ObjectMovement_script[] StartingObjects;
    private PlayerCollider_script _playerCollider;
    private Vector3 _startPos;

    void Start()
    {
        _uiMananger = GetComponent<UIMananger_script>();
        _scoreMananger = GetComponent<ScoreMananger_script>();
        _playerCollider = Player.GetComponent<PlayerCollider_script>();
        _startPos = Player.transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("Restart") && !IsGameOver)
        {
            Restart();
        }
    }

    public void GameIsOver()
    {
        IsGameOver = true;
        _uiMananger.ToggleGameOverUI(true, _scoreMananger.MainScore, _scoreMananger.GiftDelivered);
        _playerCollider.ResetValue();
        //Player.gameObject.SetActive(false);
        Player.transform.position = _startPos;
        ObjectSpawner.StopSpawning();
    }

    void LevelCleanUp()
    {
        Player.CleanUp();
        ObjectSpawner.CleanUp();
    }

    public void StartGame()
    {
        foreach (ObjectMovement_script om in StartingObjects)
        {
            om.StopMovement = false;
        }
        IsGameOver = false;
        _uiMananger.ToggleGameOverUI(false, 0 ,0);
        Player.gameObject.SetActive(true);
        ObjectSpawner.StartSpawning();
        Player.StartGifting();
    }

    public void Restart()
    {
        IsGameOver = false;
        _uiMananger.ToggleGameOverUI(false, 0, 0);
        ObjectSpawner.StopSpawning();
        LevelCleanUp();
        ObjectSpawner.StartSpawning();
        _scoreMananger.RestartValues();
        Player.gameObject.SetActive(true);
        Player.StartGifting();
    }
}
