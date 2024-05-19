using UnityEngine;

namespace State
{
    public class IdleState : BaseState
    {
        private Entity entity;
        public IdleState(StateMachine _stateMachine, Entity _entity)
        {
            stateMachine = _stateMachine;
            entity = _entity;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("����IdelState");
        }

        public override void Exit()
        {
            entity.data = "Hellow";
            Debug.Log("�˳�IdelState");
        }

        public override void Update()
        {
            Debug.Log(entity.data);
        }
    }
}
