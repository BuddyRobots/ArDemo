using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUV : MonoBehaviour {
	
	public Mesh mesh; 
	private Vector2[] uvs;

	void Start()
	{ 
		uvs = mesh.uv;
		/*for (var i = 0; i < uvs.Length; i++)
			Debug.Log(uvs[i]);*/
		Debug.Log(uvs.Length);
	}

	void Update() 
	{
		// Upper right quarter 
		if (Input.GetKeyDown(KeyCode.A))
		{
			uvs[0] = new Vector2((float)0.5, (float)0.5);
			uvs[1] = new Vector2((float)1.0, (float)0.5);
			uvs[2] = new Vector2((float)0.5, (float)1.0);
			mesh.uv = uvs;
			Debug.Log("a");
		}

		// Middle quater
		if (Input.GetKeyDown(KeyCode.B))
		{
			uvs[0] = new Vector2((float)0.25, (float)0.25);
			uvs[1] = new Vector2((float)0.75, (float)0.25);
			uvs[2] = new Vector2((float)0.25, (float)0.75);
			uvs[3] = new Vector2((float)0.75, (float)0.75);
			mesh.uv = uvs;
			Debug.Log("b");
		}

		//Left half
		if (Input.GetKeyDown(KeyCode.C))
		{
			uvs[0] = new Vector2((float)0.0, (float)0.0);
			uvs[1] = new Vector2((float)0.5, (float)0.0);
			uvs[2] = new Vector2((float)0.0, (float)1.0);
			uvs[3] = new Vector2((float)0.5, (float)1.0);
			mesh.uv = uvs;
			Debug.Log("c");
		}

		//A mess
		if (Input.GetKeyDown(KeyCode.D))
		{
			uvs[0] = new Vector2((float)0.25, (float)0.55);
			uvs[1] = new Vector2((float)0.0, (float)0.1);
			uvs[2] = new Vector2((float)0.7, (float)0.2);
			uvs[3] = new Vector2((float)0.4, (float)0.6);
			mesh.uv = uvs;
			Debug.Log("d");
		}
	}
}