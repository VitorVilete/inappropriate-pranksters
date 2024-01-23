using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private GameInput gameInput;

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
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Debug.Log("Interacting!");
    }

}
