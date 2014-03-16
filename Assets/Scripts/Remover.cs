using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {
	public GameObject splash;


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf){
				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			}

			Instantiate(splash,col.transform.position,col.transform.rotation);

			Destroy(col.gameObject);

			StartCoroutine("ReloadGame");
			Debug.Log("new game");
		}else{
			Instantiate(splash,col.transform.position,transform.rotation);

			Destroy(col.gameObject);
		}
	}
	

	IEnumerator ReloadGame(){
		Debug.Log("ReloadGame");
		yield return new WaitForSeconds(2);
		Debug.Log("ReloadGame 111");
		Application.LoadLevel(Application.loadedLevel);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
