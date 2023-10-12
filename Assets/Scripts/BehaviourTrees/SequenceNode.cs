using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BT{
    //all children needs to succed, we can conitnue
    //if fail everything fail
    public class SequenceNode : CompositeNode
    {
        
        
        
        int current =0;
        protected override void OnStart()
        {
            current = 0;
        }

        protected override State OnUpdate()
        {
            var child = childrens[current];
            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                //we want to continue
                case State.Succes:
                    current ++;
                    break;
                    
            }

            return current == childrens.Count ? State.Succes : State.Running;
        }
        protected override void OnStop()
        {
            
        }

    }

}
