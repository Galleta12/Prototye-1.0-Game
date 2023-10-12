using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BT{

    public class BTAgent : MonoBehaviour
    {
        public BehaviourTree tree;

        // public Node.Status treeStatus = Node.Status.RUNNING;
        //s
        WaitForSeconds waitForSeconds;

        public virtual void Start()
        {
            //clonnign to avoid any potential error when add more objects with the same tree
            tree = tree.Clone();
            // tree = ScriptableObject.CreateInstance<BehaviourTree>();

            // var log1 = ScriptableObject.CreateInstance<DebugLogNode>();

            // log1.message = "Helloda 111 ";
            
             
            // var pause1 = ScriptableObject.CreateInstance<WaitNode>();

           
            
            
            // var log2 = ScriptableObject.CreateInstance<DebugLogNode>();

            // log2.message = "Helloda 222 ";
            
            // var pause2 = ScriptableObject.CreateInstance<WaitNode>();
            
            // var log3 = ScriptableObject.CreateInstance<DebugLogNode>();

            // log3.message = "Helloda 333";
            
            // var pause3 = ScriptableObject.CreateInstance<WaitNode>();

         
            // var sequence = ScriptableObject.CreateInstance<SequenceNode>();
            // sequence.childrens.Add(log1);
            
            // sequence.childrens.Add(pause1);
            
            // sequence.childrens.Add(log2);
            
            // sequence.childrens.Add(pause2);

            // sequence.childrens.Add(log3);

            // sequence.childrens.Add(pause3);




            // var loop = ScriptableObject.CreateInstance<RepeatNode>();
            // loop.child = sequence; 

            // tree.rootNode = loop;

            // waitForSeconds = new WaitForSeconds(Random.Range(0.1f, 1f));
            // StartCoroutine("Behave");
        }

        // IEnumerator Behave()
        // {
        //     while (true)
        //     {
        //         tree.Update();
        //         yield return waitForSeconds;
        //     }
        // }

        void Update()
        {
            tree.Update();
        }

    }
}
