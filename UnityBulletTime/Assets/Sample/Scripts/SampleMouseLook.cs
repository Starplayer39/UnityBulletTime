namespace UnityBulletTime.Sample
{
    using UnityBulletTime.Camera;
    using UnityEngine;

    [DisallowMultipleComponent]
    public class SampleMouseLook : MonoBehaviour
    {
        public BulletTimeCameraBase bulletTimeCamera;        

        private void Update()
        {
            if (bulletTimeCamera.m_updateMode == BulletTimeCameraBase.UpdateMode.Update)
            {
                bulletTimeCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
            }
        }

        private void LateUpdate()
        {
            if (bulletTimeCamera.m_updateMode == BulletTimeCameraBase.UpdateMode.LateUpdate)
            {
                bulletTimeCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
            }
        }
    }
}
