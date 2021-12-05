using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField] private Image gameOverHUD;
    [SerializeField] private Text restartText;
    [SerializeField] private Text exitText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private KeyCode restartKey;
    private List<IRestartGame> listeners = new List<IRestartGame>();

    private void Awake()
    {
        if (gameOverHUD != null)
            gameOverHUD.enabled = false; restartText.enabled = false; exitText.enabled = false;
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        if (gameOverHUD != null)
            gameOverHUD.enabled = true; restartText.enabled = true; exitText.enabled = true;
        player.GetComponent<MarioPlayerController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
    }

    public void RestartGame()
    {
        if (gameOverHUD != null)
            gameOverHUD.enabled = false; restartText.enabled = false; exitText.enabled = false;
        player.GetComponent<PlayerHealth>().Revive();
        player.GetComponent<MarioPlayerController>().enabled = true;
        camera.GetComponent<CameraController>().enabled = true;
        hud.updateLifeTotal();
        foreach (IRestartGame l in listeners) { l.RestartGame(); }
    }

    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().getLifeTotal() > -1)
        {
            if (Input.GetKeyDown(restartKey))
            {
                RestartGame();
            }
        }
        else
            restartText.enabled = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddRestartListener(IRestartGame listener)
    {
        listeners.Add(listener);
    }

    public void RemoveRestartListener(IRestartGame listener)
    {
        listeners.Remove(listener);
    }
}
