using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BT{
    public class RepeatNode : DecoratorNode
    {
        protected override void OnStart()
        {
            
        }

        protected override State OnUpdate()
        {
            //this create a loop
            child.Update();
            return State.Running;
        }
        protected override void OnStop()
        {
            
        }

    }

}
