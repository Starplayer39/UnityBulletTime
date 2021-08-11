using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float height = 1.0f;

    void Update()
    {
        Vector3 v = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * height, transform.position.z);

        transform.position = v;
    }
}
