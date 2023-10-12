using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
using System;
using UnityEditor.Experimental.GraphView;
public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    
    public Action<NodeView> OnNodeSelected;
    public BT.Node node;
    public Port input;
    public Port output;

    public NodeView(BT.Node node){
        this.node = node;
        this.title = node.name;

        this.viewDataKey = node.guid;

        style.left = node.positon.x;
        style.top = node.positon.y;


        CreateInputPorts();
        CreateOutputPorts();
    }

    private void CreateInputPorts()
    {
        
        if(node is ActionNode){

            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        
        }

        else if(node is CompositeNode){
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));

        }


        else if (node is DecoratorNode){
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));

        }

        else if (node is RootNode){
            //input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));

        }
    

        if(input !=null){
            input.portName = "";
            inputContainer.Add(input);
        }


    
    
    
    }
    private void CreateOutputPorts()
    {
        
        if(node is ActionNode){
           
            //action node doesnt have child
        }

        else if(node is CompositeNode){
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }


        else if (node is DecoratorNode){
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        }

        else if (node is RootNode){
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        }



        if(output !=null){
            output.portName = "";
            outputContainer.Add(output);
        }
    
    
    }


    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        node.positon.x = newPos.xMin;
        node.positon.y = newPos.yMin;
    }

    public override void OnSelected()
    {
        base.OnSelected();
        if(OnNodeSelected !=null){
            OnNodeSelected.Invoke(this);
        }
    }

}
