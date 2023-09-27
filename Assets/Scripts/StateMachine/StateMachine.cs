using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //the current parent state
    private State currentParentState;
    
    //load the sub state
    public void LoadSubState(State newSubState){
        
        
        if(currentParentState ==null)return;
      
        //set it up the parent, hence the child know the current parent
        newSubState.parent = currentParentState;
        currentParentState?.subStates.TryAdd(newSubState.GetType(), newSubState);

    }
        

    //this will handle ParentStates,we will always start with this
    public void SwitchState(State newState){                 
            //exit current state
            currentParentState?.Exit();
            //set up new state
            currentParentState = newState;
            //enter new state
            currentParentState?.Enter();
    }


    public void ChangeSubState(State newState){

        
        if(currentParentState == null)return;
        State currentChildState = currentParentState?.currentSubState;
        
        //first check if the current substate is the same new state
        if(newState.GetType() == currentChildState?.GetType())return;
            
        
        if (currentParentState.subStates.TryGetValue(newState.GetType(), out State newSubState))
        {
                
            currentParentState.currentSubState?.Exit();

            currentParentState.currentSubState = newSubState;

            currentParentState.currentSubState?.Enter();
        }

    }


    public void DesactivateSubState(){
        currentParentState.currentSubState?.Exit();
        currentParentState.currentSubState = null;
    }

    private void FixedUpdate() {
        currentParentState?.FixedTick(Time.fixedDeltaTime);
        currentParentState.currentSubState?.FixedTick(Time.fixedDeltaTime);
    }
    
    private void Update() {
        currentParentState?.Tick(Time.deltaTime);
        currentParentState.currentSubState?.Tick(Time.deltaTime);

    }




    public void PrintDebugger(){

        Debug.Log("This is the current parent state: " + currentParentState.GetType());
        Debug.Log("This is the current sub state: " + currentParentState?.currentSubState?.GetType());

    }

    public void PrintChilds(){

        
        foreach(var kvp in currentParentState.subStates ){
            Debug.Log("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
        
       
    }

    private class Transition{
        public Func<bool> Condition {get;}

        public State From;

        public State To;

    }
}

