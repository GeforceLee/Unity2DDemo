using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 0;


	private PlayerControl playerControl;
	private int prevopisScore = 0;


	void Awake(){
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score;

		if(prevopisScore != score)
			playerControl.StartCoroutine(playerControl.Taunt());

		prevopisScore = score;
	}
}
