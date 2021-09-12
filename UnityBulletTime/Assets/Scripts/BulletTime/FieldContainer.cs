using System;
using System.Reflection;
using UnityBulletTime.Attributes;
using UnityEngine;

namespace UnityBulletTime.BulletTime
{
    internal class FieldContainer<T> where T : struct
    {
        public FieldInfo FieldInfo { get => m_fieldInfo; }

        public Type FieldType { get => m_type; }

        public T LastValue { get => m_lastValue; set => m_lastValue = value; }

        public T CalculatedValue { get => m_calculatedValue; set => m_calculatedValue = value; }

        public BulletTimeVariable BulletTimeVariableAttribute { get => m_bulletTimeVariableAttributes; }

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
