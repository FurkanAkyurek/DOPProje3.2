using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private bool gameEnded = false;
    
    void Update()
    {
        if (gameEnded)
            return;
        
        if (PlayerStats.Lives <= 0)
        {
            endGame();
        }
    }

    void endGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
