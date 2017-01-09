using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateARTest : MonoBehaviour 
{

	public Transform target;
	 
	public float distance = 10f;  

	public float xSpeed = 250f;  
	public float ySpeed = 120f;  

	public float yMinLimit = -20;  
	public float yMaxLimit = 80;  

	public float x = 0f;  
	public float y = 0f;  

	public Vector3 oldPosition1 ;  
	public Vector3 oldPosition2 ;  



	void Start () 
	{  
		Vector3 angles = transform.eulerAngles;  
		x = angles.y;  
		y = angles.x;  

//		// Make the rigid body not change rotation  
//		if (rigidbody)  
//			rigidbody.freezeRotation = true;  
//		
		
	}  
	void Update ()   
	{  

		if(Input.touchCount == 1)  
		{  

			if(Input.GetTouch(0).phase==TouchPhase.Moved)  
			{  

				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;  
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;  

			}  
		}  


		if(Input.touchCount >1 )  
		{  

			if(Input.GetTouch(0).phase==TouchPhase.Moved||Input.GetTouch(1).phase==TouchPhase.Moved)  
			{  

				Vector3 tempPosition1 = Input.GetTouch(0).position;  
				Vector3 tempPosition2 = Input.GetTouch(1).position;  
				if(isEnlarge(oldPosition1,oldPosition2,tempPosition1,tempPosition2))  
				{  
					if(distance > 3f)  
					{  
						distance -= 0.5f;      
					}   
				}else  
				{  
					if(distance < 18.5f)  
					{  
						distance += 0.5f;  
					}  
				}  
				oldPosition1=tempPosition1;  
				oldPosition2=tempPosition2;  
			}  
		}  
	}  

	bool isEnlarge( Vector3 oP1 ,Vector3 oP2 , Vector3 nP1 , Vector3 nP2 ) 
	{  
		float leng1 =Mathf.Sqrt((oP1.x-oP2.x)*(oP1.x-oP2.x)+(oP1.y-oP2.y)*(oP1.y-oP2.y));  
		float leng2 =Mathf.Sqrt((nP1.x-nP2.x)*(nP1.x-nP2.x)+(nP1.y-nP2.y)*(nP1.y-nP2.y));  
		if(leng1<leng2)  
		{  
			return true;   
		}
		else  
		{  
			return false;   
		}  
	}  


	void LateUpdate () 
	{  
		if (target) 
		{         

			y = ClampAngle(y, yMinLimit, yMaxLimit);  
			Quaternion rotation = Quaternion.Euler(y, x, 0);  
			var  position = rotation * (new Vector3(0.0f, 0.0f, -distance)) + target.position;  

			transform.rotation = rotation;  
			transform.position = position;  
		}  
	}  


	static float ClampAngle (float angle,float  min ,float max ) 
	{  
		if (angle < -360)  
			angle += 360;  
		if (angle > 360)  
			angle -= 360;  
		return Mathf.Clamp (angle, min, max);  
	}  
}
