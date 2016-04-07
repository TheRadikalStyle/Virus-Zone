using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {

	public bool pausado = false;

	public bool Menu = false;

	public GUISkin skinPausa;

	//public bool activarTouchButtons = true;

	public GameObject cam;

	private AudioClip gameClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pausado) {
						//Time.timeScale = 0;
						Menu = true;
						GetComponent<AudioSource>().Pause();
				} else {
						Time.timeScale = 1;
						Menu = false;
				}
	}

	void OnGUI(){
		GUI.skin = skinPausa;
		if (Menu) {
			Time.timeScale = 0;
			GUILayout.BeginVertical(); //Acomoda en vertical mis elementos
			GUILayout.BeginArea(new Rect(Screen.width/4.0f,Screen.height/4.0f,Screen.width/2.0f,Screen.height));//Crea un area que servira como "Alojamiento" de mis elementos
			GUILayout.Label("Menu de pausa");
			//GUI.Box (new Rect (Screen.width - 100, 0, 100,100), "Pausado");
			if(GUILayout.Button("Reiniciar")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUILayout.Button("Salir al menu principal")){
				Application.LoadLevel("Menu");
			}
			if(GUILayout.Button("Regresar")){
				Time.timeScale = 1;
				pausado = false;
				GetComponent<AudioSource>().Play ();
			}
			//activarTouchButtons = GUILayout.Toggle(activarTouchButtons, "Activar botones Touch");
			//PlayerPrefs.SetInt("TouchButtons",0);
			GUILayout.EndArea();
			GUILayout.EndVertical();
		}
	}
}
