using System;
using System.Reflection;
using UnityBulletTime.Attributes;

namespace UnityBulletTime.BulletTime
{
    public class FieldContainer<T>
    {
        public FieldInfo FieldInfo { get => m_fieldInfo; }
        public Type FieldType { get => m_type; }
        public T LastValue { get => m_lastValue; }
        public BulletTimeVariable BulletTimeVariableAttribute { get => m_bulletTimeVariableAttributes; }

        private FieldInfo m_fieldInfo;
        private Type m_type;
        private T m_lastValue;
        private BulletTimeVariable m_bulletTimeVariableAttributes;
    }
}
