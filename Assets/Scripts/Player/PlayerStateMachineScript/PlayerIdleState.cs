using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private readonly PlayerGroundState groundState;
    public PlayerIdleState(PlayerStateMachine stateMachine, PlayerGroundState groundState) : base(stateMachine)
    {
        this.groundState = groundState;
    }

    public override void Enter()
    {
    
    }


    public override void FixedTick(float deltaTime)
    {
        
    }

    public override void Tick(float deltaTime)
    {

        //idle
        stateMachine.PlayerAnimatorManager.SetBlendAnimation(groundState.IdleNormalBlend,0,deltaTime);
        
    }
    public override void Exit()
    {
        
    }



}
