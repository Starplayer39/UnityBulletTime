using System;

namespace UnityBulletTime.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class BulletTimeVariable : Attribute
    {
        public bool ShouldMultiplyDeltaTime { get => m_shouldMultiplyDeltaTime; }

        bool m_shouldMultiplyDeltaTime = true;

        /// <param name="shouldMultiplyDeltaTime">Multiply 'Time.deltaTime' to the value on 'Bullet Time' if true</param>
        public BulletTimeVariable(bool shouldMultiplyDeltaTime = false)
        {
            m_shouldMultiplyDeltaTime = shouldMultiplyDeltaTime;
        }
    }
}