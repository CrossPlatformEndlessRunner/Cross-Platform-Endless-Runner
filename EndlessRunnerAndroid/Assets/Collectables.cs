using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public int _points_value = 10;
    public float _speed = 0.5f;

	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacles"), LayerMask.NameToLayer("Collectables")); //layers 9, 10
	}
	
	void Update () {
        var pos = transform.position;
        pos.x += -_speed*Time.deltaTime;
        transform.position = pos;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("collecting");
        gameObject.SetActive(false);

        //needs to add points somewhere
    }
}
