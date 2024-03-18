using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject ready;
    public GameObject gameOver;
    public GameObject restartButton;
    
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.dead += GameOver;
        player.ready += Ready;
        
        if (gameOver.activeInHierarchy == true)
        {
            gameOver.SetActive(false);
        }

        if (ready.activeInHierarchy == false)
        {
            ready.SetActive(true);
        }
    }

    private void Update()
    {
        score.text = GameManager.score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Ready()
    {
        ready.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        restartButton.SetActive(true);
    }
}
