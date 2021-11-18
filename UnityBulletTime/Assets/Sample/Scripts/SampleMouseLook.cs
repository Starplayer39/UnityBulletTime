namespace UnityBulletTime.Sample
{
    using UnityBulletTime.BulletTime.Camera;
    using UnityEngine;

    [DisallowMultipleComponent]
    public class SampleMouseLook : MonoBehaviour
    {
        public BulletTimeCameraBase bulletTimeCamera;

        private void Update()
        {
            bulletTimeCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
        }
    }
}
