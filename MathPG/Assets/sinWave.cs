using UnityEngine;
using System.Collections;

public class sinWave : MonoBehaviour 
{
	public float x,y;

	void Update () 
	{
		x += 0.1f;
		y = Mathf.Sin(2*(rigidbody2D.transform.position.x));
		rigidbody2D.transform.position = new Vector2(x,y);
	}


}
