using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour
{
    public Vector2 scrollSpeed;
    public Vector2 speedIncreasePerSecond = Vector2.zero;
    private Renderer rendererOne = null;
    // Use this for initialization
    void Start()
    {
        rendererOne = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollSpeed += speedIncreasePerSecond * Time.deltaTime;
    }

    void LateUpdate()
    {
        rendererOne.material.mainTextureOffset = scrollSpeed * Time.time;
    }
}