using UnityEngine;

namespace Framework
{
    public class GetInput : MonoBehaviour
    {
        public bool left => Input.GetKeyDown(KeyCode.Mouse0);
        public bool right => Input.GetKeyDown(KeyCode.Mouse1);
        public float Xinput => Input.GetAxisRaw("Horizontal");
        public float Yinput => Input.GetAxisRaw("Vertical");
    }
}
