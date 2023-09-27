using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerControls.IPlayerActions
{
    

    //Controls input manager
    private PlayerControls playerControls;

    //Input Manager Singleton
    public static InputReader instance;

    
    
    
    //variables input reader
    public Vector2 MovementValue{get; private set;}

    public bool IsSprinting{get;private set;}

    public bool IsJumping{get;private set;}
    
    //events
    public event Action JumpEvent;
    
    
    //set the instance for the singleton
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        
        if(playerControls == null){

            /// store instance of class controls
            playerControls = new PlayerControls();
            // reference to this class
            playerControls.Player.SetCallbacks(this);
            // enable it
            playerControls.Player.Enable();
        }
    }
    
    
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
        // Debug.Log(MovementValue);
        // Debug.Log(IsSprinting);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
      
    }




    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.performed)IsSprinting=true;
        else if(!context.performed) IsSprinting=false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // if(context.performed)IsJumping=true;
        // else if(!context.performed)IsJumping=false;
        if(!context.performed)return;
        JumpEvent?.Invoke();

    }
}
