using UnityEngine;
using System.Collections;

public class MathFunctions : MonoBehaviour 
{
	public float x,y;
	public int a = 1, b = 1, c = 0;
	public bool reset = false;
	
	void Update () 
	{
		if (reset) resetGrid();
		drawSin(a,b,c);
	}

	void resetGrid()
	{
		x = 0;
		y = 0;
		reset = false;
	}

	void drawSin(int a = 1, int b = 1, int c = 0)
	{
		x += 0.1f;
		y = a * (Mathf.Sin(b * (rigidbody2D.transform.position.x)) + c);
		rigidbody2D.transform.position = new Vector2(x,y);
	}
}
