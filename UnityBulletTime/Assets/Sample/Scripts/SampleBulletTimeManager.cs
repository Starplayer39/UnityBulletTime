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
        if (SampleInputManager.Instance.isLeftMouseButtonDown && !TimeManager.Instance.IsBulletTime)
        {
            TimeManager.Instance.StartBulletTime();
            return;
        }

        if (SampleInputManager.Instance.isLeftMouseButtonDown && TimeManager.Instance.IsBulletTime)
        {
            TimeManager.Instance.StopBulletTime();
            return;
        }

        if (SampleInputManager.Instance.isRightMouseButtonDown && !TimeManager.Instance.IsBulletTime)
        {
            TimeManager.Instance.DoBulletTime();
            return;
        }
    }
}
