using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public enum COLLECTABLE_TYPE
    {
        SHIELD,
        SCORE_MUTLIPLIER,
    }

    public COLLECTABLE_TYPE collectableType;
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
        if (col.CompareTag("Player"))
        {
            Player thePlayer = col.GetComponent<Player>();
            switch (collectableType)
            {
                case COLLECTABLE_TYPE.SHIELD:
                    {
                        thePlayer.EnableShield();
                        break;
                    }
                case COLLECTABLE_TYPE.SCORE_MUTLIPLIER:
                    {
                        thePlayer.ScoreMultiplierEnabled = true;
                        break;
                    }
                default:
                    break;
            }
            print("collecting");
            gameObject.SetActive(false);
        }
        //needs to add points somewhere
    }
}
