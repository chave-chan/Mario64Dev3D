using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private KeyCode restartKey;
    private List<IRestartGame> listeners = new List<IRestartGame>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        player.GetComponent<MarioPlayerController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
    }

    public void RestartGame()
    {
        foreach (IRestartGame l in listeners) { l.RestartGame(); }
    }

    private void Update()
    {
        if (Input.GetKeyDown(restartKey)) { RestartGame(); }
    }

    public void AddRestartListener(IRestartGame listener)
    {
        listeners.Add(listener);
    }

    public void RemoveRestartListener(IRestartGame listener)
    {
        listeners.Add(listener);
    }
}
