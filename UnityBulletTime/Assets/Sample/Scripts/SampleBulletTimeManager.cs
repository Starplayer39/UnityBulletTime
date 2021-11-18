namespace UnityBulletTime.Sample
{
    using UnityBulletTime.BulletTime.Core;
    using UnityEngine;

    public class SampleBulletTimeManager : MonoBehaviour
    {
        public static SampleBulletTimeManager Instance;
        
        [InspectorName("Log Bullet Time Event")] public bool m_shouldLogBulletTimeEvent = true;        

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);          
        }

        private void Start()
        {
            TimeManager.Instance.OnBulletTimeEnabled += () =>
            {
                if (m_shouldLogBulletTimeEvent) { Debug.Log("BulletTime Enabled"); }
            };

            TimeManager.Instance.OnBulletTimeDisabled += () =>
            {
                if (m_shouldLogBulletTimeEvent) { Debug.Log("BulletTime Disabled"); }
            };
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
