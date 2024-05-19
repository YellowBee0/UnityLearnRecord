using UnityEngine;
using UnityEngine.UI;
public class EditorTest : MonoBehaviour
{
    public Image image;
    public float health;
    public float maxHealth;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            AddHealth();
        if (Input.GetKeyDown(KeyCode.Mouse1))
            ReduceHealth();
        image.fillAmount = Mathf.Lerp(image.fillAmount, health / maxHealth, Time.deltaTime * 2);
    }
    public void AddHealth()
    {
        health += 50;
    }
    public void ReduceHealth()
    {
        health -= 25;
    }
}
