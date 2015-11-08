//Author: Callum Buerckner 2015
using UnityEngine;
using System.Collections;

//attach to camera

public class CameraTracking : MonoBehaviour {

	//target
	[SerializeField]
	public GameObject m_targ;

	void Start () {
	}
	
	void LateUpdate () {
		//follow x, ignore y, z
		transform.position = new Vector3(m_targ.transform.position.x, transform.position.y, transform.position.z);
	}
}
