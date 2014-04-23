using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public static float battleLength = 1;
	private float targetTime;
	void Start () 
	{
		targetTime = battleLength + Time.time;
	
	}
	

	void Update () 
	{
		if (Time.time > targetTime) Application.LoadLevel("Menu");
	}
}
