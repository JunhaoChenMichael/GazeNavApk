using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using System;
using TMPro;



public class ETTrigger : MonoBehaviour
{
    public Animator buttonMoveAnim;
    private DateTime TriggerTime;
    private bool isFocused;
    private bool isTriggered;
    private bool isPressed;

    private void Start()
    {
        isFocused = false;
        isTriggered = false;
        isPressed = false;
    }

    private void Update(){
        if (!isTriggered && isFocused){
            buttonMoveAnim.SetTrigger("MoveOut");
            isTriggered = true; 
        } else if (!isPressed && isTriggered && TriggerTime < DateTime.Now.AddSeconds(-1)){
            buttonMoveAnim.SetTrigger("MoveIn");
            isTriggered = false;
        }
    }

    public void IsFocused()
    {
        isFocused = true;
        TriggerTime = DateTime.Now;
    }

    public void UnFocused()
    {
        isFocused = false;
    }

    public void IsPressed(){
        isPressed = true;
    }

    public void UnPressed(){
        isPressed = false;
    }
}
