using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBaseState : State
{

    protected EnemyAI stateMachine;

    public EnemyBaseState(EnemyAI stateMachine){
        this.stateMachine = stateMachine;
    }

    


}
