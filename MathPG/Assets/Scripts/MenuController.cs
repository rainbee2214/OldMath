using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	public Camera camera;
	public GameObject button;
	public GUIText guiText;
	public string[] optionsText;
	public string[] targetScene;
	public bool centered = true, leftJustified, rightJustified;

	// Everything is scaled to the camera size
	private float cameraSize;



	private const float START_GUI_LOCATION_X = 0.5f;
	private const float START_GUI_LOCATION_Y = 0.95f;
	private const float DISTANCE_BETWEEN_GUI = -0.1f;
	private const float START_LOCATION_X = 0f;
	private const float START_LOCATION_Y = 0.9f;
	private const float	DISTANCE_BETWEEN = DISTANCE_BETWEEN_GUI * 2;

	// Temporary positions for placing everything on screen
	//private float xPosition, yPosition;
	private Vector3 selectorLocation;
	private Vector3 buttonLocation = new Vector3(START_LOCATION_X,START_LOCATION_Y,1);
	private Vector3 guiLocation = new Vector3(START_GUI_LOCATION_X,START_GUI_LOCATION_Y,1);
	private Vector3 scale;


	public bool centeredH, bottomJustified;

	// Starting location is the top middle of the screen by default. 10 options fit on the screen

	private GUIText[] optionsGUIText;

	private float startingLocation, startingGUILocation;

	// Button
	private GameObject[] buttons;
	private float[] buttonLocations;
	private int currentButton = 0;
	private int maxButtons;
	private float buttonWidth = 1;



	void Start () 
	{
		selectorLocation = buttonLocation;

		cameraSize = camera.camera.orthographicSize;
		maxButtons = optionsText.Length;
		buttons = new GameObject[maxButtons];
		optionsGUIText = new GUIText[maxButtons];



		scale = new Vector3(1,cameraSize * 0.15f,1);
	
		//setPosition("GUIText");
		for (int i = 0; i < maxButtons; i++)
		{
			// Create GUI Text. 
			guiLocation.y =  START_GUI_LOCATION_Y + DISTANCE_BETWEEN_GUI * i;
			Debug.Log(guiLocation.x + "," + guiLocation.y);
			optionsGUIText[i] = Instantiate(guiText, guiLocation, Quaternion.identity) as GUIText;
			optionsGUIText[i].text = optionsText[i];
			optionsGUIText[i].name = ("Text" + i);
		}

		//setPosition("Button");
		for (int i = 0; i < maxButtons; i++)
		{
			// Create "Buttons"
			buttonLocation.y = START_LOCATION_Y + DISTANCE_BETWEEN * i;
			buttons[i] = Instantiate(button, buttonLocation * cameraSize, Quaternion.identity) as GameObject;
			buttonWidth = optionsText[i].Length;
			scale.x = (buttonWidth * cameraSize) / 10;
			buttons[i].gameObject.transform.localScale = scale;
			buttons[i].name = ("Button" + i);
		}
	}



	void Update () 
	{
		if (Input.GetButtonDown("Z"))
		{
			Application.LoadLevel(targetScene[currentButton]);
		}
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

		selectorLocation.x = START_LOCATION_X *  cameraSize;
		selectorLocation.y = (buttons[currentButton].gameObject.transform.position.y);
		gameObject.transform.position = selectorLocation;
	}
}
