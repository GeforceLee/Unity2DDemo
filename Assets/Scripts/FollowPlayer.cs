using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Vector3 offseet;

	private Transform player;


	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + offseet;
	}
}
