using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{	
	private const float DEFAULT_BUTTON_START_X = 0f, 
						DEFAULT_BUTTON_START_Y = 0.9f, 
						DEFAULT_BUTTON_DISTANCE = -0.2f,
						DEFAULT_GUI_START_X = 0.5f, 
						DEFAULT_GUI_START_Y = 0.95f, 
						DEFAULT_GUI_DISTANCE = -0.1f;
	
	private float buttonStartY;
	private float buttonStartX;
	private float guiStartY;
	private float guiStartX;
	
	private Vector3 selectorLocation;
	private Vector3 buttonLocation;
	private Vector3 guiLocation;
	
	private float cameraSize;
	private Vector3 scale;
	private GUIText[] optionsGUIText;

	private GameObject[] buttons;
	private int currentButton = 0;
	private int maxButtons;
	private float buttonWidth = 1;

	// Inspector Variables
	public Camera cameraReference;
	public GameObject button;
	public GUIText guiTextReference;
	public string[] menuOptionText;
	public string[] targetScene;
	
	public bool justifyLeft, 
				justifyRight,
				centerVertically = true;

	public ParticleSystem particles;

	void Start () 
	{
		maxButtons = menuOptionText.Length;
		//Set the starting position of the menu based on user input from the inspector
		setStartingPositions();

		//Get the current camera's size and scale accordingly
		cameraSize = cameraReference.camera.orthographicSize;
		scale = new Vector3(1,cameraSize * 0.15f,1);
		//Declare the buttons and text
		buttons = new GameObject[maxButtons];
		optionsGUIText = new GUIText[maxButtons];
		
		//Create text and buttons, scaled and positioned
		for (int i = 0; i < maxButtons; i++)
		{
			guiLocation.y =  guiStartY + DEFAULT_GUI_DISTANCE * i;
			optionsGUIText[i] = Instantiate(guiTextReference, guiLocation, Quaternion.identity) as GUIText;
			optionsGUIText[i].text = menuOptionText[i];
			optionsGUIText[i].name = ("Text" + i);

			buttonLocation.y = buttonStartY + DEFAULT_BUTTON_DISTANCE * i;
			buttons[i] = Instantiate(button, buttonLocation * cameraSize, Quaternion.identity) as GameObject;
			buttonWidth = menuOptionText[i].Length;
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
			particles.particleSystem.Stop();
			particles.particleSystem.Play();
			currentButton--;
			if (currentButton < 0) currentButton = maxButtons - 1;
		}
		if (Input.GetButtonDown("N"))
		{
			particles.particleSystem.Stop();
			particles.particleSystem.Play();
			currentButton++;
			if (currentButton > maxButtons - 1) currentButton = 0;
		}

		// Change the selector location to the next button
		selectorLocation.x = buttonStartX * cameraSize;
		selectorLocation.y = (buttons[currentButton].gameObject.transform.position.y);
		gameObject.transform.position = selectorLocation;
		particles.transform.position = selectorLocation;
	}

	void setStartingPositions()
	{
		if (justifyLeft)
		{
			buttonStartX = -1.4f;
			guiStartX = 0.1f;
		}
		else if (justifyRight)
		{
			buttonStartX = 1.4f;
			guiStartX = 0.9f;
		} 
		else
		{
			buttonStartX = DEFAULT_BUTTON_START_X;
			guiStartX = DEFAULT_GUI_START_X;
		}
		if (centerVertically)
		{
			setCenterHeight();
		}
		else
		{
			buttonStartY = DEFAULT_BUTTON_START_Y;
			guiStartY = DEFAULT_GUI_START_Y;
		}
		
		buttonLocation = new Vector3(buttonStartX, buttonStartY, 1);
		selectorLocation = buttonLocation;
		guiLocation = new Vector3(guiStartX, guiStartY, 1);
	}
	
	void setCenterHeight()
	{
		switch (maxButtons)
		{
		case 1: 
			buttonStartY = -0.1f;
			guiStartY = 0.45f;
			break;
		case 2: 
		case 3: 
			buttonStartY = 0.1f;
			guiStartY = 0.55f;
			break;
		case 4: 
		case 5: 
			buttonStartY = 0.3f;
			guiStartY = 0.65f;
			break;
		case 6: 
		case 7: 
			buttonStartY = 0.5f;
			guiStartY = 0.75f;
			break;
		case 8:
		case 9: 
			buttonStartY = 0.7f;
			guiStartY = 0.85f;
			break;
		case 10: 
			buttonStartY = 0.9f;
			guiStartY = 0.95f;
			break;
		}
	}

}
