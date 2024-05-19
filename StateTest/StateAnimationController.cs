using UnityEngine;

public class StateAnimationController : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddEvent("AnimationTrigger");
    }
    private void StateAnimationTrigger()
    {
        EventManager.PushEvent("AnimationTrigger",this,null);
        Debug.Log("Trigger");
    }
}
