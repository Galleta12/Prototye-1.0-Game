using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT{
    public class WaitNode : ActionNode
    {
        public float duration = 1.0f;
        float startTime;
        
        protected override void OnStart()
        {
            startTime = Time.time;
        }

        protected override State OnUpdate()
        {
            if(Time.time - startTime > duration){
                return State.Succes;
            }
            return State.Running;
        }
        protected override void OnStop()
        {
            
        }

    }

}
