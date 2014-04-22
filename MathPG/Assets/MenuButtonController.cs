using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour 
{
	public bool isActive = false;
	public Color activeColour, inactiveColour;

	void Start () 
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		isActive = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		isActive = false;
	}

	void Update () 
	{
		if (isActive)
		{
			renderer.material.color = activeColour;
		}
		else
		{
			renderer.material.color = inactiveColour;
		}
	}
}
