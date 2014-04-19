using UnityEngine;
using System.Collections;

public class EdgeCollider : MonoBehaviour 
{

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Trigger exit");
		if (other.tag == "Show") Destroy(other.gameObject);
	}
}
