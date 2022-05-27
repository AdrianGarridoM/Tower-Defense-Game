using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    private bool gameOver = false;
    private void Update()
    {
        if (gameOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameOver = true;
        Debug.Log("poner Fin");
    }
}
