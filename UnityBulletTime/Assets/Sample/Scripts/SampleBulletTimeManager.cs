using UnityBulletTime.BulletTime;
using UnityEngine;

namespace UnityBulletTime.Sample
{
    public class SampleBulletTimeManager : MonoBehaviour
    {
        public static SampleBulletTimeManager Instance;        

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);          
        }

        private void Start()
        {
            TimeManager.Instance.OnBulletTimeEnabled += () => Debug.Log("BulletTime Enabled");
            TimeManager.Instance.OnBulletTimeDisabled += () => Debug.Log("BulletTime Disabled");
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
}
