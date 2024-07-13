using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Properties
    public float speed = 40; // Velocidade da movimentação do Player
    public float horizontalLimit = 35; // Limite horizontal (- e +) de até onde o Player consegue ir
    public Transform shotSpawnPoint; // Local de spawn do 
    
    //Bullet
    public Rigidbody shotPrefab;
    public float bulletSpeed = 75f;

    public GameObject ringSpawn;
    public AudioSource music;
    public AudioClip shootSound, gameOverSound;

    AudioSource audioSource;
    
    // Quando "transform": Pega o transform do GameObject onde o script está atrelado
    // Quando "Transform": Pega a classe "Transform" em si
    //public Transform property;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = InputManager.GetMovementInput().x; // Verifica se o input lateral (A ou D) está sendo pressionado e pega o valor (-1, 0 ou 1)
        transform.Translate(new Vector3(horizontal, 0, 0) * Time.deltaTime * speed); // Movimenta o Player de acordo com o valor

        // Verifica se o jogador está no limite da tela
        if(transform.position.x < -horizontalLimit) // Caso esteja mais para a esquerda...
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z); // Força a posição X para o limite esquerdo (-)
        }
        else if(transform.position.x > horizontalLimit) // Caso esteja mais para a direita...
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z); // Força a posição X para o limite direito (+)
        }

        // Verifica se o jogador apertou o botão de tiro (Left Click) e cria uma nova instância de um objeto "Shot"
        if (InputManager.GetFireInput())
        {
            Rigidbody newBullet = Instantiate(shotPrefab, shotSpawnPoint.position, Quaternion.identity); // A função "Instantiate" cria um GameObject inteiro baseado em um outro GameObject, neste caso ele vai ser posicionado na coordenada X: 0, Y: 0 e Z: 1, o "Quaternion.identity" reseta a rotação do GameObject, zerando ela
            newBullet.velocity = new Vector3(0, 0, bulletSpeed);

            // Fazer o som do tiro continuar, pois o padrão é o som parar e ser executado de novo
            audioSource.PlayOneShot(shootSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MoverRing moverRing = other.GetComponent<MoverRing>(); // Se o "other" tiver um component "MoverRing" ele pega esse componente, caso contrário, o valor será nulo
        
        if(moverRing != null)
        {
            moverRing.speed = 0;

            music.Stop();
            audioSource.PlayOneShot(gameOverSound);

            Destroy(ringSpawn);
            
            speed = 0;
        }
    }
}
