using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private GameEvent toMenu;
    [SerializeField] private GameEvent toGame;

    public void Play()
    {
        toGame.Notify();
    }

    public void ReturnToMenu()
    {
        toMenu.Notify();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
