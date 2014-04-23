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

	// Temporary positions for placing everything on screen
	private float xPosition, yPosition;
	private Vector3 location;
	private Vector3 scale;

	// Starting location is the top middle of the screen by default. 10 options fit on the screen
	private float 	startingGUILocation = 0.95f, distanceGUIBetween = -0.1f, 
					startingLocation = 0.9f,distanceBetween = -0.2f;

	private GUIText[] optionsGUIText;



	// Button
	private GameObject[] buttons;
	private float[] buttonLocations;
	private int currentButton = 0;
	private int maxButtons;
	private float buttonWidth = 1;

	void Start () 
	{
		cameraSize = camera.camera.orthographicSize;
		maxButtons = optionsText.Length;
		buttons = new GameObject[maxButtons];
		optionsGUIText = new GUIText[maxButtons];

		location = new Vector3(xPosition,yPosition,1);
		scale = new Vector3(1,cameraSize * 0.15f,1);
	
		for (int i = 0; i < maxButtons; i++)
		{
			// Create GUI Text. Set
			setPositions("GUIText");
			location.x = xPosition;
			location.y = startingGUILocation + i*distanceGUIBetween;
			optionsGUIText[i] = Instantiate(guiText, location, Quaternion.identity) as GUIText;
			optionsGUIText[i].text = optionsText[i];
			optionsGUIText[i].name = ("Text" + i);
		}
		for (int i = 0; i < maxButtons; i++)
		{
			setPositions("Button");
			// Create "Buttons"
			location.x = xPosition;
			location.y = startingLocation + distanceBetween * i;
			buttons[i] = Instantiate(button, location * cameraSize, Quaternion.identity) as GameObject;
			buttonWidth = optionsText[i].Length;
			scale.x = (buttonWidth * cameraSize) / 10;
			buttons[i].gameObject.transform.localScale = scale;
			buttons[i].name = ("Button" + i);
		}

		setPositions("Selector");
	}

	
	void setPositions(string positionTypeWanted)
	{
		if (positionTypeWanted == "Button")
		{
			if (leftJustified) xPosition = -1.4f;
			else if (rightJustified) xPosition = 1.4f;	
			else xPosition = 0f;
			
		}
		else if (positionTypeWanted == "GUIText")
		{
			if (leftJustified) xPosition = 0.1f;
			else if (rightJustified) xPosition = 0.9f;		
			else xPosition = 0.5f;
			
		}
		else if (positionTypeWanted == "Selector")
		{
			if (leftJustified) xPosition = -1.4f;
			else if (rightJustified) xPosition = 1.4f;	
			else xPosition = 0f;
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

		location.x = xPosition *  cameraSize;

		location.y = buttons[currentButton].gameObject.transform.position.y;
		gameObject.transform.position = location;


	}
}
