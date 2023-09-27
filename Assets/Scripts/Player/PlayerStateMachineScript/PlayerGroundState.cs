using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    
    
    
    private PlayerIdleState idleState;
    private PlayerWalkState walkState;
    private PlayerRunState runState;
    //animations references
    public readonly int  IdleBlendTree = Animator.StringToHash("IdleBlendTree");      
    public readonly int IdleNormalBlend = Animator.StringToHash("IdleNormalBlend");

    
    
    public PlayerGroundState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    
    }

    public override void Enter()
    {
        
       
        //start the idle animations
        stateMachine.PlayerAnimatorManager.PlayBlendTreeAnimaton(IdleBlendTree);


        //load the substates
        idleState = new PlayerIdleState(stateMachine,this);        
        walkState = new PlayerWalkState(stateMachine, this);
        runState = new PlayerRunState(stateMachine,this);
        
        stateMachine.LoadSubState(idleState);
        stateMachine.LoadSubState(walkState);
        stateMachine.LoadSubState(runState);
        //register events
        InputReader.instance.JumpEvent += OnJump;

      
    }

    public override void FixedTick(float deltaTime)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
        
        if(!InputReader.instance.IsSprinting){
            //handle walk 
            HandleMovesWalk(deltaTime);
            
        }
        else if(InputReader.instance.IsSprinting && InputReader.instance.MovementValue != Vector2.zero){
            
            HandleRun(deltaTime);
        }
        
        
        FaceLookCamera(stateMachine.CurrentDir,deltaTime);
    
    }


    public override void Exit()
    {
        
        InputReader.instance.JumpEvent -= OnJump;
    
    }



    private void HandleRun(float deltaTime){

        
        //all the animations are inside this state
        stateMachine.ChangeSubState(runState);
        
    }
    
    private void HandleMovesWalk(float deltaTime){
        
        if(InputReader.instance.MovementValue !=Vector2.zero){
            //we are changing the current direciton on this state, walk state
            stateMachine.ChangeSubState(walkState);
        }
        else if(InputReader.instance.MovementValue == Vector2.zero){
            
            //idle    
            stateMachine.ChangeSubState(idleState);
            
        } 
                

    }
    
    
    
    private void OnJump(){

        stateMachine.SwitchState(new PlayerJumpState(stateMachine));

    }

}
