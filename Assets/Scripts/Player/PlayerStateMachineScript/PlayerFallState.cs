using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    
    private const float fallMultiplier = 2.0f;

    private readonly int FallAnimation = Animator.StringToHash("jumpFallShinabro");
    // jumpFallShinabro

    
    
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }


    public override void Enter()
    {
        
        stateMachine.PlayerAnimatorManager.PlayerTargetAnimation(FallAnimation);
                
    }

    public override void Tick(float deltaTime)
    {
        Fall(deltaTime);
        
        stateMachine.CurrentDir = CalculateNormalMovementCamera();

        Move(stateMachine.CurrentDir * stateMachine.JumpSpeed ,deltaTime);

        FaceLookCamera(stateMachine.CurrentDir,deltaTime);

        if(stateMachine.Controller.isGrounded){
            
            
            
            stateMachine.SwitchState(new PlayerLandingState(stateMachine));
        }



    }
    public override void Exit()
    {
        
    }

    public override void FixedTick(float deltaTime)
    {
        
    }


    private void Fall(float deltaTime){
        stateMachine.ForceReceiver.VerticalVelocity += stateMachine.ForceReceiver.Gravity * fallMultiplier * deltaTime;
    }

}
