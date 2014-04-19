using UnityEngine;
using System.Collections;

public class EdgeCollider : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
			other.gameObject.renderer.enabled = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
			other.gameObject.renderer.enabled = false;
	}
}
