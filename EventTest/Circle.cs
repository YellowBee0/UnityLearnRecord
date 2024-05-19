using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject prefab;
    public Cube cube;
    void Start()
    {
        EventManager.AddEvent("Cube");
        EventManager.AddEvent("Circle");
        EventManager.ListenForEvent("Cube", this, ((_, obj) => Debug.Log(name + _.name + obj.ToString())));
        EventManager.ListenForEvent("Yellow", this, ((_, obj) => Debug.Log("没有的事件回调")));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            EventManager.PushEvent("Cube", this, "YellowBee");
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Instantiate(prefab, new Vector3(Random.Range(-2f, 2f), Random.Range(-5f, 5f), 0f), Quaternion.identity);
        /*        if (Input.GetKeyDown(KeyCode.Mouse1))
                    EventManager.RemoveEventFromListener("Cube", this);*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            EventManager.RemoveEvent("Cube");
        }
    }
}
