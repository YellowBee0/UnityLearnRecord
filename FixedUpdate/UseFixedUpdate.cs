using UnityEngine;
namespace LearnFixedUpdate
{
    public class UseFixedUpdate : MonoBehaviour
    {
        private Rigidbody2D rb;
        //private BoxCollider2D bc;
        [SerializeField] private float speed;
        private float XInput=> Input.GetAxisRaw("Horizontal");
        private float YInput=> Input.GetAxisRaw("Vertical");
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            //bc = GetComponent<BoxCollider2D>();
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(XInput * speed, YInput * speed);
        }
        private void Update()
        {
            //rb.velocity = new Vector2(XInput * speed, YInput * speed);
/*            XInput = Input.GetAxisRaw("Horizontal");
            YInput = Input.GetAxisRaw("Vertical");*/
        }
    }
}

