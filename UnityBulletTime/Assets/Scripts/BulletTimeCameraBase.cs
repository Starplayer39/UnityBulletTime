using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeCameraBase : MonoBehaviour
{
    public GameObject cameraObject;

    protected Camera cameraComponent;

    protected float mouseSensitivityX = 100.0f;
    protected float mouseSensitivityY = 100.0f;

    protected float bulletTimeMultiplier;

    protected virtual void Init()
    {
#if UNITY_EDITOR
        if (cameraObject == null) Debug.LogWarning("Camera Object is null");
#endif

        if (cameraObject != null) cameraComponent = cameraObject.GetComponent<Camera>();

        bulletTimeMultiplier = CalculateMultiplier();
    }

    protected float CalculateMultiplier() => (Time.timeScale - TimeManager.Instance.bulletTimeFactor) / Time.timeScale + Time.timeScale;
}
