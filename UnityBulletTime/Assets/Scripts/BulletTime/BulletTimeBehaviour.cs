namespace UnityBulletTime.BulletTime.Core
{
    using System;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using UnityBulletTime.Attributes;
    using UnityBulletTime.Data;    
    using UnityEngine;

    public abstract class BulletTimeBehaviour : MonoBehaviour
    {        
        readonly Type m_shortType = typeof(short);
        readonly Type m_ushortType = typeof(ushort);
        readonly Type m_intType = typeof(int);            
        readonly Type m_uintType = typeof(uint);
        readonly Type m_longType = typeof(long);
        readonly Type m_ulongType = typeof(ulong);
        readonly Type m_floatType = typeof(float);
        readonly Type m_doubleType = typeof(double);        
        readonly Type m_vector3Type = typeof(Vector3);        

        List<FieldContainer<short>> m_shortFieldContainers = null;
        List<FieldContainer<ushort>> m_ushortFieldContainers = null;
        List<FieldContainer<int>> m_intFieldContainers = null;
        List<FieldContainer<uint>> m_uintFieldContainers = null;
        List<FieldContainer<long>> m_longFieldContainers = null;
        List<FieldContainer<ulong>> m_ulongFieldContainers = null;
        List<FieldContainer<float>> m_floatFieldContainers = null;
        List<FieldContainer<double>> m_doubleFieldContainers = null;        
        List<FieldContainer<Vector3>> m_vector3FieldContainers = null;        

        protected virtual void Start()
        {            
            InitBulletTimeVars();

            TimeManager.Instance.BulletTimeBehaviourProcessOnBulletTimeEnabled += this.OnBulletTimeEnabled;
            TimeManager.Instance.BulletTimeBehaviourProcessOnBulletTimeDisabled += this.OnBulletTimeDisabled;
        }

        private void InitBulletTimeVars()
        {
            FieldInfo[] bulletTimeVars = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            for (int i = 0; i < bulletTimeVars.Length; i++)
            {                
                if (bulletTimeVars[i].IsDefined(typeof(BulletTimeVariable), true))
                {
                    Attribute attribute = bulletTimeVars[i].GetCustomAttribute(typeof(BulletTimeVariable), true);
                    Type type = bulletTimeVars[i].FieldType;
                    
                    if (attribute != null)
                    {
                        if (type == m_intType)
                        {
                            if (m_intFieldContainers == null) m_intFieldContainers = new List<FieldContainer<int>>();

                            FieldContainer<int> fieldContainer = new FieldContainer<int>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_intFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_floatType)
                        {
                            if (m_floatFieldContainers == null) m_floatFieldContainers = new List<FieldContainer<float>>();

                            FieldContainer<float> fieldContainer = new FieldContainer<float>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                            else
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();
                            
                            m_floatFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_vector3Type)
                        {
                            if (m_vector3FieldContainers == null) m_vector3FieldContainers = new List<FieldContainer<Vector3>>();

                            FieldContainer<Vector3> fieldContainer = new FieldContainer<Vector3>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                            else
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                            m_vector3FieldContainers.Add(fieldContainer);

                            continue;
                        }                        

                        else if (type == m_doubleType)
                        {
                            if (m_doubleFieldContainers == null) m_doubleFieldContainers = new List<FieldContainer<double>>();

                            FieldContainer<double> fieldContainer = new FieldContainer<double>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                            else
                                fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();
                            
                            m_doubleFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_longType)
                        {
                            if (m_longFieldContainers == null) m_longFieldContainers = new List<FieldContainer<long>>();

                            FieldContainer<long> fieldContainer = new FieldContainer<long>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_longFieldContainers.Add(fieldContainer);

                            continue;
                        }                        

                        else if (type == m_shortType)
                        {
                            if (m_shortFieldContainers == null) m_shortFieldContainers = new List<FieldContainer<short>>();

                            FieldContainer<short> fieldContainer = new FieldContainer<short>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_shortFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_uintType)
                        {
                            if (m_uintFieldContainers == null) m_uintFieldContainers = new List<FieldContainer<uint>>();

                            FieldContainer<uint> fieldContainer = new FieldContainer<uint>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_uintFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_ulongType)
                        {
                            if (m_ulongFieldContainers == null) m_ulongFieldContainers = new List<FieldContainer<ulong>>();

                            FieldContainer<ulong> fieldContainer = new FieldContainer<ulong>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_ulongFieldContainers.Add(fieldContainer);

                            continue;
                        }

                        else if (type == m_ushortType)
                        {
                            if (m_ushortFieldContainers == null) m_ushortFieldContainers = new List<FieldContainer<ushort>>();

                            FieldContainer<ushort> fieldContainer = new FieldContainer<ushort>(bulletTimeVars[i], (BulletTimeVariable)attribute, this);

                            if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                                fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                            else
                                fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                            m_ushortFieldContainers.Add(fieldContainer);

                            continue;
                        }               
                    }
                }
            }
        }

        private void OnBulletTimeEnabled()
        {            
            if (m_intFieldContainers != null)
            {
                for (int i = 0; i < m_intFieldContainers.Count; i++)
                {
                    FieldContainer<int> fieldContainer = m_intFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (int)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_floatFieldContainers != null)
            {
                for (int i = 0; i < m_floatFieldContainers.Count; i++)
                {
                    FieldContainer<float> fieldContainer = m_floatFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (float)value;                        
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                    else
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_vector3FieldContainers != null)
            {
                for (int i = 0; i < m_vector3FieldContainers.Count; i++)
                {
                    FieldContainer<Vector3> fieldContainer = m_vector3FieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (Vector3)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                    else
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_doubleFieldContainers != null)
            {
                for (int i = 0; i < m_doubleFieldContainers.Count; i++)
                {
                    FieldContainer<double> fieldContainer = m_doubleFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (double)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                    else
                        fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_longFieldContainers != null)
            {
                for (int i = 0; i < m_longFieldContainers.Count; i++)
                {
                    FieldContainer<long> fieldContainer = m_longFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (long)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_shortFieldContainers != null)
            {
                for (int i = 0; i < m_shortFieldContainers.Count; i++)
                {
                    FieldContainer<short> fieldContainer = m_shortFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (short)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_uintFieldContainers != null)
            {
                for (int i = 0; i < m_uintFieldContainers.Count; i++)
                {
                    FieldContainer<uint> fieldContainer = m_uintFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (uint)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_ulongFieldContainers != null)
            {
                for (int i = 0; i < m_ulongFieldContainers.Count; i++)
                {
                    FieldContainer<ulong> fieldContainer = m_ulongFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (ulong)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            if (m_ushortFieldContainers != null)
            {
                for (int i = 0; i < m_ushortFieldContainers.Count; i++)
                {
                    FieldContainer<ushort> fieldContainer = m_ushortFieldContainers[i];
                    object value = fieldContainer.FieldInfo.GetValue(this);

                    if (!(value.Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (ushort)value;
                    }

                    if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                        fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                    else
                        fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                    fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                }
            }

            StartCoroutine(Recalculate());
        }                                            

        private void OnBulletTimeDisabled()
        {
            StopCoroutine(Recalculate());

            if (m_intFieldContainers != null)
            {
                for (int i = 0; i < m_intFieldContainers.Count; i++)
                {
                    m_intFieldContainers[i].FieldInfo.SetValue(this, m_intFieldContainers[i].LastValue);
                }
            }

            if (m_floatFieldContainers != null)
            {
                for (int i = 0; i < m_floatFieldContainers.Count; i++)
                {                    
                    m_floatFieldContainers[i].FieldInfo.SetValue(this, m_floatFieldContainers[i].LastValue);
                }
            }

            if (m_vector3FieldContainers != null)
            {
                for (int i = 0; i < m_vector3FieldContainers.Count; i++)
                {
                    m_vector3FieldContainers[i].FieldInfo.SetValue(this, m_vector3FieldContainers[i].LastValue);
                }
            }

            if (m_doubleFieldContainers != null)
            {
                for (int i = 0; i < m_doubleFieldContainers.Count; i++)
                {
                    m_doubleFieldContainers[i].FieldInfo.SetValue(this, m_doubleFieldContainers[i].LastValue);
                }
            }

            if (m_longFieldContainers != null)
            {
                for (int i = 0; i < m_longFieldContainers.Count; i++)
                {
                    m_longFieldContainers[i].FieldInfo.SetValue(this, m_longFieldContainers[i].LastValue);
                }
            }

            if (m_shortFieldContainers != null)
            {
                for (int i = 0; i < m_shortFieldContainers.Count; i++)
                {
                    m_shortFieldContainers[i].FieldInfo.SetValue(this, m_shortFieldContainers[i].LastValue);
                }
            }

            if (m_uintFieldContainers != null)
            {
                for (int i = 0; i < m_uintFieldContainers.Count; i++)
                {
                    m_uintFieldContainers[i].FieldInfo.SetValue(this, m_uintFieldContainers[i].LastValue);
                }
            }

            if (m_ulongFieldContainers != null)
            {
                for (int i = 0; i < m_ulongFieldContainers.Count; i++)
                {
                    m_ulongFieldContainers[i].FieldInfo.SetValue(this, m_ulongFieldContainers[i].LastValue);
                }
            }

            if (m_ushortFieldContainers != null)
            {
                for (int i = 0; i < m_ushortFieldContainers.Count; i++)
                {
                    m_ushortFieldContainers[i].FieldInfo.SetValue(this, m_ushortFieldContainers[i].LastValue);
                }
            }
        }    
        
        private IEnumerator Recalculate()
        {
            while (true)
            {
                if (m_intFieldContainers != null)
                {
                    for (int i = 0; i < m_intFieldContainers.Count; i++)
                    {
                        FieldContainer<int> fieldContainer = m_intFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        int castedValue = (int)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (int)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_floatFieldContainers != null)
                {
                    for (int i = 0; i < m_floatFieldContainers.Count; i++)
                    {
                        FieldContainer<float> fieldContainer = m_floatFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {                            
                            continue;
                        }

                        float castedValue = (float)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                        else
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_vector3FieldContainers != null)
                {
                    for (int i = 0; i < m_vector3FieldContainers.Count; i++)
                    {
                        FieldContainer<Vector3> fieldContainer = m_vector3FieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        Vector3 castedValue = (Vector3)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                        else
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_doubleFieldContainers != null)
                {
                    for (int i = 0; i < m_doubleFieldContainers.Count; i++)
                    {
                        FieldContainer<double> fieldContainer = m_doubleFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        double castedValue = (double)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
                        else
                            fieldContainer.CalculatedValue = fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier();

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_longFieldContainers != null)
                {
                    for (int i = 0; i < m_longFieldContainers.Count; i++)
                    {
                        FieldContainer<long> fieldContainer = m_longFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        long castedValue = (long)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (long)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_shortFieldContainers != null)
                {
                    for (int i = 0; i < m_shortFieldContainers.Count; i++)
                    {
                        FieldContainer<short> fieldContainer = m_shortFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        short castedValue = (short)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (short)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_uintFieldContainers != null)
                {
                    for (int i = 0; i < m_uintFieldContainers.Count; i++)
                    {
                        FieldContainer<uint> fieldContainer = m_uintFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        uint castedValue = (uint)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (uint)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_ulongFieldContainers != null)
                {
                    for (int i = 0; i < m_ulongFieldContainers.Count; i++)
                    {
                        FieldContainer<ulong> fieldContainer = m_ulongFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        ulong castedValue = (ulong)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (ulong)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                if (m_ushortFieldContainers != null)
                {
                    for (int i = 0; i < m_ushortFieldContainers.Count; i++)
                    {
                        FieldContainer<ushort> fieldContainer = m_ushortFieldContainers[i];
                        object value = fieldContainer.FieldInfo.GetValue(this);

                        if (value.Equals(fieldContainer.CalculatedValue))
                        {
                            continue;
                        }

                        ushort castedValue = (ushort)value;

                        fieldContainer.LastValue = castedValue;

                        if (fieldContainer.BulletTimeVariableAttribute.ShouldMultiplyDeltaTime)
                            fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * Time.deltaTime * TimeManager.Instance.CalculateMultiplier());
                        else
                            fieldContainer.CalculatedValue = (ushort)Math.Round(fieldContainer.LastValue * TimeManager.Instance.CalculateMultiplier());

                        fieldContainer.FieldInfo.SetValue(this, fieldContainer.CalculatedValue);
                    }
                }

                yield return null;
            }            
        }
    }
}
