using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquare : MonoBehaviour
{
    public static PlayerSquare Instance { get; private set; }

    [SerializeField] private Collider2D playerSquareCollider2D;

    private bool isInsideHandshake = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"There is more than one {this.GetType().Name} instance");
        }
        Instance = this;
    }

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInsideHandshake = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInsideHandshake = false;
    }

    public bool IsInsideHandshake()
    {
        return isInsideHandshake;
    }

}
