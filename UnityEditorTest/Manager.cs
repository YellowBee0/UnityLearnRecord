using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject prefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
            Spawn();
    }
    public void Spawn()
    {
        Instantiate(prefab, new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
    }
}
