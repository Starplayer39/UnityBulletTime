using System;

namespace UnityBulletTime.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BulletTimeVariable : Attribute
    {
        public bool ShouldMultiplyDeltaTime { get => m_shouldMultiplyDeltaTime; }

        bool m_shouldMultiplyDeltaTime = false;

        /// <param name="shouldMultiplyDeltaTime">Multiply 'Time.deltaTime' to the value on 'Bullet Time' if true</param>
        public BulletTimeVariable(bool shouldMultiplyDeltaTime = false)
        {
            m_shouldMultiplyDeltaTime = shouldMultiplyDeltaTime;
        }
    }
}
