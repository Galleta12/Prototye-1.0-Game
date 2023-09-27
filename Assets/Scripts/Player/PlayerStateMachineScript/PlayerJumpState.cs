using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    
    
    private readonly int JumpAnimation = Animator.StringToHash("jumpStartShinaBro");
  
    // jumpStartShinaBro
    
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        
        
        //get into the blend
       

        stateMachine.PlayerAnimatorManager.PlayerTargetAnimation(JumpAnimation);
        
        StartJump();

    }


    public override void FixedTick(float deltaTime)
    {
                
    }

    public override void Tick(float deltaTime)
    {
        
        
        stateMachine.CurrentDir = CalculateNormalMovementCamera();

        Move(stateMachine.CurrentDir * stateMachine.JumpSpeed ,deltaTime);

        FaceLookCamera(stateMachine.CurrentDir,deltaTime);

        if(stateMachine.Controller.velocity.y <=0.0f){
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }



        
    }
    public override void Exit()
    {
        

    }
    private void StartJump()
    {
        stateMachine.ForceReceiver.VerticalVelocity = stateMachine.InitialJumpVelocity;
    }
}
