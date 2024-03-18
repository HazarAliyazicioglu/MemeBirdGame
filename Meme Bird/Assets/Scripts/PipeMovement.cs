using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private float speed = 5f;
    private float leftedge;
    
    // Start is called before the first frame update
    void Start()
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftedge)
        {
            Destroy(gameObject);
        }
    }
}
