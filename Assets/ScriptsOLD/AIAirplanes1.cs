using UnityEngine;
using System.Collections;

public class AIAirplanes1 : MonoBehaviour {
	public GameObject aircraftTransform;
	public GameObject enemyTransform;
	public GameObject movementLocation;
	public GameObject attackUnit;
	// Use this for initialization
	void Start () {
	
	}
	/*
	// Update is called once per frame
		void Update () {
			Vector3 middleWaypointPosition =
				new Vector3((aircraftTransform.GetComponent<Transform>().position.x + movementLocation.GetComponent<Transform>().position.x + enemyTransform.GetComponent<Transform>().position.x) / 3f,
			            	(aircraftTransform.GetComponent<Transform>().position.y + movementLocation.GetComponent<Transform>().position.y + enemyTransform.GetComponent<Transform>().position.y) / 3f,
			            	(aircraftTransform.GetComponent<Transform>().position.z + movementLocation.GetComponent<Transform>().position.z + enemyTransform.GetComponent<Transform>().position.z) / 3f);
			Vector3 finishTangent = middleWaypointPosition + (enemyTransform.GetComponent<Transform>().position - middleWaypointPosition) / 2;
			finishTangent.y = 10;
			// Add first point - A position, A forward tangent
			waypointSequence.addPoint(aircraftTransform.GetComponent<Transform>().position, aircraftTransform.GetComponent<Transform>().position + aircraftTransform.GetComponent<Transform>().forward * 10);
			// Second point - Centroid of A, B, C. Tangent is pointing at C
			waypointSequence.addPoint(middleWaypointPosition, finishTangent);
			// Last point - position is at B
			waypointSequence.addPoint(movementLocation, movementLocation +
			                          (movementLocation - attackUnit.transform.position).normalized * 10);
		}
		*/
	}
