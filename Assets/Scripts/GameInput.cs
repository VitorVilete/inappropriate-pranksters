using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnPauseAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Subscribing to events
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
        
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (MinigameManager.Instance != null)
        {
            if (Input.GetKeyUp(KeyCode.U))
            {
                MinigameManager.Instance.triggerGameOver();
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                MinigameManager.Instance.triggerLose();
                MinigameManager.Instance.triggerGameOver();
            }
        }
        #endif
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        // Unsubscribing to events
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public bool isInteracting()
    {
        float isInteracting = playerInputActions.Player.Interact.ReadValue<float>();
        return isInteracting != 0f;
    }

    private float GetInteractionPress()
    {
        return playerInputActions.Player.Interact.ReadValue<float>();
    }
}
