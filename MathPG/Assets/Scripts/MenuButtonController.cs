using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour 
{

	public bool isActiveB = false;
	public Color activeColour, inactiveColour;

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(isActive);
		isActiveB = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		isActiveB = false;
	}

	void Update () 
	{

		if (isActiveB)
		{
			renderer.material.color = activeColour;
		}
		else
		{
			renderer.material.color = inactiveColour;
		}
	}
}
