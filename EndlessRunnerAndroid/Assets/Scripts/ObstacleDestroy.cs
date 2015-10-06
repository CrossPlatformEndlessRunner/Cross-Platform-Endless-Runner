using UnityEngine;
using System.Collections;

public class ObstacleDestroy : MonoBehaviour
{

    public float obstacleLifetime = 5.0f;
    private Rigidbody2D body2D;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        Invoke("Destroy", obstacleLifetime);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Destroy()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        body2D.velocity = Vector2.zero;
        body2D.rotation = 0.0f;
        body2D.angularVelocity = 0.0f;
    }
}
