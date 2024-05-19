using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Framework
{

    public class Components
    {
        public static void Add<T>(object key, Entity entity, Func<Entity, bool> require) where T : Component
        {
            if (entity.components.ContainsKey(key))
            {
                Debug.Log("����Ѵ���");
                return;
            }
            else
            {
                if (require != null && !require.Invoke(entity))
                {
                    Debug.Log("������Ҫ��");
                    return;
                }
                entity.components.Add(key, entity.AddComponent<T>());
            }
        }
    }
}