﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 6;
	public float lookAheadMoveThreshold = 5;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(target.position.x, target.position.y, -10f);
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
		// only update lookahead pos if accelerating or changed direction
		if (target != null)
		{
			float xMoveDelta = (target.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			transform.position = newPos;
			
			lastTargetPosition = target.position;
		}
				
	}
}