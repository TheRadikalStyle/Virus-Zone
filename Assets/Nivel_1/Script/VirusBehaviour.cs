using UnityEngine;
using System.Collections;

public class VirusBehaviour : MonoBehaviour {

	/*public Transform Player;
	private float MoveSpeed = .5f;
	private int MaxDist = 1;
	private float MinDist = 0.5F;  */



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
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*transform.LookAt (Player);
		if (Vector3.Distance (transform.position, Player.position) >= MinDist) {
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
		}
		if (Vector3.Distance (transform.position, Player.position) <= MaxDist) {
		//Si quiero hacer algo como disparar
		}*/
		//myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * moveSpeed * Time.deltaTime);
		myTransform.position = Vector3.MoveTowards (myTransform.position, target.position, moveSpeed * Time.deltaTime);
		//myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coli){
		if(coli.gameObject.tag== "Weapon"){
			//Debug.Log ("Colision con Binary Ball");
			Destroy (gameObject);
		}
	}

	/*void OnCollisionEnter2D (Collision2D coll){
		if(coll.gameObject.tag== "Player"){
			Debug.Log ("Mate al personaje wuajajajaj");
			Destroy (coll.gameObject);
		}
	}*/
}
