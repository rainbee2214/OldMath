using UnityEngine;
using System.Collections;

public class SelectionController : MonoBehaviour 
{
	public int maxButtons;
	public float startingLocation, distanceBetween;

	private Vector2 location;
	private float[] buttonLocations;	// = {-1.5f, -2.5f, -3.5f};
	private int currentButton = 0;

	void Start () 
	{
		buttonLocations = new float[maxButtons];
		for (int i = 0; i < maxButtons; i++)
		{
			buttonLocations[i] = startingLocation + distanceBetween * i;
		}
		location = new Vector2(0f, buttonLocations[currentButton]);
		gameObject.transform.position = location;
	}

	void Update () 
	{
		if (Input.GetButtonDown("M"))
		{
			currentButton--;
			if (currentButton < 0) currentButton = maxButtons - 1;
		}
		if (Input.GetButtonDown("N"))
		{
			currentButton++;
			if (currentButton > maxButtons - 1) currentButton = 0;
		}

		location.y = buttonLocations[currentButton];
		gameObject.transform.position = location;
	}


}
