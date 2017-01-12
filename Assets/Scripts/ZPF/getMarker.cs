using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;


public class getMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		/*string pngPath = @"MyCubeUV";
		Texture2D myTexture = loadPNG(pngPath);
		Mat wholeTexImage = new Mat(myTexture.height, myTexture.width, CvType.CV_8UC4);
		Utils.texture2DToMat(myTexture, wholeTexImage);*/






	

		RenderTexture markTex = GameObject.Find("Region_Capture_Unity").GetComponent<RenderTextureCamera>().CameraOutputTexture;


		Texture2D myTexture2D = new Texture2D(markTex.width, markTex.height);
		RenderTexture.active = markTex;
		myTexture2D.ReadPixels(new UnityEngine.Rect(0, 0, markTex.width, markTex.height), 0, 0);
		myTexture2D.Apply();


		Mat markImage = new Mat(myTexture2D.height, myTexture2D.width, CvType.CV_8UC4);
		Utils.texture2DToMat(myTexture2D, markImage);


		List<Mat> matList = new List<Mat>();
		matList.Add(markImage);
		matList.Add(markImage);
		matList.Add(markImage);

		Mat hconcatImage = new Mat();
		Core.hconcat(matList, hconcatImage);

		matList.Clear();
		matList.Add(hconcatImage);
		matList.Add(hconcatImage);
		matList.Add(hconcatImage);

		Mat vconcatImage = new Mat();
		Core.vconcat(matList, vconcatImage);


		Debug.Log("vconcatImage.size = " + vconcatImage.cols() + " " + vconcatImage.rows());
		Imgproc.resize(vconcatImage, vconcatImage, new Size(1024, 1024));



		Texture2D newTex = new Texture2D(vconcatImage.cols(), vconcatImage.rows(), TextureFormat.ARGB32, false);
		Utils.matToTexture2D(vconcatImage, newTex);

		//Utils.matToTexture2D(markImage, newTex);

		GetComponent<Renderer>().material.mainTexture = newTex;
	}

	private Texture2D loadPNG(string filePath)
	{		
		return Resources.Load<Texture2D>(filePath);
	}

	private void makeTexture(ref Texture wholeTex, ref Texture markTex)
	{
		
	}

}
