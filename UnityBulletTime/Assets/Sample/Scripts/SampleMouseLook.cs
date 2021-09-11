using UnityBulletTime.BulletTimeCamera;
using UnityEngine;

namespace UnityBulletTime.Sample
{
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
