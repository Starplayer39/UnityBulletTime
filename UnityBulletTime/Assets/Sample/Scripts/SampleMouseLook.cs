using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMouseLook : MonoBehaviour
{
    public BulletTimeCameraBase bulletTimeCamera;    

    private void Update()
    {
        bulletTimeCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
    }
}
