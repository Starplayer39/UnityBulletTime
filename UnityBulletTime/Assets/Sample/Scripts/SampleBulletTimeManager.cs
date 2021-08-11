using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBulletTimeManager : MonoBehaviour
{
    public static SampleBulletTimeManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        if (SampleInputManager.Instance.isLeftMouseButtonDown && !TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.StartBulletTime();
            return;
        }

        if (SampleInputManager.Instance.isLeftMouseButtonDown && TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.StopBulletTime();
            return;
        }

        if (SampleInputManager.Instance.isRightMouseButtonDown && !TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.DoBulletTime();
            return;
        }
    }
}
