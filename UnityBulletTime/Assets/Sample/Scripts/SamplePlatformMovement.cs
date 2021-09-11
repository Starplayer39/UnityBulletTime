using UnityEngine;

namespace UnityBulletTime.Sample
{
    [DisallowMultipleComponent]
    public class SamplePlatformMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private Vector3 startingPoint;
        [SerializeField] private Vector3 destination;
        [SerializeField] private float smoothTime = 0.5f;

        [Header("Sine Wave Movement")]
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float height = 1.0f;
        [SerializeField] private bool sineWaveMovement = false;

        private Vector3 currentVelocity;
        private bool isGoingToDestination = true;

        private void Start()
        {
            transform.position = startingPoint;
        }

        private void Update()
        {
            if (sineWaveMovement) SineWaveMovement();
            else Movement();
        }

        private void Movement()
        {
            if (isGoingToDestination)
            {
                if (Utility.IsNearlySame(transform.position, destination, 0.3f)) isGoingToDestination = false;

                transform.position = Vector3.SmoothDamp(transform.position, destination, ref currentVelocity, smoothTime);
            }

            if (!isGoingToDestination)
            {
                if (Utility.IsNearlySame(transform.position, startingPoint, 0.3f)) isGoingToDestination = true;

                transform.position = Vector3.SmoothDamp(transform.position, startingPoint, ref currentVelocity, smoothTime);
            }
        }

        private void SineWaveMovement()
        {
            Vector3 v = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * height, transform.position.z);

            transform.position = v;
        }
    }
}
