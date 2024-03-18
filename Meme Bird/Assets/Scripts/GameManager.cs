using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float score;

    private Player player;
    private void Start()
    {
        score = 0;
        player = FindObjectOfType<Player>();
        player.scoring += IncreaseScore;
        
    }

    private static void IncreaseScore()
    {
        score += 1;
    }
}
