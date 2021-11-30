using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private KeyCode restartKey;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(restartKey))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        player.GetComponent<MarioPlayerController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
    }

    public void RestartGame()
    {

    }
}
