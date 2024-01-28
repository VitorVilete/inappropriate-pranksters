using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandshakeMinigameBar : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerSquareRigidBody2D;
    [SerializeField] private Rigidbody2D handshakeRigidBody2D;

    private float speed = 10f;
    private float speedHandshake = 2.5f;
    private float movingTimerMax = 2f;
    private float movingTimerMin = 0.2f;
    private float movingTimer;
    private int handshakeDirection = 1;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Debug.Log("Interacting!");
    }

    private void FixedUpdate()
    {
        if (MinigameManager.Instance.IsGamePlaying()) 
        { 
            if (PlayerSquare.Instance.IsInsideTargetZone())
            {
                MoveSquare();
                MoveHandshake();
            }
            else
            {
                MinigameManager.Instance.triggerLose();
                MinigameManager.Instance.triggerGameOver();
            }
        }
    }

    private void MoveSquare()
    {
        if (gameInput.isInteracting())
        {
            playerSquareRigidBody2D.velocity += new Vector2(speed * Time.deltaTime, 0);
        }
        else
        {
            playerSquareRigidBody2D.velocity -= new Vector2(speed * Time.deltaTime, 0);
        }
    }

    private void MoveHandshake()
    {
        movingTimer -= Time.deltaTime;
        if (movingTimer <= 0)
        {
            ResetMovingTimer();
            SetNewHandshakeDirection();
        }
        else
        {
            if (handshakeDirection > 0)
            {
                handshakeRigidBody2D.velocity += new Vector2(speedHandshake * Time.deltaTime, 0);
            }
            else
            {
                handshakeRigidBody2D.velocity -= new Vector2(speedHandshake * Time.deltaTime, 0);
            }
        }
    }

    private void ResetMovingTimer()
    {
        movingTimer = Random.Range(movingTimerMin, movingTimerMax);
    }

    private void SetNewHandshakeDirection()
    {
        handshakeDirection = handshakeDirection * -1;
        handshakeRigidBody2D.velocity = Vector2.zero;
    }


}
