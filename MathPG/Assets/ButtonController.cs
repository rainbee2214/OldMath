using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{
	private MenuButtonController buttons;
	private MenuButtonController button1, button2, button3;

	void Update () 
	{
		button1 = gameObject.GetComponentInChildren<MenuButtonController>();
		Debug.Log(":" + button1);
		button2 = gameObject.GetComponentInChildren<MenuButtonController>();
		Debug.Log(":" + button2);
	}
}
