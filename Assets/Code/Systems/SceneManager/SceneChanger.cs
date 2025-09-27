using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
