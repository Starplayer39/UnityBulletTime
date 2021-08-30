using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMouseLook : MonoBehaviour
{
    public BulletTimeFpsCamera fpsCamera;    

    private void Update()
    {        
        fpsCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
    }
}
