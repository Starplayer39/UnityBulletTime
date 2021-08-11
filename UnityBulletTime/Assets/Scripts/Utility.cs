using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static bool IsNearlySame(float value, float valueToCompare, float factor)
    {
        float min = valueToCompare - factor;
        float max = valueToCompare + factor;

        return min <= value && value <= max;
    }
}
