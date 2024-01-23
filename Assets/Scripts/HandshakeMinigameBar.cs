using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandshakeMinigameBar : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerSquareRigidBody2D;
    [SerializeField] private Rigidbody2D handshakeRigidBody2D;

    private float speed = 100f;
    private float movingTimerMax = 1f;
    private float movingTimerMin = 0.2f;
    private float movingTimer;
    private float damageValue = 1f;
    private float maxHealth = 100f;
    private float currentHealth;
    private int handshakeDirection;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        currentHealth = maxHealth;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Debug.Log("Interacting!");
    }

    private void FixedUpdate()
    {
        if (MinigameManager.Instance.IsGamePlaying()) 
        { 
            if (currentHealth <= 0)
            {
                Debug.Log("You Lose!");
            }
            if (!PlayerSquare.Instance.IsInsideHandshake())
            {
                currentHealth -= damageValue * Time.deltaTime;
                Debug.Log(currentHealth);
            }
            MoveSquare();
            MoveHandshake();
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
                handshakeRigidBody2D.velocity += new Vector2(speed * Time.deltaTime, 0);
            }
            else
            {
                handshakeRigidBody2D.velocity -= new Vector2(speed * Time.deltaTime, 0);
            }
        }
    }

    private void ResetMovingTimer()
    {
        movingTimer = Random.Range(movingTimerMin, movingTimerMax);
    }

    private void SetNewHandshakeDirection()
    {
        handshakeDirection = Random.Range(-1, 2);
    }


}
