using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityBulletTime.Attributes;
using UnityEngine;

namespace UnityBulletTime.BulletTime
{
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

            TimeManager.Instance.OnBulletTimeEnabled += this.OnBulletTimeEnabled;
            TimeManager.Instance.OnBulletTimeDisabled += this.OnBulletTimeDisabled;
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
                        }                        
                    }
                }
            }
        }

        private void OnBulletTimeEnabled()
        {
            //TODO: Start Coroutine 'Recalculate'

            if (m_intFieldContainers != null)
            {

            }

            if (m_floatFieldContainers != null)
            {
                for (int i = 0; i < m_floatFieldContainers.Count; i++)
                {
                    FieldContainer<float> fieldContainer = m_floatFieldContainers[i];

                    if (!(fieldContainer.FieldInfo.GetValue(this).Equals(fieldContainer.LastValue)))
                    {
                        fieldContainer.LastValue = (float)fieldContainer.FieldInfo.GetValue(this);                        
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

            }

            if (m_doubleFieldContainers != null)
            {

            }

            if (m_longFieldContainers != null)
            {

            }

            if (m_shortFieldContainers != null)
            {

            }

            if (m_uintFieldContainers != null)
            {

            }

            if (m_ulongFieldContainers != null)
            {

            }

            if (m_ushortFieldContainers != null)
            {

            }
        }                                            

        private void OnBulletTimeDisabled()
        {
            //TODO: Stop Coroutine 'Recalculate'

            if (m_intFieldContainers != null)
            {

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

            }

            if (m_doubleFieldContainers != null)
            {

            }

            if (m_longFieldContainers != null)
            {

            }

            if (m_shortFieldContainers != null)
            {

            }

            if (m_uintFieldContainers != null)
            {

            }

            if (m_ulongFieldContainers != null)
            {

            }

            if (m_ushortFieldContainers != null)
            {

            }
        }    
        
        private IEnumerator Recalculate()
        {
            //TODO: Calculate the value of the fields that changed
            yield return null;
        }
    }
}
