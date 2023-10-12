using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


namespace BT
{   
    [CreateAssetMenu()]
    public class BehaviourTree : ScriptableObject
    {
        //root node
        public Node rootNode;
        public Node.State treeState = Node.State.Running;
        //store nodes that not neccesary are attach to rootnode
        public List<Node> nodes = new List<Node>();

        public Node.State Update() {
            if(rootNode.state == Node.State.Running){

                treeState =rootNode.Update();
            }
            return treeState;
            
        }
    
    
    
        public Node CreateNode(System.Type type){
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            nodes.Add(node);

            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;

        }

        public void DeleteNode(Node node){
            nodes.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
        }



        //remember that the action node doesnt have childrens
        public void AddChild(Node parent, Node child){
            
            DecoratorNode decoratorNode =  parent as DecoratorNode;
            if(decoratorNode){
                decoratorNode.child = child;
            }

            RootNode rootNode = parent as RootNode;
            if(rootNode){
                rootNode.children = child;
            }
            
            CompositeNode compositeNode = parent as CompositeNode;
            if(compositeNode){
                //Debug.Log(child);
                compositeNode.childrens.Add(child);
            }
            


        
        }


        public void RemoveChild(Node parent, Node child){
            DecoratorNode decoratorNode =  parent as DecoratorNode;
            if(decoratorNode){
                decoratorNode.child = null;
            }

            RootNode rootNode = parent as RootNode;
            if(rootNode){
                rootNode.children = null;
            }

            CompositeNode compositeNode = parent as CompositeNode;
            if(compositeNode){
                compositeNode.childrens.Remove(child);
            }
        }

        //return empty list
        public List<Node> GetChildrens(Node parent){
            
            List<Node> internalChildren = new List<Node>();
            
            DecoratorNode decoratorNode =  parent as DecoratorNode;
            if(decoratorNode && decoratorNode.child !=null){
                internalChildren.Add(decoratorNode.child);
            }


            RootNode rootNode = parent as RootNode;
            if(rootNode  && rootNode.children !=null){
               internalChildren.Add(rootNode.children);
            }


            CompositeNode compositeNode = parent as CompositeNode;
            if(compositeNode){
                return compositeNode.childrens;
            }

            return internalChildren;
        }



        //clone evrything to dont get error when instatnice object with tree objecets added to them
        public BehaviourTree Clone(){
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();
            return tree;
        }
    
    
    
    }
        



}


