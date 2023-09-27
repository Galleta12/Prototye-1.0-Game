using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    
    private readonly PlayerGroundState groundState;
    public PlayerWalkState(PlayerStateMachine stateMachine, PlayerGroundState groundState) : base(stateMachine)
    {
    
        this.groundState = groundState;
    }


    public override void Enter()
    {

        
    }   


    public override void FixedTick(float deltaTime)
    {
       
    }

    public override void Tick(float deltaTime){

        //get the current movemnt for walkstate
        stateMachine.CurrentDir = CalculateNormalMovementCamera();
        //move character
        Move(stateMachine.CurrentDir * stateMachine.NormalSpeed,deltaTime);

        //walk
        stateMachine.PlayerAnimatorManager.SetBlendAnimation(groundState.IdleNormalBlend,1,deltaTime);



    }


    public override void Exit()
    {
    
    }
    


}
