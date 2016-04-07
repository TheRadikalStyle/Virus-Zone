using UnityEngine;
using System.Collections;

public class PersonajeBehaviour : MonoBehaviour {

	public float fuerzaSalto = 350F;
	public float fuerzaCaida = 200F;

	public float h; // Activar cuando se use Acelerometro

	private bool dobleSalto = false;

	private GameObject cam;

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.06f;
	public LayerMask Ground; //Capa Ground

	public bool isMoving;

	public bool meep = false;

	private bool colisionLimitador; // Variable bool que hace si esta verdadera, Movimiento() no se ejecuta

	/******Activar si quiero que sea movimiento en X autonomo***************/
	/*public bool isMoving = false;
	public float velocidadMovimiento = 2f;*/
	/********************************************************************/

	public int score = 0;

	//Audio variables
	public AudioClip[] Sonidos;
	private AudioSource FuenteAudio;

	//[HideInInspector]
	public bool facingRight;


	float someScale;
	// Use this for initialization
	void Start () {
		FuenteAudio = GetComponent<AudioSource> ();
		someScale = transform.localScale.x;
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(!colisionLimitador){
		Movimiento ();
	}
	}

	void FixedUpdate(){ //Cada cierto tiempo no cada frame
		/************ACTIVAR CUANDO EL MOVIMIENTO SEA AUTONOMO*******************/
		/*if (isMoving) {
			rigidbody2D.velocity = new Vector2(velocidadMovimiento,	rigidbody2D.velocity.y);	
			enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, Ground);
		if (enSuelo) {
			dobleSalto = false;		
		}
		}*/
		/*********************************************************************/
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, Ground);
		if (enSuelo) {
			dobleSalto = false;		
		}
	}



	void Movimiento(){

				/*******ACTIVAR SI DESEO MOVIMIENTO EN X AUTONOMO**************/
				/*if (Input.GetMouseButtonDown (0)) {
						if (isMoving) {
								if (enSuelo || !dobleSalto) {
										rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
										rigidbody2D.AddForce (new Vector2 (0, fuerzaSalto));
										(GetComponent<Animator> ()).SetBool ("isJumping", true);
										if (!dobleSalto && !enSuelo) {
												dobleSalto = true;
										}
										//(GetComponent<Animator>()).SetBool("isJumping",false);
								} else {
										isMoving = false;	
								}
						} 
				}*/

		/******************************************************************************/


												/*if (Input.GetKey (KeyCode.D)) {
													transform.Translate (Vector2.right * 4F * Time.deltaTime);
													transform.eulerAngles = new Vector2 (0, 0);  //x1, y1 Giros en ejes para voltear personaje
													(GetComponent<Animator> ()).SetBool ("isRunning", true);
												}else {
													(GetComponent<Animator> ()).SetBool ("isRunning", false);
												}*/

/***********************************MOVIMIENTO A TRAVES DE TECLADO**************************************************/
		if (Input.GetAxis ("Horizontal") != 0 ) {  //!=0
		 h = Input.GetAxis("Horizontal");
			if(h>0.0f){ //Para voltear al personaje dependiendo la orientacion
				transform.localScale = new Vector2(someScale, transform.localScale.y);
				facingRight = true;
			}else{
				transform.localScale = new Vector2(-someScale, transform.localScale.y);
				facingRight = false;
			}
						Vector3 pos = transform.localPosition;
						pos.x += Input.GetAxis ("Horizontal") * .075f;
						transform.localPosition = pos;
						(GetComponent<Animator>()).SetBool("isRunning",true);
						isMoving = true;
						}else {
							(GetComponent<Animator>()).SetBool("isRunning",false);
							isMoving = false;
							}
		//if (cam.GetComponent<Pausa> ().activarTouchButtons) { //Si estan activados los botones touch se salta con boton, si no se salta tocando x punto en la pantalla
			Salto ();
			//SaltoSinTouch();
		//} else {
			//SaltoSinTouch();	
		//}
/***********************************MOVIMIENTO A TRAVES DE TECLADO**************************************************/

/***********************************MOVIMIENTO A TRAVES DE ACELEROMETRO**************************************************/
		/*if(Input.acceleration.x >= 0.1f) {
			//GUILayout.Label(Rect(Screen.width/2,Screen.height/2,50,80)," "+Input.acceleration.x);
			transform.localScale = new Vector2(someScale, transform.localScale.y); //Girar derecha
			Vector3 pos = transform.localPosition;
			pos.x += Input.acceleration.x * .45f;
			transform.localPosition = pos;
			(GetComponent<Animator>()).SetBool("isRunning",true);
			isMoving = true;
			facingRight = true;
			//Debug.Log("Se mueve derecha");
		}else {
			transform.localScale = new Vector2(-someScale, transform.localScale.y); //Girar izquierda
			Vector3 pos = transform.localPosition;
			pos.x += Input.acceleration.x * .45f;
			transform.localPosition = pos;
			(GetComponent<Animator>()).SetBool("isRunning",true);
			isMoving = true;
			facingRight = false;
			//Debug.Log("Se mueve izquierda");
		}
		h = Input.acceleration.x; //Mandar a PARALLAXFX.CS CUANDO USO ACELEROMETRO
		*/
		/*if(Input.acceleration.x >= 0.1f) {
			//GUILayout.Label(Rect(Screen.width/2,Screen.height/2,50,80)," "+Input.acceleration.x);
			transform.localScale = new Vector2(someScale, transform.localScale.y); //Girar derecha
			Vector3 pos = transform.localPosition;
			pos.x += Input.acceleration.x * .45f;
			transform.localPosition = pos;
			(GetComponent<Animator>()).SetBool("isRunning",true);
			isMoving = true;
			Debug.Log("Se mueve derecha");
				}else {
				(GetComponent<Animator>()).SetBool("isRunning",false);
				isMoving = false;
					}// Si se mueve a la derecha el celular, se debe de mover a la derecha

		if(Input.acceleration.x <= -0.1f){
			transform.localScale = new Vector2(-someScale, transform.localScale.y); //Girar izquierda
			Vector3 pos = transform.localPosition;
			pos.x += Input.acceleration.x * .45f;
			transform.localPosition = pos;
			(GetComponent<Animator>()).SetBool("isRunning",true);
			isMoving = true;
			facingRight = false;
				}else {
					(GetComponent<Animator>()).SetBool("isRunning",false);
					isMoving = false;
				}// Si se mueve a la izquierda el celular se debe de mover a la izquierda

		if (cam.GetComponent<Pausa> ().activarTouchButtons) { //Si estan activados los botones touch se salta con boton, si no se salta tocando x punto en la pantalla
						Salto ();	
				} else {
			SaltoSinTouch();	
		}*/

/***********************************MOVIMIENTO A TRAVES DE ACELEROMETRO****************************************************/
		}	//Cierre de movimiento

																							/**************EJEMPLOS DE CODIGOS USANDO ACELEROMETRO*****************************/
																									/*Esto debe de ir dentro de Update()... Hace saltar al personaje
																									 * *
																									if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {//Cuando inicia el evento touch el objeto saltara
																										this.transform.Translate(Vector3.up * 2.0f);		
																									}
																									*
																									*/

																									/*Esto debe de ir dentro de Update()... Mueve al personaje dependiendo de que lado toque la pantalla
																									 * 
																									if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {//Cuando inicia el evento touch el objeto saltara
																										if(Input.GetTouch(0).position.x < Screen.width/2.0f) //Si se toca a la mitad izquierda
																											this.transform.Translate(Vector3.left*2.0f);
																										if(Input.GetTouch(0).position.x > Screen.width/2.0f)//Si se toca a la mitad derecha
																											this.transform.Translate(Vector3.right*2.0f)
																									}
																									*
																									*/
																									
																																		/*if (Input.GetKey (KeyCode.S)) {
																																			rigidbody2D.AddForce(new Vector2(0,-fuerzaCaida));	
																																			(GetComponent<Animator>()).SetBool("isJumping",false);

																																		}*/

																									/*USANDO ACELEROMETRO, USA EJES X Y Z... DEBE IR EN UPDATE
																									 * *Mover objeto usando acelerometro y girarlo en su eje
																									 * *
																									 * if(Input.acceleration.x > 0.0f)// Si se mueve a la derecha el celular se debe de mover a la derecha
																									 * this.transform.Translate(Vector3.right * Time.deltaTime);
																									 * 
																									 * if(Input.acceleration.x < 0.0f)// Si se mueve a la derecha el celular se debe de mover a la derecha
																									 * this.transform.Translate(Vector3.left * Time.deltaTime);
																									 * 
																									 * if(Input.acceleration.z > 0.0f)// Rota a la derecha
																									 * this.transform.Rotate(Vector3.forward * Time.deltaTime);
																									 * 
																									 * if(Input.acceleration.z < 0.0f)// Rota a la izquierda
																									 * this.transform.Rotate(Vector3.back * Time.deltaTime);
																									 * */


																									/*USANDO GESTOS, touchCount == 1 significa 1 dedo
																									 * 
																									 * private bool vivo;
																									 * 
																									 * void OnCollisionEnter2D(Collision2D Objeto){
																									 * if(Objeto.gameObject.layer != 8)
																									 * vivo = false;
																									 * }
																									 * 
																									 * void Start(){
																									 * vivo = true;
																									 * }
																									 * 
																									 * void Update(){
																									 * if(Input.touchCount==  && vivo)
																									 * this.transform.Translate(Vector3.up * Time.deltaTime * Input.GetTouch(0).tapCount);//subir personaje multiplicando tambien por 
																									 * }
																									 * 
																									 * 
																									 * */

																									/*USANDO GESTOS, touchCount == 1 significa 1 dedo
																									 * private Vector2 Inicio;
																									 * private Vector2 Fin;
																									 * private bool SeMovio;
																									 * 
																									 * void Start(){
																									 * SeMovio = false;
																									 * }
																									 * 
																									 * void Update(){
																									 * if(Input.touchCount > 0){
																									 * if(Input.GetTouch(0).phase == TouchPhase.Began)
																									 * Inicio = Input.GetTouch(0).position;
																									 * if(Input.GetTouch(0).phase == TouchPhase.Moved)
																									 * SeMovio = true;
																									 * if(Input.GetTouch(0).phase == TouchPhase.Ended){
																									 * if(SeMovio){
																									 * Fin = Input.GetTouch(0).position;
																									 * this.transform.Translate(new Vector3((Fin.x - Inicio.x)/100.0f,(Fin.y-Inicioy)/100.0f,0.0f)); //Dividir entre 100porque touch da pixeles
																									 * }
																									 * }
																									 * 
																									 * }
																									 * }
																									 * 
																									 * 
																									 * 
																									 * 
																									 * */

																									/*AMPLIAR  ACHICAR PERSONAJE CON 2 DEDOS
																									 * private bool MagnitudAlmacenada;
																									 * private float MagnitudInicial;
																									 * privateFloat Magnitud Final;
																									 * 
																									 * void Start(){
																									 * MagnitudAlmacenada  = true;
																									 * }
																									 * 
																									 * void Update(){
																									 * if(Input.touchCount == 2){
																									 * if(!MagnitudAlmacenada){
																									 * MagnitudInicial = Vector2.SqrMagnitude(Input.GetTouch(0).position - Input.GetTouch(1).position);
																									 * MagnitudAlmacenada = true;
																									 * }
																									 * if(Input.GetTouch(0).phase == TouchPhase.moved && Input.GetTouch(1).phase == TouchPhase.Moved)
																									 * MagnitudFinal=Vector2.SqrMagnitude(Input.GetTouch(0).position - Input.GetTouch(1).position);
																									 * if(MagnitudFinal > MagnitudInicial)
																									 * this.transform.localScale = Vector3.one + (Vector3.one*0.1f);
																									 * else
																									 * this.transform.localScale = Vector3.one - (Vector3.one*0.1f);
																									 * }
																									 * else
																									 * MagnitudAlmacenada = false;
																									 * }
																									 * 
																									 * 
																									 * 
																									 * */
																								/**************EJEMPLOS DE CODIGOS USANDO ACELEROMETRO*****************************/

	public void Salto(){
		if (cam.GetComponent<GeneralGUI>().saltoPresionado && (enSuelo || !dobleSalto)) {  //if (Input.GetMouseButtonDown (0) && (enSuelo || !dobleSalto))
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, fuerzaSalto));
			//cam.GetComponent<GeneralGUI>().saltoPresionado = false;
		(GetComponent<Animator> ()).SetBool ("isJumping", true);
		if (!dobleSalto && !enSuelo) {
			dobleSalto = true;
		}
		(GetComponent<Animator>()).SetBool("isJumping",false);
			}
		}

	/*public void SaltoSinTouch(){
		if (Input.GetMouseButtonDown (0) && (enSuelo || !dobleSalto)) {  //if (Input.GetMouseButtonDown (0) && (enSuelo || !dobleSalto))
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
			rigidbody2D.AddForce (new Vector2 (0, fuerzaSalto));
			//cam.GetComponent<GeneralGUI>().saltoPresionado = false;
			(GetComponent<Animator> ()).SetBool ("isJumping", true);
			if (!dobleSalto && !enSuelo) {
				dobleSalto = true;
			}
			(GetComponent<Animator>()).SetBool("isJumping",false);
		}
	}*/

	/*IEnumerator esperaAntesDe() {
		Debug.Log("Before Waiting 5 seconds");
		yield return new WaitForSeconds(5);
		Debug.Log("After Waiting 5 Seconds");
	}*/

	/********************COLISIONADORES DE MONEDAS Y ENEMIGOS****************************/
			void OnTriggerEnter2D(Collider2D col){
				if (col.tag == "Coins") {
					FuenteAudio.clip = Sonidos[0];
					FuenteAudio.Play();
					score += 5;
					Destroy(col.gameObject);
					}
				if(col.tag == "Virus"){
					//this.GetComponentInChildren<GUIText>().enabled = true;
					//Debug.Log ("Ups! me mori por un Virus");
					(GetComponent<Animator>()).SetBool("isDead", true);
					meep = cam.GetComponent<Muerte> ().muerto;
					Debug.Log(meep);
					meep = true;
					cam.GetComponent<Muerte> ().muerto = meep;
				}
				if(col.tag == "Police_Virus"){
					//this.GetComponentInChildren<GUIText>().enabled = true;
					//Debug.Log ("Ups! me mori por un Police_Virus");
					(GetComponent<Animator>()).SetBool("isDead", true);
					meep = cam.GetComponent<Muerte> ().muerto;
					Debug.Log(meep);
					meep = true;
					cam.GetComponent<Muerte> ().muerto = meep;
					}
				}
	/********************COLISIONADORES DE MONEDAS Y ENEMIGOS****************************/


				void OnCollisionEnter2D(Collision2D coli){
					if(coli.gameObject.tag == "Limitador"){
						colisionLimitador = true;
						isMoving = false;
						//Debug.Log ("Colision con limitador izquierdo");
						//Debug.Log ("isMoving esta: " +isMoving);
						(GetComponent<Animator>()).SetBool("isRunning",false);
						//Debug.Log("Ups! no te puedes salir del mapa, entrarias a la deep zone!");
						}
					}

				void OnCollisionStay2D(Collision2D coli2){
					if(coli2.gameObject.tag == "Limitador"){
						//transform.Translate = new Vector2(-14.2f,-2.5367f);
						Vector3 pos = transform.localPosition;
						pos = new Vector3(-14.2f,-2.5367f,0);
						transform.localPosition = pos;
						colisionLimitador = false;
						}
					}
	
		}//Fin