using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Para a câmera seguir o jogador, é necessário ter uma referência para o objeto que representa o jogador (nesse caso eu quero a posição do jogador (Transform))
    public Transform player;
    public Vector3 offset; // Distância da câmera em relação ao jogador

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    //void Update()
    // Como o jogo da umas pequenas travas para atualizar a posição da câmera em relação ao jogador, a função "LateUpdate" é chamada depois do frame ser renderizado. Atualiza a posição do jogador para depois atualizar a posição da câmera
    void LateUpdate()
    {
        // Pega a posição atual do jogador e adiciona a distância (offset) que foi calculado no início
        transform.position = player.position + offset;
    }
}
