using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingState : PlayerBaseState
{
    
    
    
    
    private readonly int LandAnimation = Animator.StringToHash("jumpEndShinaBro");
    
    // jumpEndShinaBro
    
    public PlayerLandingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    
    }

    public override void Enter()
    {
        stateMachine.PlayerAnimatorManager.PlayerTargetAnimation(LandAnimation);
    }

    public override void FixedTick(float deltaTime)
    {

    }

    public override void Tick(float deltaTime)
    {
        //check if the time has pass
        if(!stateMachine.Controller.isGrounded){
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
            return;
        }

        float normalized = stateMachine.PlayerAnimatorManager.GetNormalizedTime(stateMachine.Animator,"jumpEnd");

        if(normalized >= 1.0f){
            stateMachine.SwitchState(new PlayerGroundState(stateMachine));
        }
        else if(InputReader.instance.MovementValue !=Vector2.zero){
            stateMachine.SwitchState(new PlayerGroundState(stateMachine));
        }        


    }
    public override void Exit()
    {
        
    }
}
