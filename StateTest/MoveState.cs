using UnityEngine;
namespace State
{
    public class MoveState : BaseState
    {
        private Entity entity;
        public MoveState(StateMachine _stateMachine, Entity _entity)
        {
            stateMachine = _stateMachine;
            entity = _entity;
        }
        public override void Enter()
        {
            Debug.Log("½øÈëMoveState");
        }

        public override void Exit()
        {
            Debug.Log("ÍË³öMoveState");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                entity.rb.velocity = new Vector2(0, 1);
        }
    }
}
