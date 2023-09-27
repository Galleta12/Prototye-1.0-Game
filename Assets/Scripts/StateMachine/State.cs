using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    

    public State currentSubState;

    public State parent;

    public Dictionary<Type, State> subStates = new Dictionary<Type, State>();



    
    public abstract void Enter();

    public abstract void FixedTick(float deltaTime);
    
    public abstract void Tick(float deltaTime);

    public abstract void Exit();


    




}
