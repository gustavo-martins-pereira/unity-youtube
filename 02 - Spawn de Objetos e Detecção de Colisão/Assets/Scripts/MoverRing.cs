using UnityEngine;

public class MoverRing : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
