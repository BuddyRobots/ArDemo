using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour,IDragHandler {


	public Transform target;
	private float speed = 0.3f;


	public void OnDrag(PointerEventData eventData)
	{
		Vector3 Vec3rote = new Vector3(eventData.delta.y,-eventData.delta.x);
		target.Rotate(Vec3rote*speed,Space.World);
		//自身轴旋转
		//Vector3 Vec3rote = new Vector3(0, -eventData.delta.x);
		//target.Rotate(Vec3rote * speed, Space.Self);
	}
}

