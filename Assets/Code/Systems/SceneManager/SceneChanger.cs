using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Lose() 
    {
        SceneManager.LoadScene("LoseScene");
    }
}
