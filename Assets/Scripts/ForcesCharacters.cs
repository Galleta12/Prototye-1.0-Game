using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ForcesOfCharacters
{
    public class ForcesCharacters : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;

        [SerializeField] private float drag = 0.1f;

        private float verticalVelocity;

        public float VerticalVelocity{get{return verticalVelocity;}set{verticalVelocity=value;}}

        private Vector3 dampingVelocity;

        private Vector3 impact;

        public float gravity = -9.8f;

        public float Gravity{get{return gravity;}set{gravity = value;}}

        private readonly float groundGravity = -.05f;

        //this will be used by the stateMachines
        public Vector3 Movement => impact + (Vector3.up * verticalVelocity);


    private void Start(){
        
   }
  
   
   
   private void Update() {
             
        if(verticalVelocity < 0f && controller.isGrounded){
             
            verticalVelocity= groundGravity  * Time.deltaTime;
         
        }
        
        else{
            verticalVelocity += gravity * Time.deltaTime;     
        

        }
        // reduce impact until is 0
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);

   
     }

     public void AddForce(Vector3 force){
       impact += force;

     }



    


    // public void Jump(){
    //     verticalVelocity = intialJumpVelocity;

    // }

    // public void falling(){
    //    float fallMultiplier = 2.0f;

    //    verticalVelocity += gravity *  fallMultiplier * Time.deltaTime;

    // }

    // public void DoubleJump(){
           
         
           
    //        verticalVelocity = intialJumpVelocity * 1.2f;
    // }

    
    }
    
};

