using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour {

	public float speed = 2;
	public bool smooth = true;
	public float smoothValue = 3;
	Vector3 startAngle;
	bool isPC = true;

	float angle_y;
	float slipSpeed_y;
	
	void Awake()
	{
		startAngle = transform.localEulerAngles;
	}

	// Use this for initialization
	void Start () 
	{
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			isPC = false;
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Control();	
	}

	public void Init()
	{
		transform.localEulerAngles = startAngle;
	}
	void Control()
	{
		#region PC端
		if (isPC)
		{
			if (Input.GetMouseButton(0))
			{
				slipSpeed_y = Input.GetAxis("Mouse X");
				angle_y -= slipSpeed_y * speed;
			}
		}
		#endregion
		#region 移动端
		if (!isPC)
		{
			if (Input.touchCount > 0)
			{
				if(Input.touchCount == 1)
				{
					Vector2 v = Input.GetTouch(0).deltaPosition;
					slipSpeed_y = v.x;
					angle_y -= slipSpeed_y * speed;
				}
			}
		}
		#endregion
		if (smooth)
		{
			slipSpeed_y = Mathf.Lerp(slipSpeed_y, 0, Time.deltaTime * smoothValue);
			angle_y -= slipSpeed_y * speed;
		}
		Quaternion rotation = Quaternion.Euler(startAngle.x, angle_y, startAngle.z);
		transform.rotation = rotation;
    }
}
