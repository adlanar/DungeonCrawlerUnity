﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Maze mazePrefab;

    public Player playerPrefab;

    private Maze mazeInstance;

    private Player playerInstance;

    private void Start()
    {
        //StartCoroutine(BeginGame());
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0.7f, 0.5f, 0.5f, 0.5f);
    }

    //private IEnumerator BeginGame()
    //{
    //    Camera.main.clearFlags = CameraClearFlags.Skybox;
    //    Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
    //    mazeInstance = Instantiate(mazePrefab) as Maze;
    //    yield return StartCoroutine(mazeInstance.Generate());
    //    playerInstance = Instantiate(playerPrefab) as Player;
    //    playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
    //    Camera.main.clearFlags = CameraClearFlags.Depth;
    //    Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    //}

    private void RestartGame()
    {
        //StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        BeginGame();
        //StartCoroutine(BeginGame());
    }
}