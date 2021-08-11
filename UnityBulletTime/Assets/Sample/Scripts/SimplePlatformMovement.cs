using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector3 startingPoint;
    [SerializeField] private Vector3 destination;    
    [SerializeField] private float smoothTime = 0.5f;    

    private Vector3 currentVelocity;
    private bool isGoingToDestination = true;

    private void Start()
    {
        transform.position = startingPoint;
    }

    private void Update()
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
}
