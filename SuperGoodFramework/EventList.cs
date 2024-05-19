using System;

namespace Framework
{
    public class EventList
    {
        private Event head;
        public Delegate this[object key]
        {
            get
            {
                return Find(key)?.eventHandler;
            }
        }
        public void AddHandler(object key, Delegate handler)
        {
            Event _event = Find(key);
            if (_event != null)
            {
                _event.eventHandler = Delegate.Combine(_event.eventHandler, handler);
            }
            else
            {
                head = new Event(head, key, handler);
            }
        }
        public void RemoveHandler(object key, Delegate handler)
        {
            Event _event = Find(key);
            if (_event != null)
            {
                _event.eventHandler = Delegate.Remove(_event.eventHandler, handler);
            }
        }
        private Event Find(object key)
        {
            Event _event = head;
            while (_event != null)
            {
                if (_event.key == key)
                {
                    break;
                }
                _event = _event.next;
            }
            return _event;
        }
        internal sealed class Event
        {
            internal readonly Event next;
            internal readonly object key;
            internal Delegate eventHandler;
            internal Event(Event next, object key, Delegate eventHandler)
            {
                this.next = next;
                this.key = key;
                this.eventHandler = eventHandler;
            }
        }
    }

}
