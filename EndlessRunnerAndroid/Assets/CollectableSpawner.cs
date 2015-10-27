using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//sorry

public class CollectableSpawner : MonoBehaviour {

    List<GameObject> _obj_pool;

    //prefab stuff
    static public int _num_prefabs = 5;
    public GameObject[] _collectables_prefabs = new GameObject[_num_prefabs];

    //this should be same speed as obstacles
    public int global_speed = 2;

    private int _pool_size = 0;

    public int _spawn_time = 5;
    private float timer = 0.0f;


	// Use this for initialization
	void Start () {
        _obj_pool = new List<GameObject>();
        _pool_size = _collectables_prefabs.Length;
        //cpy paste from yours :P
        for (int i = 0; i < _pool_size; ++i)
        {
            GameObject obj = (GameObject)Instantiate(_collectables_prefabs[i]);
            obj.SetActive(false);
            obj.layer = LayerMask.NameToLayer("Collectables");
            _obj_pool.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > _spawn_time)
        {
            spawn_object();
            timer = 0.0f;
        }

        //collectables move themselves

        //for (int i = 0; i < _pool_size; ++i)
        //{
        //    if (_obj_pool[i].activeInHierarchy)
        //    {
        //        var pos = _obj_pool[i].transform.position;
        //        //each could have unique speed
        //        pos.x -= global_speed * Time.deltaTime;
        //        _obj_pool[i].transform.position = pos;
        //    }
        //}
	}

    //just morphed your code to work with mine :P
    void spawn_object()
    {
        int cur_obj = 0;
        for (; cur_obj < _pool_size; ++cur_obj)
        {
            if (!_obj_pool[cur_obj].activeInHierarchy)
                break;
        }
        //may be buggy
        if (cur_obj == _pool_size)
        {
            Debug.Log("No valid collectables to spawn");
            return;
        }

        GameObject to_spawn = _obj_pool[cur_obj];
        to_spawn.transform.position = gameObject.transform.position;
        to_spawn.transform.rotation = gameObject.transform.rotation;
        to_spawn.SetActive(true);
    }
}
