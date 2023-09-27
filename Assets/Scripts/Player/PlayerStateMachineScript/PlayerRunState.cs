using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    
   
   
   
   private Vector3 currentVelocity = Vector3.zero;
   private Vector3 smoothDampVelocity = Vector3.zero;

   private float smoothDampTime = 0.8f;
   
   
    private readonly PlayerGroundState groundState;

    public readonly int BoolRun = Animator.StringToHash("RunBlendBool");

    private readonly int RunBlendTree = Animator.StringToHash("RunBlendTree");
    private readonly int RunNormalBlend = Animator.StringToHash("RunNormalBlend");
    public PlayerRunState(PlayerStateMachine stateMachine, PlayerGroundState groundState) : base(stateMachine)
    {
        this.groundState = groundState;
    }

    public override void Enter()
    {

        
        stateMachine.PlayerAnimatorManager.BoolChangeAnimation(BoolRun,true);
        
        stateMachine.PlayerAnimatorManager.PlayBlendTreeAnimaton(RunBlendTree);
        
    }

    public override void FixedTick(float deltaTime)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
        
        
        
        
        // currentVelocity is a Vector3 that represents the current velocity of your character.
        // smoothDampVelocity is used by Vector3.SmoothDamp to keep track of its internal state. 
        // You should initialize it to Vector3.zero when you declare it.
        
        // smoothDampTime is a parameter that controls the time it takes for the current velocity to approach the target velocity. 
        // A smaller value will result in quicker adjustments, 
        // while a larger value will lead to smoother and slower changes.
        
        
        stateMachine.CurrentDir = CalculateNormalMovementCamera();

        Vector3 targetVelocity = stateMachine.CurrentDir * stateMachine.RunSpeed;

        currentVelocity = Vector3.SmoothDamp(
            currentVelocity,
            targetVelocity,
            ref smoothDampVelocity,
            smoothDampTime
        ); 
        
        
      

        Move(targetVelocity,deltaTime);
        
        stateMachine.PlayerAnimatorManager.SetBlendAnimation(RunNormalBlend,0,deltaTime);
    }
    public override void Exit()
    {
        
        //this can be improved
        stateMachine.PlayerAnimatorManager.SetBlendAnimation(RunNormalBlend,1,Time.deltaTime);
        //before chaging to the bool we want to check if the normalize time 
        
        //when we exit we want to set the bool as false
        stateMachine.PlayerAnimatorManager.BoolChangeAnimation(BoolRun,false);
        //get back to the blend of the ground, the run is only being played on the ground state
        stateMachine.PlayerAnimatorManager.PlayBlendTreeAnimaton(groundState.IdleBlendTree);

    
    }



}
