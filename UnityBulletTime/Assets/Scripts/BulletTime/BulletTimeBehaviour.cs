using System;
using System.Reflection;
using System.Collections.Generic;
using UnityBulletTime.Attributes;
using UnityEngine;

namespace UnityBulletTime.BulletTime
{
    public abstract class BulletTimeBehaviour : MonoBehaviour
    {
        private Type[] m_variableTypes = new Type[]
        {            
            typeof(short),
            typeof(ushort),            
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(Vector3)
        };

        readonly Type m_shortType = typeof(short);
        readonly Type m_ushortType = typeof(ushort);
        readonly Type m_intType = typeof(int);            
        readonly Type m_uintType = typeof(uint);
        readonly Type m_longType = typeof(long);
        readonly Type m_ulongType = typeof(ulong);
        readonly Type m_floatType = typeof(float);
        readonly Type m_doubleType = typeof(double);
        readonly Type m_decimalType = typeof(decimal);
        readonly Type m_vector3Type = typeof(Vector3);

        List<FieldContainer<short>> m_shortFieldContainers = null;
        List<FieldContainer<ushort>> m_ushortFieldContainers = null;
        List<FieldContainer<int>> m_intFieldContainers = null;
        List<FieldContainer<uint>> m_uintFieldContainers = null;
        List<FieldContainer<long>> m_longFieldContainers = null;
        List<FieldContainer<ulong>> m_ulongFieldContainers = null;
        List<FieldContainer<float>> m_floatFieldContainers = null;
        List<FieldContainer<double>> m_doubleFieldContainers = null;
        List<FieldContainer<decimal>> m_decimalFieldContainers = null;
        List<FieldContainer<Vector3>> m_vector3FieldContainers = null;

        protected virtual void Start()
        {            
            InitBulletTimeVars();
        }

        private void InitBulletTimeVars()
        {
            FieldInfo[] bulletTimeVars = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            for (int i = 0; i < bulletTimeVars.Length; i++)
            {
                if (bulletTimeVars[i].IsDefined(typeof(BulletTimeVariable), true))
                {
                    Attribute attributes = bulletTimeVars[i].GetCustomAttribute(typeof(BulletTimeVariable), true);
                    

                }
            }
        }
    }
}
