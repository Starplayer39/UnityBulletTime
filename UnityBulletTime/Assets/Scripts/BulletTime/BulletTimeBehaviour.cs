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

        List<FieldInfo> m_bulletTimeVariables = new List<FieldInfo>();
        List<Type> m_bulletTimeVariableTypes = new List<Type>();
        List<object> m_lastIntegerValues = new List<object>();
        List<BulletTimeVariable> m_bulletTimeVariableAttributes = new List<BulletTimeVariable>();

        protected virtual void Start()
        {

        }

        private void InitBulletTimeVars()
        {
            FieldInfo[] bulletTimeVars = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            
            for (int i = 0; i < bulletTimeVars.Length; i++)
            {
                if (bulletTimeVars[i].IsDefined(typeof(BulletTimeVariable), true))
                {

                }
            }
        }
    }
}
