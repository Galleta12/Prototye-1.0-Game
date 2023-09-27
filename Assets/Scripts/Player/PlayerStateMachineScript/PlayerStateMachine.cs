using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ForcesOfCharacters;


    
public class PlayerStateMachine : StateMachine
{


    
    //input reader is a slingleton script.
    [field: SerializeField] public CharacterController Controller {get;private set;}

    //animations
    [field: SerializeField] public Animator Animator {get; private set; }
        
    //Velocity Jogging
    [field: SerializeField] public float NormalSpeed {get;private set;}
    [field: SerializeField] public float RunSpeed {get;private set;}
    [field: SerializeField] public float JumpSpeed {get;private set;}
    [field: SerializeField] public float MaxJumpHeight = 2.0f;

    [field: SerializeField] public float MaxJumpTime = 0.5f;
    
    
    
    //the rotation damp speed
    [field: SerializeField] public float RotationDampSpeed {get;private set;}
    //forces
    [field: SerializeField] public ForcesCharacters ForceReceiver {get;private set;}


    //camera variable
    private Camera mainCamera;
    public Camera MainCamera {get{return mainCamera;}set{mainCamera = value;}}


    //handle the direction
    private Vector3 currentDirection;

    public Vector3 CurrentDir{get{return currentDirection;}set{currentDirection = value;}}


    //handle other forces
    //jump varaibles
    
    private float intialJumpVelocity;

    public float InitialJumpVelocity{get{return intialJumpVelocity;}set{intialJumpVelocity=value;}}

    
    
    
    //classes only for state machine
    private PlayerAnimatorManager playerAnimatorManager;
    public PlayerAnimatorManager PlayerAnimatorManager {get{return playerAnimatorManager;}set{playerAnimatorManager=value;}}

    public void Start() {
        
        //initialize initial variables
        Initialize();
        //set up classes of the player
        StartClasses();
        
        SwitchState(new PlayerGroundState(this));
    }

    private void Initialize()
    {
        mainCamera = Camera.main;
        SetupJumpVariable();
    }

    private void StartClasses()
    {
        playerAnimatorManager = new PlayerAnimatorManager(Animator);
    }

    private void LateUpdate() {
       
    }

    // set the variables for the jumping
    private void SetupJumpVariable()
    {
        float timeToApex =MaxJumpTime / 2;
        ForceReceiver.Gravity = -2 * MaxJumpHeight / MathF.Pow(timeToApex, 2);
        intialJumpVelocity = 2 * MaxJumpHeight / timeToApex; 
    }
    

}


