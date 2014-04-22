using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	public Camera camera;
	private float cameraSize;

	public GameObject button;
	public GUIText guiText;
	public GUIText titleNameText;

	public string[] optionsText;
	public float startingGUILocation, distanceGUIBetween, startingLocation,  distanceBetween;

	private GameObject[] buttons;
	private GUIText[] optionsGUIText;
	private float[] buttonLocations;
	private Vector2 location;
	private int currentButton = 0;
	private int maxButtons;

	void Start () 
	{
		cameraSize = camera.camera.orthographicSize;
		maxButtons = optionsText.Length;
		Debug.Log(maxButtons);
		titleNameText.text = "MathPG";

		buttons = new GameObject[maxButtons];
		optionsGUIText = new GUIText[maxButtons];

		Vector3 location = new Vector3(0f,0f,1);
		Vector3 scale = new Vector3(1,cameraSize * 0.15f,1);

		for (int i = 0; i < maxButtons; i++)
		{
			// Create GUI Text
			location.x = 0.5f;
			location.y = startingGUILocation + i*distanceGUIBetween;
			optionsGUIText[i] = Instantiate(guiText, location, Quaternion.identity) as GUIText;
			optionsGUIText[i].text = optionsText[i];
			optionsGUIText[i].name = ("Text" + i);
			// Create "Buttons"
			location.x = 0;
			location.y = startingLocation + distanceBetween * i;
			buttons[i] = Instantiate(button, location * cameraSize, Quaternion.identity) as GameObject;
			scale.x = cameraSize;
			buttons[i].gameObject.transform.localScale = scale;
			buttons[i].name = ("Button" + i);
		}

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

		location.y = buttons[currentButton].gameObject.transform.position.y;
		gameObject.transform.position = location;
	}
}
