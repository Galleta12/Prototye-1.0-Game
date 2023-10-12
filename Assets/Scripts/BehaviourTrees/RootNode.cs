using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT{
    
    public class RootNode : Node
    {
        public Node children;

        protected override void OnStart()
        {
            
        }

        protected override State OnUpdate()
        {
            return children.Update();   
        }
        protected override void OnStop()
        {
            
        }
        
        public override Node Clone(){
            RootNode node = Instantiate(this);
            node.children = children.Clone();
            return node;
        }

    }

}
