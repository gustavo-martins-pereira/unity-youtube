using UnityEngine;

public class Shot : MonoBehaviour
{
    public AudioClip hitSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ring"))
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
    