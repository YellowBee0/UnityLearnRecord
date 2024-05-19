using UnityEngine;

public class Cube : MonoBehaviour
{
    public int GUID;
    // Start is called before the first frame update
    void Start()
    {
        GUID = Global.GUID += 1;
        EventManager.AddEvent("Cube");
        EventManager.ListenForEvent("Cube", this, ((_, obj) => Debug.Log(GUID)));
    }
}
