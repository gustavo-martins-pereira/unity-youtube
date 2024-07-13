using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Se um objeto sair do colisor do GameObject no qual esse script foi atrelado ativa a função
    // Um dos objetos PRECISA ter um RigidBody
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
