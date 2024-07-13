using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Para a c�mera seguir o jogador, � necess�rio ter uma refer�ncia para o objeto que representa o jogador (nesse caso eu quero a posi��o do jogador (Transform))
    public Transform player;
    public Vector3 offset; // Dist�ncia da c�mera em rela��o ao jogador

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    //void Update()
    // Como o jogo da umas pequenas travas para atualizar a posi��o da c�mera em rela��o ao jogador, a fun��o "LateUpdate" � chamada depois do frame ser renderizado. Atualiza a posi��o do jogador para depois atualizar a posi��o da c�mera
    void LateUpdate()
    {
        // Pega a posi��o atual do jogador e adiciona a dist�ncia (offset) que foi calculado no in�cio
        transform.position = player.position + offset;
    }
}
