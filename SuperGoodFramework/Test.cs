using UnityEngine;

namespace Framework
{
    public class Test : MonoBehaviour, IComponentReset
    {
        private Move move;
        public void UseMove(Entity entity)
        {
            if (move == null)
            {
                Component cmp = entity.components[Keys.c_move];
                if (cmp)
                {
                    move = cmp as Move;
                }
                else
                {
                    return;
                }
            }
            move.SetX(1);
        }
        public void Reset()
        {
            move = null;
        }
        public static bool Require(Entity entity)
        {
            if (!entity.components.ContainsKey(Keys.c_move))
            {
                return false;
            }
            return true;
        }
    }

}
