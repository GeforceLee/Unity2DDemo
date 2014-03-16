using UnityEngine;
using System.Collections;

public class ScoreShadow : MonoBehaviour {
	public GameObject guiCopy;

	void Awake(){
		Vector3 behindPos = transform.position;
		behindPos = new Vector3 (guiCopy.transform.position.x, guiCopy.transform.position.y - 0.005f, guiCopy.transform.position.z - 1);
		transform.position = behindPos;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = guiCopy.guiText.text;
	}
}
