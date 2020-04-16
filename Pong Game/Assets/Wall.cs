using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager; 
    public PlayerControl player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Ball")
        {
            player.Increment_Score();
            if (player.Score < gameManager.maxScore)
            {
                other.gameObject.SendMessage("Restart_Game", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
