using UnityEngine;
using System.Collections;

public class GeneralGUI : MonoBehaviour {
	public GameObject go;//Para poder acceder a sus componentes
	public Texture2D SaltarOrb;
	public Texture2D botonPausa;
	public Texture2D DisparaOrb;

	public GUISkin skinJuego;
	public GUISkin skinMuerto;

	public bool saltoPresionado;

	private int scoree = 0;

	private GameObject person;
	//public GameObject pau;

	private int touch;

	private AudioClip gameClip; //Controla el audio

	private string hover;
	public AudioClip sound;

	//PersonajeBehaviour pb = new PersonajeBehaviour();

	void Start(){
		//pau = GameObject.FindGameObjectWithTag ("MainCamera");
		person = GameObject.FindGameObjectWithTag ("Player");
		touch = PlayerPrefs.GetInt ("TouchButtons");
		/*if (touch == 1) {
			//GetComponent<Pausa>().activarTouchButtons = true;	
		}*/
	}

	
	void Update(){
		//if(hover=="Button 1")
			//audio.PlayOneShot(sound);
	}

	
	void OnGUI(){
				if (!GetComponent<Pausa> ().pausado) {
						//if (GetComponent<Pausa> ().activarTouchButtons == false) {
								//menuNoTouch ();
						//} else {
								menuTouch ();
						//}
				}

				/*if (person.GetComponent<PersonajeBehaviour> ().muerto) { //Si es tocado por un virus, muere y se activa este menu
						bool meep = GetComponent<Muerte> ().muerto;
						meep = true;
						GetComponent<Muerte> ().muerto = meep;
				}*/
						/*Time.timeScale= 0;
			audio.Pause();
			//GUI.skin = skinMuerto;
			GUILayout.BeginVertical(); //Acomoda en vertical mis elementos
			GUILayout.BeginArea(new Rect(Screen.width/4.0f,Screen.height/4.0f,Screen.width/2.0f,Screen.height));//Crea un area que servira como "Alojamiento" de mis elementos
			GUILayout.Label("¡Has muerto!");
			GUILayout.Label("Puntaje: "+scoree);
			
			if(GUILayout.Button("Reintentar")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUILayout.Button("Salir al menu principal")){
				Application.LoadLevel("Menu");
			}
			
			GUILayout.EndArea();
			GUILayout.EndVertical();
		}*/
						/*Boton para moverse a la izquierda*/
						/*if (GUI.Button (new Rect (Screen.width - 100, 140, Screen.width / 4.0f, Screen.width / 4.0f), "Derecho")) {
						Debug.Log ("Disparar Binary Balls");
						//Hacer algo
						person.GetComponent<SpawnBalls> ();

				}*/

/************************ACTIVAR SOLO EN VERSIONES MOVILES******************************/

						/*if (GUI.Button (new Rect (0, Screen.height/2 + 45, 50, 50), SaltarOrb)) {
			Debug.Log ("Saltar");
			//Hacer algo
			person.GetComponent<PersonajeBehaviour>().Salto();
		}
		
		if (GUI.Button (new Rect (0, Screen.height/2 + 90, 50, 50), DisparaOrb)) {
				Debug.Log ("Disparar");
				//Hacer algo
				person.GetComponent<SpawnBalls>().Disparar();
			}*/
/************************ACTIVAR SOLO EN VERSIONES MOVILES******************************/	
		
				
		}//if fin

		public void menuNoTouch(){

		/******Seteo algo de alpha******/
		Color tmpColor = GUI.color;
		GUI.color = new Color (1, 1, 1, 0.5f);
		GUI.color = tmpColor;
		/******Seteo algo de alpha******/

		GUI.skin = skinJuego;
		//hover = GUI.tooltip;
			scoree = go.GetComponent<PersonajeBehaviour> ().score; //Setea la variable local scoree con la info de la var score en PersonajeBehaviour 
			/*Label para mostrar puntos*/
			GUILayout.Label ("Puntos: " + scoree); //Puntaje en pantalla
			
			/* Caja anunciadora de version alpha*/
			//GUI.Box (new Rect (Screen.width - 100, 0, 100, 25), "Beta Test"); //Cuadro de alpha en arriba derecha
			
			/*Boton para pausa*/
			if(GUI.Button(new Rect(5,Screen.height - 40, 45,45), botonPausa)){   //   10    /2
				bool me = GetComponent<Pausa>().pausado;
				me = true;
				GetComponent<Pausa>().pausado = me;
				GetComponent<AudioSource>().PlayOneShot(sound);
			}
		PlayerPrefs.SetInt("TouchButtons",1);
	}

			public void menuTouch(){
		/******Seteo algo de alpha******/
		Color tmpColor = GUI.color;
		GUI.color = new Color (1, 1, 1, 0.5f);
		GUI.color = tmpColor;
		/******Seteo algo de alpha******/
				
				GUI.skin = skinJuego;
				scoree = go.GetComponent<PersonajeBehaviour> ().score; //Setea la variable local scoree con la info de la var score en PersonajeBehaviour 
				/*Label para mostrar puntos*/
				GUILayout.Label ("Puntos: " + scoree); //Puntaje en pantalla
				
				/* Caja anunciadora de version alpha*/
				//GUI.Box (new Rect (Screen.width - 100, 0, 100, 25), "Beta Test"); //Cuadro de alpha en arriba derecha
				
				/*Boton para pausa*/
				if(GUI.Button(new Rect(10,Screen.height - 150, 60,60), botonPausa)){   //   10    /2
					bool me = GetComponent<Pausa>().pausado;
					me = true;
					GetComponent<Pausa>().pausado = me;
				}
				if (GUI.Button (new Rect (90, Screen.height - 85, 90, 90), SaltarOrb)) {
					Debug.Log ("Saltar");
					//Hacer algo
					saltoPresionado = true;
					person.GetComponent<PersonajeBehaviour>().Salto();
					saltoPresionado = false;
				}
				
				if (GUI.Button (new Rect (0, Screen.height -85, 90, 90), DisparaOrb)) {
						Debug.Log ("Disparar");
						//Hacer algo
						person.GetComponent<SpawnBalls>().Disparar();
					}
				PlayerPrefs.SetInt("TouchButtons",1);
			}
	
}