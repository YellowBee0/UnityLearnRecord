using System;
using System.Collections.Generic;

namespace LearnBehaviorTree
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public enum Status
    {
        Success,
        Failure,
        Running,
        Invalid
    }
    /// <summary>
    /// �ڵ�Ļ��࣬��Ϊ�����нڵ㶼�̳д���
    /// �����δ������Ϊ�˱�֤���нڵ㶼��һ��Execute��������֤�ݹ�ʹ�ã�
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// ÿ���ڵ㶼��Ҫʵ�ֵķ����������ݹ�
        /// </summary>
        /// <returns></returns>
        public abstract Status Execute();
    }
    /// <summary>
    /// ��Ϊ�ڵ㣬û���ӽڵ㣬��ΪҶ�ӽڵ�ʹ��
    /// </summary>
    public class ActionNode : Node
    {
        private Func<Status> action;
        public ActionNode(Func<Status> action)
        {
            this.action = action;
        }
        /// <summary>
        /// �¼�Ϊ�շ���Failure�����߷����¼����
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
    /// �����ڵ㣬��ΪҶ�ӽڵ㣬û���ӽڵ�
    /// </summary>
    public class ConditionNode : Node
    {
        private Func<bool> condition;
        public ConditionNode(Func<bool> condition)
        {
            this.condition = condition;
        }
        /// <summary>
        /// ʱ��Ϊ�շ���Failure�����߷���Ϊ������SuccessΪ�ٷ���Failure
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
    /// ѡ��ڵ㣬���ӽڵ㣬�ӽڵ�ȫ��Ϊ����Ϊ�٣�һ��Ϊ���Ϊ�棬�൱��||����
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
                    Console.WriteLine("�ӽڵ����Success");
                    return Status.Success;
                }
                else if (status == Status.Running)
                    return Status.Running;
            }
            Console.WriteLine("�ӽڵ�ȫ��Failure");
            return Status.Failure;
        }
    }
    /// <summary>
    /// ˳��ڵ㣬�ӽڵ�һ��Ϊ����Ϊ�٣�ȫ��Ϊ����Ϊ�棨û���ӽڵ�ҲΪ�٣�
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
                        Console.WriteLine("�ӽڵ����Failure");
                        return Status.Failure;
                    }
                    else if (status == Status.Running)
                        return Status.Running;
                }
                Console.WriteLine("�ӽڵ�ȫ��Success");
                return Status.Success;
            }
            Console.WriteLine("û���ӽڵ�Failure");
            return Status.Failure;
        }
    }
    /// <summary>
    /// ��Ϊ�����ڵ��࣬Ψһ�����нڵ�ĸ��ڵ㣬�������������Ϊ��
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
