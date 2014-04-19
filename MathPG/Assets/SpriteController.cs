using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour 
{
	public bool hasCollided = false;

	void Update () 
	{
		if (Application.loadedLevelName != "TitleScreen")
		{
			renderer.enabled = false;
		}
		else
		{
			renderer.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		hasCollided = true;

	}
}
