using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour 
{

	public bool isSelected = false;
	public Color activeColour, inactiveColour;

	void OnTriggerEnter2D(Collider2D other)
	{
		
		//Debug.Log(isActive);
		isSelected = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		isSelected = false;
	}

	void Update () 
	{

		if (isSelected)
		{

			renderer.material.color = activeColour;
		}
		else
		{
			renderer.material.color = inactiveColour;
		}
	}
}
