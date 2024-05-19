using UnityEngine;

namespace Framework
{
    public class Player : Entity
    {
        private GetInput input;
        private Move move;
        private Rigidbody2D rb;
        private Test test;
        private void Awake()
        {
            Components.Add<GetInput>(Keys.c_input, this, null);
            Components.Add<Rigidbody2D>(Keys.c_rb, this, null);
            Components.Add<Move>(Keys.c_move, this, Move.Require);
            Components.Add<Test>(Keys.c_test, this, Test.Require);
        }
        private void Start()
        {
            input = GetComponent<GetInput>();
            move = GetComponent<Move>();
            rb = GetComponent<Rigidbody2D>();
            test = GetComponent<Test>();
            rb.gravityScale = 0;
            move?.Init(3, rb);
        }
        private void Update()
        {
            if (move)
            {
                if (input.Xinput != 0)
                {
                    move.SetX(input.Xinput);
                }
                if (input.right)
                {
                    move.speed = 1;
                }
            }
            if (test)
            {
                if (input.left)
                {
                    test.UseMove(this);
                }
            }
        }
    }
}
