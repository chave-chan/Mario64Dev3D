using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text score;
    public Image healthUI;
    public Text lifeTotal;
    public PlayerHealth ph;

    private void Start()
    {
        DependencyContainer.GetDependency<IScoreManager>()
            .scoreChangedDelegate += updateScore;
    }

    private void OnDestroy()
    {
        DependencyContainer.GetDependency<IScoreManager>()
            .scoreChangedDelegate -= updateScore;
    }

    public void updateScore(IScoreManager scoreManager)
    {
        score.text = "Score: " +
                     scoreManager.getPoints().ToString("0");
    }

    public void changedHealth(float currentHealth, float totalHealth)
    {
        healthUI.fillAmount = currentHealth / totalHealth;
    }

    public void updateLifeTotal()
    {
        lifeTotal.text = "" + ph.getLifeTotal();
    }
}