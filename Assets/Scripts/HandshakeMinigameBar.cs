using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandshakeMinigameBar : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D square;
    [SerializeField] private Rigidbody2D circle;

    private float speed = 100f;

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
        MoveSquare();
    }

    private void MoveSquare()
    {
        if (gameInput.isInteracting())
        {
            square.velocity += new Vector2(speed * Time.deltaTime, 0);
        }
        else
        {
            square.velocity -= new Vector2(speed * Time.deltaTime, 0);
        }
    }
}
