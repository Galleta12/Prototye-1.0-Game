using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    
    protected PlayerStateMachine stateMachine;


    public PlayerBaseState(PlayerStateMachine stateMachine){
        this.stateMachine = stateMachine;
    }



    protected Vector3 CalculateNormalMovementCamera(){
        //first get the forward and right vectors of the camera
        Vector3 cameraForward = stateMachine.MainCamera.transform.forward;
        Vector3 cameraRight = stateMachine.MainCamera.transform.right;
        //we dont want to consider y component
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;
        //normalize
        cameraForward.Normalize();
        cameraRight.Normalize();
        //get the new vector
        return cameraRight * InputReader.instance.MovementValue.x + 
        cameraForward * InputReader.instance.MovementValue.y;

    }


    //rotation
    protected void FaceLookCamera(Vector3 direction, float deltaTime){
    
      if(InputReader.instance.MovementValue == Vector2.zero)return;
       
        
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation,
        Quaternion.LookRotation(direction),
        deltaTime * stateMachine.RotationDampSpeed
        );


    }


    protected void Move(Vector3 motion, float deltaTime){
        stateMachine.Controller.Move((stateMachine.ForceReceiver.Movement + motion) * deltaTime);
    }

    

}
