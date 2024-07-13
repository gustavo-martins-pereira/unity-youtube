using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Referência ao gerenciador de inputs
    public static InputManager instance;

    Vector2 movementInput;
    bool fireInput;
    bool runInput;

    // O "Awake" é chamado 1 frame antes do Start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        fireInput = false;
    }

    // STATIC
    public static Vector2 GetMovementInput()
    {
        return instance.movementInput;
    }

    public static bool GetFireInput()
    {
        return instance.fireInput;
    }

    public static bool GetRunInput()
    {
        return instance.runInput;
    }

    // Sempre que o GameObject se mover no X ou Y ele pega o valor que varia de -1 a 1
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        fireInput = value.isPressed;
    }

    // Sempre que a tecla SHIFT do GameObject for pressionada ele aciona essa função
    public void OnRun(InputValue value)
    {
        runInput = value.isPressed;
    }
}
