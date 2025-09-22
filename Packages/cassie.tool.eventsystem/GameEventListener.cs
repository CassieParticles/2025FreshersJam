using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent localEvents;

    private void OnEnable()
    {
        gameEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent?.UnregisterListener(this);
    }

    public void Notify()
    {
        localEvents.Invoke();
    }
}
