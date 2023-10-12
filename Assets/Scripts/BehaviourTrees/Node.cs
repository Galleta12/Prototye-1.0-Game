using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BT{
    public abstract class Node : ScriptableObject
    {

        //maybe hide
        
        public enum State{Running, Failure, Succes}
        [HideInInspector]public State state = State.Running;

        [HideInInspector]public bool started = false;

        public string guid;

        //internal positon on the treeview
        [HideInInspector]public Vector2 positon;

        
        public State Update() {
            if(!started){
                OnStart();
                started = true;
            }

            state = OnUpdate();

            if(state == State.Failure || state == State.Succes){
                OnStop();
                started = false;
            }
            
            return state;

        }

        public virtual Node Clone(){
            return Instantiate(this);
        }

        protected abstract void OnStart();
        protected abstract State OnUpdate();
        protected abstract void OnStop();
    
    }

}

