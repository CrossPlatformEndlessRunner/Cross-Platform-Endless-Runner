using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{

    public float        spawnSpeed = 400.0f;
    public GameObject   gameObjectPool = null;
    private Vector2     spawnDirection = new Vector2(-1.0f, 0.0f);  // Direction the spawn obstacles will travel in.
    private float       spawnTimer = 0.0f;
    private float       spawnInterval = 4.0f;                       // Time between obstacle spawns in seconds.
    private ObjectPooler objPool;

    // Use this for initialization
    void Start()
    {
        objPool = gameObjectPool.GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            ResetSpawnTimer();
        }
    }

    void ResetSpawnTimer()
    {
        spawnTimer = 0.0f;
    }

    void SpawnObject()
    {
        GameObject obj = objPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

        Vector2 velocity = spawnDirection * spawnSpeed;
        obj.GetComponent<Rigidbody2D>().AddForce(velocity);
    }
}
