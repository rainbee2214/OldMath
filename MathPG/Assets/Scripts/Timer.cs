using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public static float battleLength = 5;
	private float targetTime;
	void Start () 
	{
		targetTime = battleLength + Time.time;
		//Debug.Log(battleLength);
		//Debug.Log(Time.time);
	}
	

	void Update () 
	{
		//Debug.Log(Time.time);
		if (Time.time > targetTime) Application.LoadLevel("TitleScreen");
	}
}
