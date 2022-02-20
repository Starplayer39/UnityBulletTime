namespace UnityBulletTime
{
    using System;
    using System.Collections;    
    using UnityEngine;    

    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        [Header("Bullet Time")]
        [InspectorName("Target Time Scale")] [Range(0.0f, 1.0f)] public float targetTimeScale = 0.05f;
        [InspectorName("Bullet Time Length")] public float bulletTimeLength = 9.0f;
        [InspectorName("Smooth Time")]public float smoothTime = 0.3f;

        public Action OnBulletTimeEnabled;
        public Action OnBulletTimeDisabled;

        internal Action BulletTimeBehaviourProcessOnBulletTimeEnabled;
        internal Action BulletTimeBehaviourProcessOnBulletTimeDisabled;

        public bool IsBulletTime { get => m_isBulletTime; }
        public bool IsSmoothBulletTime { get => m_isBulletTime && m_isCoroutineRunning; }

        private bool m_isBulletTime = false;
        private bool m_isCoroutineRunning = false;
        private float m_initialTimeScale = 1.0f;
        private float m_currentVelocity = 0.0f;

        private void OnEnable() => m_initialTimeScale = Time.timeScale;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }        

        private void Update()
        {
            m_isBulletTime = !UnityBulletTime.Utility.Utility.IsNearlySame(Time.timeScale, 1.0f, 0.001f);
            if (!m_isBulletTime && m_isCoroutineRunning)
            {
                StopCoroutine("RecoverTimeScale");
                m_isCoroutineRunning = false;
                BulletTimeBehaviourProcessOnBulletTimeDisabled();
            }            
        }

        public void EnableBulletTime()
        {
            if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

            if (!m_isBulletTime)
            {
                m_isBulletTime = true;
                Time.timeScale = targetTimeScale;

                if (OnBulletTimeEnabled != null)
                {
                    OnBulletTimeEnabled();
                }

                if (BulletTimeBehaviourProcessOnBulletTimeEnabled != null)
                {
                    BulletTimeBehaviourProcessOnBulletTimeEnabled();
                }
            }
        }

        public void DisableBulletTime()
        {
            if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

            if (m_isBulletTime)
            {
                m_isBulletTime = false;
                Time.timeScale = m_initialTimeScale;

                if (OnBulletTimeDisabled != null)
                {
                    OnBulletTimeDisabled();
                }

                if (BulletTimeBehaviourProcessOnBulletTimeDisabled != null)
                {
                    BulletTimeBehaviourProcessOnBulletTimeDisabled();
                }
            }
        }

        public void DoBulletTime()
        {
            EnableBulletTime();
            StartCoroutine("RecoverTimeScale");
            m_isCoroutineRunning = true;
        }

        public void StartBulletTime()
        {
            EnableBulletTime();
        }

        public void StopBulletTime()
        {
            DisableBulletTime();
        }

        public void StopBulletTimeSmoothly()
        {
            if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

            if (m_isBulletTime)
            {
                Time.timeScale = Mathf.SmoothDamp(Time.timeScale, 1.0f, ref m_currentVelocity, smoothTime);
            }
        }        

        public float CalculateMultiplier()
        {
            if (m_isBulletTime)
                /* 
                 *  As Time.timeScale becomes (p / q) * m_initialTimeScale on Bullet Time. 
                 *  To make value is same as before the Time.timeScale changes, 
                 *  We could just simply multiply m_initialTimeScale / Time.timeScale to the changed value. 
                 *  Because the value after Time.timeScale changed is equal to (p / q) * (original value).
                 */
                return m_initialTimeScale / Time.timeScale;
            else
                return 1.0f;
        }

        IEnumerator RecoverTimeScale()
        {
            while (true)
            {
                if (m_isBulletTime)
                {
                    Time.timeScale += (1.0f / bulletTimeLength) * Time.unscaledDeltaTime;
                    Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
                }

                else break;

                m_isBulletTime = !UnityBulletTime.Utility.Utility.IsNearlySame(Time.timeScale, 1.0f, 0.001f);

                yield return null;
            }
        }
    }
}
