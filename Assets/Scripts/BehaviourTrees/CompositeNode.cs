using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BT{
    public abstract class CompositeNode : Node
    {
        public List<Node> childrens = new List<Node>();


        public override Node Clone(){
            CompositeNode node = Instantiate(this);
            //clone on each of the children
            //node.childrens.ConvertAll(c=>c.Clone());
            node.childrens = childrens.ConvertAll(c=>c.Clone());
            
            return node;
        }

    }

}
