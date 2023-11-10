using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.XR;
using TMPro;
using System;

public class EyeTrackingManager : MonoBehaviour
{
    public Transform Origin;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;
    public LineRenderer lr;
    private Vector3 combineEyeGazeVector;
    private Vector3 combineEyeGazeOriginOffset;
    private Vector3 combineEyeGazeOrigin;
    private Matrix4x4 headPoseMatrix;
    private Matrix4x4 originPoseMatrix;

    private Vector3 combineEyeGazeVectorInWorldSpace;
    private Vector3 combineEyeGazeOriginInWorldSpace;

    private uint leftEyeStatus;
    private uint rightEyeStatus;

    private Vector2 primary2DAxis;

    private RaycastHit hitinfo;

    private Transform selectedObj;
    private Transform pressedObj;

    private string gaze_time;
    private string ungaze_time;
    private DateTime blink_time;

    private int leftEyeBlinkIndex;
    private float leftEyeOpenness;

    private int rightEyeBlinkIndex;
    private float rightEyeOpenness;

    private float pre_leftEyeOpenness;
    private float pre_rightEyeOpenness;
    void Start()
    {
        combineEyeGazeOriginOffset = Vector3.zero;
        combineEyeGazeVector = Vector3.zero;
        combineEyeGazeOrigin = Vector3.zero;
        originPoseMatrix = Origin.localToWorldMatrix;
        gaze_time = null;
        ungaze_time = null;
        pre_leftEyeOpenness = 1;
        pre_rightEyeOpenness = 1;
        blink_time = DateTime.Now.AddSeconds(-1);
        // lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //Offest Adjustment
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxis))
        {

            combineEyeGazeOriginOffset.x += primary2DAxis.x*0.001f;
            combineEyeGazeOriginOffset.y += primary2DAxis.y*0.001f;

        }

        PXR_EyeTracking.GetHeadPosMatrix(out headPoseMatrix);
        PXR_EyeTracking.GetCombineEyeGazeVector(out combineEyeGazeVector);
        PXR_EyeTracking.GetCombineEyeGazePoint(out combineEyeGazeOrigin);
        //Translate Eye Gaze point and vector to world space
        combineEyeGazeOrigin += combineEyeGazeOriginOffset;
        combineEyeGazeOriginInWorldSpace = originPoseMatrix.MultiplyPoint(headPoseMatrix.MultiplyPoint(combineEyeGazeOrigin));
        combineEyeGazeVectorInWorldSpace = originPoseMatrix.MultiplyVector(headPoseMatrix.MultiplyVector(combineEyeGazeVector));

        // lr.SetPosition(0, combineEyeGazeOriginInWorldSpace);
        // lr.SetPosition(1, combineEyeGazeOriginInWorldSpace + 10000*combineEyeGazeVectorInWorldSpace);
        LeftTriggerControl(combineEyeGazeVector);
        RightTriggerControl(combineEyeGazeVector);
        GazeTargetControl(combineEyeGazeOriginInWorldSpace, combineEyeGazeVectorInWorldSpace);

        PXR_EyeTracking.GetLeftEyeGazeOpenness(out leftEyeOpenness);
        PXR_EyeTracking.GetRightEyeGazeOpenness(out rightEyeOpenness);

        BlinkControl(leftEyeOpenness, rightEyeOpenness, pre_leftEyeOpenness, pre_rightEyeOpenness);

        pre_leftEyeOpenness = leftEyeOpenness;
        pre_rightEyeOpenness = rightEyeOpenness;
    }


    void RightTriggerControl(Vector3 vector){
        if (vector.x > 0.35){
            RightTrigger.GetComponent<ETTrigger>().IsFocused();
        } else {
            RightTrigger.GetComponent<ETTrigger>().UnFocused();
        }
    }

    void LeftTriggerControl(Vector3 vector){
        if (vector.x < -0.35){
            LeftTrigger.GetComponent<ETTrigger>().IsFocused();
        } else {
            LeftTrigger.GetComponent<ETTrigger>().UnFocused();
        }
    }

    void GazeTargetControl(Vector3 origin,Vector3 vector)
    {
        Ray ray = new Ray(origin,vector);
        if (Physics.SphereCast(origin,0.0005f,vector,out hitinfo))
        {
            Debug.Log(hitinfo);
            if (selectedObj != null && selectedObj == hitinfo.transform)
            {
                return;
            }
            Debug.Log(hitinfo.collider.transform.tag);
            if (hitinfo.collider.transform.tag.Equals("GazeButton"))
            {
                if (gaze_time is not null)
                {
                    DateTime cur_time = DateTime.Now;
                    DateTime gaze2 = DateTime.Parse(gaze_time).AddSeconds(1);
                    if (cur_time >= gaze2)
                    {
                        if (selectedObj != null)
                        {
                            if (selectedObj.GetComponent<ETObject>() != null)
                                selectedObj.GetComponent<ETObject>().UnFocused();
                            selectedObj = null;
                        }
                        else if (selectedObj == null)
                        {
                            selectedObj = hitinfo.transform;
                            if (selectedObj.GetComponent<ETObject>() != null)
                                selectedObj.GetComponent<ETObject>().IsFocused();
                        }
                        ungaze_time = null;
                    }
                }
                else
                {
                    gaze_time = DateTime.Now.ToString();
                }
            } 
            else
            {
                if (ungaze_time is not null)
                {
                    DateTime cur_time = DateTime.Now;
                    DateTime gaze2 = DateTime.Parse(ungaze_time).AddSeconds(1);
                    if (cur_time >= gaze2)
                    {
                        if (selectedObj != null)
                        {
                            if (selectedObj.GetComponent<ETObject>() != null)
                                selectedObj.GetComponent<ETObject>().UnFocused();
                            selectedObj = null;
                        }
                        gaze_time = null;

                    }
                }
                else
                {
                    ungaze_time = DateTime.Now.ToString();
                }
            }
        }
        else
        {
            if (ungaze_time is not null)
            {
                DateTime cur_time = DateTime.Now;
                DateTime gaze2 = DateTime.Parse(ungaze_time).AddSeconds(1);
                if (cur_time >= gaze2) {
                    if (selectedObj != null)
                    {
                        if (selectedObj.GetComponent<ETObject>() != null)
                            selectedObj.GetComponent<ETObject>().UnFocused();
                        selectedObj = null;
                    }
                }
            }
            else
            {
                ungaze_time = DateTime.Now.ToString();
            }
        }    
    }

    void BlinkControl(float left, float right, float pre_left, float pre_right)
    {

        if (left > 0 && pre_left == 0)
        // if (left > 0 && pre_left == 0 && right > 0 && pre_right == 0)
        {
            DateTime CurBlinkTime = DateTime.Now;
            if (CurBlinkTime < blink_time.AddSeconds(1.5))
            {
                if (selectedObj != null)
                {
                    if (selectedObj.GetComponent<ETObject>().CheckPress())
                    {
                        selectedObj.GetComponent<ETObject>().UnPressed();
                    } else {
                        selectedObj.GetComponent<ETObject>().IsPressed();   
                    }
                }
                
                blink_time = CurBlinkTime.AddSeconds(-1);
            } else
            {
                blink_time = CurBlinkTime;
            }
            
        }
    }
}

/*
// this part only allows one pressed button
if (pressedObj == null)
                    {
                        pressedObj = selectedObj;
                        pressedObj.GetComponent<ETObject>().IsPressed();
                    }
                    else if (pressedObj != selectedObj)
                    {
                        pressedObj.GetComponent<ETObject>().UnPressed();
                        pressedObj = selectedObj;
                        pressedObj.GetComponent<ETObject>().IsPressed();
                    } else if (pressedObj == selectedObj)
                    {
                        pressedObj.GetComponent<ETObject>().UnPressed();
                    }
*/
