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

	private int self;
	private int nextNumber;
	private bool add = false;
	private bool subtract = false;
	private bool multiply = false;
	private bool divide = false;

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

	void OnTriggerEnter2D (Collider2D other)
	{
		self = GameController.gameController.CurrentNumber;


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
			if (multiply) self *= nextNumber;
			if (divide) self /= nextNumber;
			//Debug.Log(self);
			if (self < 0) self = 100 - Mathf.Abs(self);
			GameController.gameController.CurrentNumber = self % 10;
		}
		Destroy(other.gameObject);

	}
}
