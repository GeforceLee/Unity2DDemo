using UnityEngine;
using System.Collections;

public class SetParticleSortingLayer : MonoBehaviour {
	public string sotringLayerName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingLayerName =  sotringLayerName;
	}
}
