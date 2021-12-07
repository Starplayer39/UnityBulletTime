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
            bulletTimeCamera.Look(SampleInputManager.Instance.mouseX, SampleInputManager.Instance.mouseY);
        }
    }
}
