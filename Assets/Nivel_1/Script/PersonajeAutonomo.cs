using UnityEngine;
using System.Collections;

public class PersonajeAutonomo : MonoBehaviour {


	public float fuerzaSalto = 10f;
	
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	
	private bool dobleSalto = false;
	

	
	public bool isMoving;
	public float velocidad = 5f;
	
	void Awake(){

	}


	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate(){
		if(isMoving){
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
			}
		//animator.SetFloat("VelX", rigidbody2D.velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		(GetComponent<Animator> ()).SetBool ("isRunning", false);
		if(enSuelo){
			dobleSalto = false;
		}
	}
	

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(isMoving){
				// Hacemos que salte si puede saltar
				if(enSuelo || !dobleSalto){
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					(GetComponent<Animator> ()).SetBool ("isJumping", true);
					if(!dobleSalto && !enSuelo){
						dobleSalto = true;
					}
				}
			}else{
				isMoving = true;
			}
		}
	}

}
