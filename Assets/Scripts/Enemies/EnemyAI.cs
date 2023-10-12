using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForcesOfCharacters;
using BT;
using Unity.VisualScripting;
using UnityEngine.AI;

public class EnemyAI : StateMachine
{
    

    //normal variables

    //blackboard

    //layers
    //first layer bt
    
    //secpmd layer states

    
    
    
    [field: SerializeField] public NavMeshAgent NavMeshAgent {get;private set;}
    [field: SerializeField] public Transform WayPoint {get;private set;}
    
    
    [field: SerializeField] public CharacterController Controller {get;private set;}

    //animations
    [field: SerializeField] public Animator Animator {get; private set; }
        
    //Velocity Jogging
    [field: SerializeField] public float NormalSpeed {get;private set;}
    

     //the rotation damp speed
    [field: SerializeField] public float RotationDampSpeed {get;private set;}
    //forces
    [field: SerializeField] public ForcesCharacters ForceReceiver {get;private set;}


    
    //handle the direction
    private Vector3 currentDirection;

    public Vector3 CurrentDir{get{return currentDirection;}set{currentDirection = value;}}



    private EnemyAnimatorManager enemyAnimatorManager;
    public EnemyAnimatorManager EnemyAnimatorManager {get{return enemyAnimatorManager;}set{enemyAnimatorManager=value;}}




    private void Start() {
        
        //we dont want to move the agent with the navmesh, but we want to move it
        //with out own custom scripts

        NavMeshAgent.updatePosition = false;
        NavMeshAgent.updateRotation = false;
        
        
        
        StartClasses();
        SwitchState(new EnemyPatrolState(this));
   
    }

    private void StartClasses()
    {
        enemyAnimatorManager = new EnemyAnimatorManager(Animator);
    }


    

    
    




}
