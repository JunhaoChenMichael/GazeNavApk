using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class ETButton : ETObject
{
    public Animator buttonAnim;
    public Animator UIAnim;
    public Sprite blueV;
    public Sprite GreyV;
    public Image curImg;
    public GameObject TriggerObject;
    private Renderer targetRenderer;

    private void Start()
    {
       buttonAnim.speed = 0;
    }

    public override void IsFocused()
    {
        base.IsFocused();
        buttonAnim.speed = 1;
    }

    public override void UnFocused()
    {
        base.UnFocused();
        buttonAnim.speed = 0;
    }

    public override void IsPressed()
    {
        base.IsPressed();
        curImg.sprite = blueV;
        buttonAnim.SetTrigger("BlueV");
        UIAnim.SetTrigger("MoveIn");
        TriggerObject.GetComponent<ETTrigger>().IsPressed();
    }

    public override void UnPressed()
    {
        base.UnPressed();
        curImg.sprite = GreyV;
        buttonAnim.SetTrigger("GreyV");
        UIAnim.SetTrigger("MoveOut");
        TriggerObject.GetComponent<ETTrigger>().UnPressed();
    }
}
