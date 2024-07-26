using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float speed = 2.0f;
    private float length;
    private float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, length);
        transform.position = new Vector3(startPosition + newPosition, transform.position.y, transform.position.z);
    }
}