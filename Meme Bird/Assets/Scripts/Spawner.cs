using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    
    private float SpawnRate = 1.2f;
    private float minHeight = -2f;
    private float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),SpawnRate,SpawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (Player.isStarted == true)
        {
            GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); 
        }
    }
}
