using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        player.GetComponent<MarioPlayerController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
    }
}
