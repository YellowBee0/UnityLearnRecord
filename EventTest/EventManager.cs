using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    /// <summary>
    /// 用来区分该事件的监听者，Action里第一个参数是指事件发布者sender。
    /// </summary>
    private struct Date
    {
        public Component listener;
        public Action<Component, object> action;
    }
    /// <summary>
    /// 单例的事件字典
    /// </summary>
    private static readonly Dictionary<string, List<Date>> Events = new();
    /// <summary>
    /// 添加事件，新的事件默认为空的，需要使用ListenerForEvent来注册
    /// </summary>
    /// <param name="_name">事件名</param>
    public static void AddEvent(string _name)
    {
        if (!Events.ContainsKey(_name))
            Events.Add(_name, new List<Date>());
    }
    /// <summary>
    /// 注册监听事件
    /// </summary>
    /// <param name="_name">事件名</param>
    /// <param name="_listener">监听者</param>
    /// <param name="_action">当事件发生执行的委托</param>
    public static void ListenForEvent(string _name, Component _listener, Action<Component, object> _action)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
            events.Add(new Date { listener = _listener, action = _action });
    }
    /// <summary>
    /// 移除一个事件的监听者，该监听者不会在响应该事件
    /// </summary>
    /// <param name="_name">事件名</param>
    /// <param name="_listener">监听者</param>
    public static void RemoveEventFromListener(string _name, Component _listener)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
            events.RemoveAll(e => e.listener == _listener);
    }
    /// <summary>
    /// 移除一个监听者，该监听者不会响应任何事件
    /// </summary>
    /// <param name="_listener">监听者</param>
    public static void RemoveListener(Component _listener)
    {
        foreach (List<Date> events in Events.Values)
            events.RemoveAll(e => e.listener == _listener);
    }
    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="_name"></param>
    public static void RemoveEvent(string _name)
    {
        if (Events.ContainsKey(_name))
            Events.Remove(_name);
    }
    /// <summary>
    /// 发布时间，事件发布后所有监听该事件监听者都会执行对应的处理
    /// </summary>
    /// <param name="_name">事件名</param>
    /// <param name="_sender">发布者</param>
    /// <param name="_date">发布者传达的信息</param>
    public static void PushEvent(string _name, Component _sender, object _date)
    {
        if (Events.TryGetValue(_name, out List<Date> events))
        {
            foreach (Date eventDate in events)
                eventDate.action?.Invoke(_sender, _date);
        }
    }
}
