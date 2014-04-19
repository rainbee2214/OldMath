using UnityEngine;
using System.Collections;

public class EdgeCollider : MonoBehaviour 
{
	private SpriteRenderer renderer;
	private Sprite sprite = null;

	void Start()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		renderer.sprite = sprite;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		renderer = other.gameObject.GetComponent<SpriteRenderer>();
		sprite = renderer.sprite;
		renderer.sprite = null;
		//if (other.tag == "Show" && other.tag != "Player") Destroy(other.gameObject);
		//else if (other.tag != "Show" && other.tag != "Player") other.renderer.enabled = false;
	}
}
