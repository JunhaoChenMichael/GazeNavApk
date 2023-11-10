using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class EnableSeeThrough : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float enableSeeThroughAfter = 1.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        if (mainCamera == null) mainCamera = GetComponent<Camera>();

        if (mainCamera){
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
            mainCamera.backgroundColor = new Color(0,0,0,0);
            StartCoroutine(ToggleSeeThrough(true));
        } else {
            Debug.LogError("Main Camera neeeddddddd.");
        }
    }
    private IEnumerator ToggleSeeThrough(bool enable){
        yield return new WaitForSeconds(enableSeeThroughAfter);
        PXR_Boundary.EnableSeeThroughManual(enable);
    }

    private void OnApplicationPause(bool pause){
        if (!pause){
            PXR_Boundary.EnableSeeThroughManual(true);
        }
    }
}
