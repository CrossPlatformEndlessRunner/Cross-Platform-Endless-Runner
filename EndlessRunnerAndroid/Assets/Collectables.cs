using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public int _points_value;

	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacles"), LayerMask.NameToLayer("Collectables")); //layers 9, 10
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //print("collision");
    }
}
