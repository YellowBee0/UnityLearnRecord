using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class Entity : MonoBehaviour
    {
        public Dictionary<object, Component> components;
        public EventList events;
        public Entity()
        {
            components = new Dictionary<object, Component>();
            events = new EventList();
        }
        public event FirstEventHandler First
        {
            add => events.AddHandler(Keys.e_first, value);
            remove => events.RemoveHandler(Keys.e_first, value);
        }
        public void OnFirst(string data, FirstEventArgs e)
        {
            ((FirstEventHandler)events[Keys.e_first])?.Invoke(data, this, e);
        }
    }
}
