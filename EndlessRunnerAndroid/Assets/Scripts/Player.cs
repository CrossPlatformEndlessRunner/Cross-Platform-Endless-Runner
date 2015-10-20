using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private SpriteRenderer playerSprite = null;
    private Vector2[] spriteUVs;

    // Use this for initialization
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        spriteUVs = playerSprite.sprite.uv;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Get sprite based uv animation working; specifically sprite rotation.
        for(int i = 0; i<spriteUVs.Length; ++i)
        {
            spriteUVs[i] = Rotate(spriteUVs[i], 45.0f);
        }
        //gameObject.transform.Rotate(Vector3.forward, 10.0f * Time.deltaTime);
    }

    public Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        return new Vector2(cos * v.x - sin * v.y, sin * v.x + cos *v.y);
    }
}