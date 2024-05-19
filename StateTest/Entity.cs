using UnityEngine;

namespace State
{
    public class Entity : MonoBehaviour
    {
        public Animator anim;
        public Rigidbody2D rb;
        public string data;
        public StateMachine stateMachine;
        public IdleState idle;
        public MoveState move;
        private void Start()
        {
            data = "Ohohohoh";
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
            stateMachine = new StateMachine();
            idle = new IdleState(stateMachine, this);
            move = new MoveState(stateMachine, this);
            stateMachine.StateInit(idle);
        }
        private void Update()
        {
            stateMachine.Update();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stateMachine.ChangeState(idle);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(data);
                stateMachine.ChangeState(move);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                data = "Yellow Bee";
            }
        }
    }
}