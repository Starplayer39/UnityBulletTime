using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.StartBulletTime();
            return;
        }

        if (Input.GetMouseButtonDown(0) && TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.StopBulletTime();
            return;
        }

        if (Input.GetMouseButtonDown(1) && !TimeManager.Instance.isBulletTime)
        {
            TimeManager.Instance.DoBulletTime();
            return;
        }
    }
}
