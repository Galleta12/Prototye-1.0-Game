using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager
{
    
    private readonly Animator Animator;

    //normal animation
    private const float CrossFadeDuration = 0.1f;

    //blend tree
    private const float AnimatorDampTime = 0.1f;

   
    public  PlayerAnimatorManager(Animator _animator)
    {   
        Animator = _animator;
    }

    public void PlayerTargetAnimation(int targetAnimationNameHash){
        Animator.CrossFadeInFixedTime(targetAnimationNameHash,CrossFadeDuration);
    }

    public void PlayBlendTreeAnimaton(int blendHashName){
        //get into the blend tree animator state
        Animator.CrossFadeInFixedTime(blendHashName,CrossFadeDuration);
    }

    //blend trees
    public void SetBlendAnimation(int blendHashName, float speedChange, float deltaTime){
        Animator.SetFloat(blendHashName, speedChange,AnimatorDampTime ,deltaTime);
    }

    //for bool changes
    public void BoolChangeAnimation(int boolTransistorName, bool stateChange){
        Animator.SetBool(boolTransistorName,stateChange);
    }


    //know if an animation is play
    //we use a tag for this
    //this works on layer 0
    //if the normalized time is lees that 1, it mean that we are playing an animation
    //if it is greater than 0, the current aniamtion is being played
    public float GetNormalizedTime(Animator animator, string tag){
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if(animator.IsInTransition(0) && nextInfo.IsTag(tag)){
            return nextInfo.normalizedTime;

        }
        else if(!animator.IsInTransition(0) && currentInfo.IsTag(tag)){
            return currentInfo.normalizedTime;
        }
        else{
            return 0.0f;
        }
    }


}
