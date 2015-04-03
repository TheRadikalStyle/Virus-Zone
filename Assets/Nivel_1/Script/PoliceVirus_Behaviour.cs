using UnityEngine;
using System.Collections;

public class PoliceVirus_Behaviour : MonoBehaviour {

	public Transform target;
	public int moveSpeed = 1;
	public int rotationSpeed = 1;
	public Transform myTransform;
	
	void Awake ()
	{
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		myTransform.position = Vector3.MoveTowards (myTransform.position, target.position, moveSpeed * Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D coli){
		if(coli.gameObject.tag== "Weapon"){
			//Debug.Log ("Colision con Binary Ball");
			Destroy (gameObject);
		}
	}

}