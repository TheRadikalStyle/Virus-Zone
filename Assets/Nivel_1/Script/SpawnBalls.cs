using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour {

	public Rigidbody2D ballPrefab;
	public Transform barrelEnd;
	
	public GameObject persona;
	//private Rigidbody2D rocketInstance;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Disparar();
			//rocketInstance.AddForce(barrelEnd.forward * 5000);	
		}
	}

	public void Disparar(){
		Rigidbody2D rocketInstance;
			rocketInstance = Instantiate(ballPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;

	}
}
