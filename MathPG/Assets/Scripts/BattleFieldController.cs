using UnityEngine;
using System.Collections;

public class BattleFieldController : MonoBehaviour 
{


	void Start () 
	{
		Debug.Log(Screen.width);
		//gameObject.transform.localScale = new Vector3(Screen.width, Screen.height, 1);
	}
	

	void Update () 
	{
	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		other.gameObject.transform.position = new Vector2(0f,0f);
	}
}
