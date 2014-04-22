using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	public GUIText titleNameText, option1Text, option2Text, option3Text;

	void Start () 
	{
		titleNameText.text = "MathPG";
		option1Text.text = "Start Game";
		option2Text.text = "Settings";
		option3Text.text = "Quit";
	}

	void Update () 
	{
	
	}
}
