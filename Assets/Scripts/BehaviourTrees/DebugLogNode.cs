using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BT{
    public class DebugLogNode : ActionNode
    {
        public string message;
        protected override void OnStart()
        {
            Debug.Log($"On Start{message}");
        }

        //the dubug log node can not fail
        protected override State OnUpdate()
        {
            Debug.Log($"On Update{message}");

            return State.Succes;
            
        }
        protected override void OnStop()
        {
            Debug.Log($"On Stop{message}");
            
        }

    }
}
