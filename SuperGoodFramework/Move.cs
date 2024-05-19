using UnityEngine;
namespace Framework
{
    public class Move : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float speed;
        public void Init(float speed, Rigidbody2D rb)
        {
            this.speed = speed;
            this.rb = rb;
        }
        public void SetX(float dir)
        {
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        }
        public static bool Require(Entity entity)
        {
            if (!entity.components.ContainsKey(Keys.c_rb))
            {
                return false;
            }
            return true;
        }
    }
}
