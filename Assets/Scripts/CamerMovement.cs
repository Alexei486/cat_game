using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}