namespace UnityBulletTime.Utility
{
    using UnityEngine;

    internal static class Utility
    {
        internal static bool IsNearlySame(float value, float valueToCompare, float tolerance = 0.0001f)
        {
            float min = valueToCompare - tolerance;
            float max = valueToCompare + tolerance;

            return min <= value && value <= max;
        }

        internal static bool IsNearlySame(Vector3 value, Vector3 valueToCompare, float tolerance = 0.0001f)
        {
            bool b1 = IsNearlySame(value.x, valueToCompare.x, tolerance);
            bool b2 = IsNearlySame(value.y, valueToCompare.y, tolerance);
            bool b3 = IsNearlySame(value.z, valueToCompare.z, tolerance);

            return b1 && b2 && b3;
        }
    }

}