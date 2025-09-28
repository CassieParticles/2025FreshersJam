using UnityEngine;
using UnityEngine.InputSystem;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] GameEvent returnToMenu;

    InputAction input;

    private void Awake()
    {
        input = inputAction.FindAction("Pause");

        input.performed += Return;
    }

    private void Return(InputAction.CallbackContext callback)
    {
        returnToMenu.Notify();
    }
}
