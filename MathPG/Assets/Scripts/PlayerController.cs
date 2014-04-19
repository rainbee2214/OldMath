using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	public GameObject[] prefabs;
	public Sprite[] sprites;

	private SpriteRenderer renderer;
	private string lastCollision;
	private Vector2 movement;

	private int self;	// Self is a value between 0 and 99. It is temporary and is used to determine the next current value of the player. It is basically just space for the number to be manipulated.
	private int nextNumber;
	private bool add = false;
	private bool subtract = false;
	private bool multiply = false;
	private bool divide = false;

	private GameObject temp1, temp2, temp3;


	private Vector2 direction;
	void Start () 
	{
		renderer = gameObject.GetComponent<SpriteRenderer>();
		renderer.sprite = sprites[GameController.gameController.CurrentNumber];

	}

	void Update()
	{
		renderer.sprite = sprites[GameController.gameController.CurrentNumber];
	}

	void FixedUpdate () 
	{
		movement.x = Input.GetAxis ("Horizontal") * GameController.gameController.Speed;
		movement.y = Input.GetAxis ("Vertical") * GameController.gameController.Speed;
		rigidbody2D.velocity = movement;
	}

	void startBattle(int currentNumber)
	{
		Application.LoadLevel("Battle" + currentNumber);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag != "Show" && other.tag != "Edge") GameController.gameController.Score = 1;
		if (other.tag != "Show")
		{
			if (other.tag == "=")
			{
				startBattle(GameController.gameController.CurrentNumber);
			}
			// If it's an operator
			if (other.tag == "+" || other.tag == "-" || other.tag == "multiply" || other.tag == "divide") 
			{
				changeOperator(other.tag);
				lastCollision = other.tag;
				
			}
			
			// If it's a number
			if (other.tag == "1" || other.tag == "2" || other.tag == "3" ||
			    other.tag == "4" || other.tag == "5" || other.tag == "6" ||
			    other.tag == "7" || other.tag == "8" || other.tag == "9" ||
			    other.tag == "0")
			{
				nextNumber = int.Parse(other.tag);
				if (add) self += nextNumber;
				if (subtract) self -= nextNumber;
				if (multiply) 
				{
					showProduct(GameController.gameController.CurrentNumber, nextNumber);
					int temp = self % 10;
					self = temp * nextNumber;
				}
				if (divide) 
				{
					showDividend(GameController.gameController.CurrentNumber, nextNumber);
					int temp = self % 10;
					self = temp / nextNumber;
				}

				// Update the players current number and the self
				if (self < 0) self = 100 - Mathf.Abs(self);
				if (self > 99) self = self - 100;
				GameController.gameController.CurrentNumber = self % 10;
			}
			
			if(other.tag != "Edge") Destroy(other.gameObject);

		}
	}

	void changeOperator(string operatorName)
	{
		add = false;
		subtract = false;
		multiply = false;
		divide = false;
		switch(operatorName)
		{
		case "+": add = true; break;
		case "-": subtract = true; break;
		case "multiply": multiply = true; break;
		case "divide": divide = true; break;
		}
	}

	void showProduct(int self, int nextNumber)
	{
		int product = self * nextNumber;
		direction = transform.position;
		direction.y += 1;
		direction.x += 0.5f;
		temp1 = Instantiate(prefabs[product % 10], direction, Quaternion.identity) as GameObject;
		direction.x += -1;
		if (product / 10 != 0) temp2 = Instantiate(prefabs[product / 10], direction, Quaternion.identity) as GameObject;
		
	}
	
	void showDividend(int self, int nextNumber)
	{
		int dividend = self / nextNumber;
		int mod = self % nextNumber;
		direction = transform.position;
		direction.y += 1;
		direction.x += 0.5f;
		temp1 = Instantiate(prefabs[10], direction, Quaternion.identity) as GameObject;
		direction.x += -1;
		temp2 = Instantiate(prefabs[dividend], direction, Quaternion.identity) as GameObject;
		direction.x += 2f;
		temp3 = Instantiate(prefabs[mod], direction, Quaternion.identity) as GameObject;
		temp3.transform.localScale = new Vector3(.75f, .75f, 1);
		
	}
}
