using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        // SISTEMA ANTIGO DE INPUT
        //// Debug.Log(Time.deltaTime); // "Time.deltaTime": Mostra o intervalo em segundos entre o frame anterior e o atual

        //// Pega o valor do input (-1 até 1)
        //float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");

        //transform.Translate(0, 0, speed * Time.deltaTime * vertical); // O objeto vai se mover 1 unidade por segundo, independente de quantos frames estão sendo renderizados pelo PC (O Time.deltaTime representa 1s)
        //transform.Rotate(0, rotationSpeed * Time.deltaTime * horizontal, 0);

        // SISTEMA NOVO DE INPUT
        float vertical = InputManager.GetMovementInput().y;
        float horizontal = InputManager.GetMovementInput().x;

        transform.Translate(0, 0, speed * Time.deltaTime * vertical);
        transform.Rotate(0, rotationSpeed * Time.deltaTime * horizontal, 0);

        if (InputManager.GetFireInput())
        {
            Debug.Log("Shot!");
        }

        if (InputManager.GetRunInput())
        {
            Debug.Log("Running!");
        }
    }
}
