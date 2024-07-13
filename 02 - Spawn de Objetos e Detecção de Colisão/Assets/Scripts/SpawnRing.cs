using UnityEngine;

public class SpawnRing : MonoBehaviour
{
    public GameObject ringPrefab;
    public float horizontalLimit = 35f;
    public Vector2 spawnInterval = new Vector2(1, 2);

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(spawnInterval.x, spawnInterval.y));
    }

    void Spawn()
    {
        Vector3 spawnPosition =  new Vector3(Random.Range(-horizontalLimit, horizontalLimit), transform.position.y, transform.position.z);
        Instantiate(ringPrefab, spawnPosition, ringPrefab.transform.rotation);
        Invoke("Spawn", Random.Range(spawnInterval.x, spawnInterval.y));
    }
}
