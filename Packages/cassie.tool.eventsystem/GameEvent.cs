using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> gameEventListeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener)
    {
        gameEventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        gameEventListeners.Remove(listener);
    }

    public void Notify()
    {
        foreach(GameEventListener listener in gameEventListeners) {
            {
                listener.Notify();

            }
        }
    }
}
