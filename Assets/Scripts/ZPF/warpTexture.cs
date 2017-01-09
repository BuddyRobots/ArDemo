using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpTexture : MonoBehaviour {

	public Renderer renderer;
	public Material cubeMat;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cubeMat.mainTexture = renderer.material.mainTexture;
	}
}
