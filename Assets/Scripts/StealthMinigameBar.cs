using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthMinigameBar : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerRigidBody2D;
    
    private float playerBackSpeed = 5f;
    private float playerForwardSpeed = 10f;
    private float randomModifierIntervalTotal = 5f;
    private float movingTimer;

    public float secondPersonMinMovingSpeed;
    public float secondPersonMaxMovingSpeed;
    public Rigidbody2D secondPersonRigidbody2D;

    private bool movingSecondPersonForward;
    private bool movingSecondPersonBack;

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

                if (movingSecondPersonForward)
                {
                    MoveBodyForward(secondPersonRigidbody2D);
                } else if (movingSecondPersonBack)
                { 
                    MoveBodyBack(secondPersonRigidbody2D);
                }

                RandomizeModifier();

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

    private void RandomizeModifier()
    {
        movingTimer -= Time.deltaTime;
        if (movingTimer <= 0)
        {
            ResetMovingTimer();
            //randomize modifier
            secondPersonRigidbody2D.velocity = Vector2.zero;
            int randomNumber = Random.Range(1, 3);
            switch (randomNumber)
            {
                case 1:
                    Debug.Log("Case 1");
                    movingSecondPersonForward = true;
                    movingSecondPersonBack = false;
                    break;
                case 2:
                    Debug.Log("Case 2");
                    movingSecondPersonForward = false;
                    movingSecondPersonBack = true;
                    break;
                case 3:
                    Debug.Log("Case 3");
                    movingSecondPersonForward = false;
                    movingSecondPersonBack = false;
                    break;
            }
        }
    }

    private void ResetMovingTimer()
    {
        movingTimer = randomModifierIntervalTotal;
    }
    private void MoveBodyForward(Rigidbody2D secondPersonRigidbody2D)
    {
        float secondPersonMovingSpeed = Random.Range(secondPersonMinMovingSpeed, secondPersonMaxMovingSpeed); 
        secondPersonRigidbody2D.velocity += new Vector2(secondPersonMovingSpeed * Time.deltaTime, 0);
    }

    private void MoveBodyBack(Rigidbody2D secondPersonRigidbody2D)
    {
        float secondPersonMovingSpeed = Random.Range(secondPersonMinMovingSpeed, secondPersonMaxMovingSpeed);
        secondPersonRigidbody2D.velocity -= new Vector2(secondPersonMovingSpeed * Time.deltaTime, 0);
    }
}
