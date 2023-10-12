using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    
    
    
    
    public EnemyPatrolState(EnemyAI stateMachine) : base(stateMachine)
    {
    
    }

    public override void Enter()
    {
        
    }


    public override void FixedTick(float deltaTime)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 dir = stateMachine.WayPoint.position - stateMachine.transform.position;        

        stateMachine.NavMeshAgent.destination = stateMachine.WayPoint.position;

        stateMachine.Controller.Move((stateMachine.NavMeshAgent.desiredVelocity.normalized * stateMachine.NormalSpeed)*deltaTime);

        //stay in sync
        //since the velocity is different from the desired velocity. Hence the velocity 
        //of the navmesh needs to be the same as the controller
        stateMachine.NavMeshAgent.velocity = stateMachine.Controller.velocity;

    }
    public override void Exit()
    {
        //reset the current path
        stateMachine.NavMeshAgent.ResetPath();

        stateMachine.NavMeshAgent.velocity = Vector3.zero;
    }
}
