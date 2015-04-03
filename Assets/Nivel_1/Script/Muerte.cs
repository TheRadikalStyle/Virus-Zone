using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour {

	private GameObject perso;

	private bool MenuMuerto;

	private AudioClip gameClip;

	private int scoree = 0;

	public bool muerto = false;

	// Use this for initialization
	void Start () {
		perso = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		scoree = perso.GetComponent<PersonajeBehaviour> ().score;
		if (muerto) {
			Time.timeScale = 0;
			MenuMuerto = true;
			audio.Pause();
			//Vector3 meep = perso.GetComponent<PersonajeBehaviour>().pos;
			//meep = Vector3(0,0,0);
			//perso.GetComponent<PersonajeBehaviour>().pos = meep;
		} else {
			Time.timeScale = 1;
			MenuMuerto = false;
		}
	}

	void OnGUI(){
		//GUI.skin = skinPausa;
		if (MenuMuerto) {
			Time.timeScale= 0;
			audio.Pause();
			GUILayout.BeginVertical(); //Acomoda en vertical mis elementos
			GUILayout.BeginArea(new Rect(Screen.width/4.0f,Screen.height/4.0f,Screen.width/2.0f,Screen.height));//Crea un area que servira como "Alojamiento" de mis elementos
			GUILayout.Label("¡Has muerto!");
			//GUI.Box (new Rect (Screen.width - 100, 0, 100,100), "Pausado");
			GUILayout.Label("Puntaje: "+scoree);
			
			if(GUILayout.Button("Reintentar")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUILayout.Button("Salir al menu principal")){
				Application.LoadLevel("Menu");
			}
			
			GUILayout.EndArea();
			GUILayout.EndVertical();
		}
	}



}
