using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public static GameController gameController;
	public GUIText scoreText, currentOperatorText;
	
	#region Properties
	private string currentOperator;
	public string CurrentOperator
	{
		get {return currentOperator;}
		set {currentOperator = value;}
	}
	private int score = 0;
	public int Score
	{
		get{return score;}
		set{score += value;}
	}
	
	private int currentNumber = 0;
	public int CurrentNumber
	{
		get{return currentNumber;}
		set{currentNumber = value;}
	}
	
	private bool playerDead = false;
	public bool PlayerDead
	{
		get{return playerDead;}
		set{playerDead = value;}
	}

	private float speed = 5;
	public float Speed 
	{
		get{return speed;}
		set{speed = value;}
	}
	#endregion

	void Start () 
	{

	}

	void Awake () 
	{
		//if control is not set, set it to this one and allow it to persist
		if (gameController == null)
		{
			DontDestroyOnLoad(gameObject);
			gameController = this;
		}
		//else if control exists and it isn't this instance, destroy this instance
		else if(gameController != this)
		{
			//Debug.Log ("Game control already exists, deleting this new one");
			Destroy (gameObject);
		}
	}

	void Update () 
	{
		if (Application.loadedLevelName == "TitleScreen") 
		{
			currentOperatorText.text = ("Operator: " + currentOperator);
			scoreText.text = ("Score: " + GameController.gameController.Score);
		}
		else
		{
			scoreText.text = "";
			currentOperatorText.text = "";
		}

	}

}
