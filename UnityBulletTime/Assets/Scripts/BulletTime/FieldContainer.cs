namespace UnityBulletTime.Data
{
    using System;
    using System.Reflection;    

    internal class FieldContainer<T> where T : struct
    {
        internal FieldInfo FieldInfo { get => m_fieldInfo; }

        internal Type FieldType { get => m_type; }

        internal T LastValue { get => m_lastValue; set => m_lastValue = value; }

        internal T CalculatedValue { get => m_calculatedValue; set => m_calculatedValue = value; }

        internal BulletTimeVariable BulletTimeVariableAttribute { get => m_bulletTimeVariableAttributes; }

        private FieldInfo m_fieldInfo;
        private Type m_type;
        private T m_lastValue;
        private T m_calculatedValue;
        private BulletTimeVariable m_bulletTimeVariableAttributes;    

        internal FieldContainer(FieldInfo fieldInfo, BulletTimeVariable attribute, object obj)
        {
            Init(fieldInfo, attribute, obj);
        }                      
        
        private void Init(FieldInfo fieldInfo, BulletTimeVariable attribute, object obj)
        {
            m_fieldInfo = fieldInfo;
            m_type = m_fieldInfo.FieldType;
            m_bulletTimeVariableAttributes = attribute;
            m_lastValue = (T)m_fieldInfo.GetValue(obj);            
        }
    }
}
