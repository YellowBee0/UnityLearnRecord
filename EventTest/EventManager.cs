using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    /// <summary>
    /// �������ָ��¼��ļ����ߣ�Action���һ��������ָ�¼�������sender��
    /// </summary>
    private struct Date
    {
        public Component listener;
        public Action<Component, object> action;
    }
    /// <summary>
    /// �������¼��ֵ�
    /// </summary>
    private static readonly Dictionary<string, List<Date>> Events = new();
    /// <summary>
    /// ����¼����µ��¼�Ĭ��Ϊ�յģ���Ҫʹ��ListenerForEvent��ע��
    /// </summary>
    /// <param name="_name">�¼���</param>
    public static void AddEvent(string _name)
    {
        if (!Events.ContainsKey(_name))
            Events.Add(_name, new List<Date>());
    }
    /// <summary>
    /// ע������¼�
    /// </summary>
    /// <param name="_name">�¼���</param>
    /// <param name="_listener">������</param>
    /// <param name="_action">���¼�����ִ�е�ί��</param>
    public static void ListenForEvent(string _name, Component _listener, Action<Component, object> _action)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
            events.Add(new Date { listener = _listener, action = _action });
    }
    /// <summary>
    /// �Ƴ�һ���¼��ļ����ߣ��ü����߲�������Ӧ���¼�
    /// </summary>
    /// <param name="_name">�¼���</param>
    /// <param name="_listener">������</param>
    public static void RemoveEventFromListener(string _name, Component _listener)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
            events.RemoveAll(e => e.listener == _listener);
    }
    /// <summary>
    /// �Ƴ�һ�������ߣ��ü����߲�����Ӧ�κ��¼�
    /// </summary>
    /// <param name="_listener">������</param>
    public static void RemoveListener(Component _listener)
    {
        foreach (List<Date> events in Events.Values)
            events.RemoveAll(e => e.listener == _listener);
    }
    /// <summary>
    /// �Ƴ��¼�
    /// </summary>
    /// <param name="_name"></param>
    public static void RemoveEvent(string _name)
    {
        if (Events.ContainsKey(_name))
            Events.Remove(_name);
    }
    /// <summary>
    /// ����ʱ�䣬�¼����������м������¼������߶���ִ�ж�Ӧ�Ĵ���
    /// </summary>
    /// <param name="_name">�¼���</param>
    /// <param name="_sender">������</param>
    /// <param name="_date">�����ߴ������Ϣ</param>
    public static void PushEvent(string _name, Component _sender, object _date)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
        {
            foreach (Date eventDate in events)
                eventDate.action?.Invoke(_sender, _date);
        }
    }
}
