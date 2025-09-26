using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private GameEvent toMenu;

    public void ReturnToMenu()
    {
        toMenu.Notify();
    }
}
