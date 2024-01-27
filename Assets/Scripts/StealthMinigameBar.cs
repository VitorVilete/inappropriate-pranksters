using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthMinigameBar : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerRigidBody2D;
    
    private float playerBackSpeed = 5f;
    private float playerForwardSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (MinigameManager.Instance.IsGamePlaying())
        {
            if (!PlayerSquare.Instance.IsInsideTargetZone())
            {
                MovePlayer();
            }
            else
            {
                MinigameManager.Instance.triggerLose();
                MinigameManager.Instance.triggerGameOver();
            }
        }
    }

    private void MovePlayer()
    {
        if (gameInput.isInteracting())
        {
            playerRigidBody2D.velocity += new Vector2(playerForwardSpeed * Time.deltaTime, 0);
        }
        else
        {
            playerRigidBody2D.velocity -= new Vector2(playerBackSpeed * Time.deltaTime, 0);
        }
    }
}
