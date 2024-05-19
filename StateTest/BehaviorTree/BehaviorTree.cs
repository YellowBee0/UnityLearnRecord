using System;
using System.Collections.Generic;

namespace LearnBehaviorTree
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public enum Status
    {
        Success,
        Failure,
        Running,
        Invalid
    }
    /// <summary>
    /// 节点的基类，行为树所有节点都继承此类
    /// （本段代码仅仅为了保证所有节点都有一个Execute函数，保证递归使用）
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// 每个节点都需要实现的方法，用来递归
        /// </summary>
        /// <returns></returns>
        public abstract Status Execute();
    }
    /// <summary>
    /// 行为节点，没有子节点，作为叶子节点使用
    /// </summary>
    public class ActionNode : Node
    {
        private Func<Status> action;
        public ActionNode(Func<Status> action)
        {
            this.action = action;
        }
        /// <summary>
        /// 事件为空返回Failure，否者返回事件结果
        /// </summary>
        /// <returns></returns>
        public override Status Execute()
        {
            if (action == null)
                return Status.Failure;
            else
                return action.Invoke();
        }
    }
    /// <summary>
    /// 条件节点，作为叶子节点，没有子节点
    /// </summary>
    public class ConditionNode : Node
    {
        private Func<bool> condition;
        public ConditionNode(Func<bool> condition)
        {
            this.condition = condition;
        }
        /// <summary>
        /// 时间为空返回Failure，否者返回为正返回Success为假返回Failure
        /// </summary>
        /// <returns></returns>
        public override Status Execute()
        {
            if (condition == null)
                return Status.Failure;
            else
                return condition.Invoke() ? Status.Success : Status.Failure;
        }
    }
    /// <summary>
    /// 选择节点，有子节点，子节点全部为假则为假，一个为真就为真，相当于||符号
    /// </summary>
    public class SelectNode : Node
    {
        private List<Node> childrens = new List<Node>();
        public void AddChild(Node child)
        {
            childrens.Add(child);
        }
        public void RemoveChild(Node child)
        {
            childrens.Remove(child);
        }
        public override Status Execute()
        {
            foreach (Node node in childrens)
            {
                Status status = node.Execute();
                if (status == Status.Success)
                {
                    Console.WriteLine("子节点出现Success");
                    return Status.Success;
                }
                else if (status == Status.Running)
                    return Status.Running;
            }
            Console.WriteLine("子节点全部Failure");
            return Status.Failure;
        }
    }
    /// <summary>
    /// 顺序节点，子节点一个为假则为假，全部为真则为真（没有子节点也为假）
    /// </summary>
    public class SequenceNode : Node
    {
        private List<Node> childrens = new List<Node>();
        public void AddChild(Node child)
        {
            childrens.Add(child);
        }
        public void RemoveChild(Node child)
        {
            childrens.Remove(child);
        }
        public override Status Execute()
        {
            if (childrens.Count != 0)
            {

                foreach (Node node in childrens)
                {
                    Status status = node.Execute();
                    if (status == Status.Failure)
                    {
                        Console.WriteLine("子节点出现Failure");
                        return Status.Failure;
                    }
                    else if (status == Status.Running)
                        return Status.Running;
                }
                Console.WriteLine("子节点全部Success");
                return Status.Success;
            }
            Console.WriteLine("没有子节点Failure");
            return Status.Failure;
        }
    }
    /// <summary>
    /// 行为树根节点类，唯一是所有节点的根节点，用这个类启动行为树
    /// </summary>
    public class BehaviorTree
    {
        private Node root;
        public void SetRoot(Node root) => this.root = root;
        public void Execute()
        {
            root.Execute();
        }
    }
}
