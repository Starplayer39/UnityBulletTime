using UnityEngine;

public class Utility : MonoBehaviour
{
    public static bool IsNearlySame(float value, float valueToCompare, float tolerance=0.0001f)
    {
        float min = valueToCompare - factor;
        float max = valueToCompare + factor;

        return min <= value && value <= max;
    }

    public static bool IsNearlySame(Vector3 value, Vector3 valueToCompare, float tolerance=0.0001f)
    {
        bool b1 = IsNearlySame(value.x, valueToCompare.x, factor);
        bool b2 = IsNearlySame(value.y, valueToCompare.y, factor);
        bool b3 = IsNearlySame(value.z, valueToCompare.z, factor);

        return b1 && b2 && b3;
    }
}
