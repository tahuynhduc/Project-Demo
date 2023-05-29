using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerHealth playerHealth;
    public GameObject gameWinUI;
    private void Start()
    {
        gameOverUI.SetActive(false);

    }
    private void Update()
    {
        if (EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }
    private void OnGameWin()
    {
        gameWinUI.SetActive(true);
        playerHealth.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        gameOverUI.SetActive(true);
    }
}
