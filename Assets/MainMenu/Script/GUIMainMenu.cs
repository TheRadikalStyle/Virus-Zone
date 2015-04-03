using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

	public GUISkin Cool;

	public Texture2D botonIniciar;
	public Texture2D botonCerrar;
	public Texture2D botonControles;
	public Texture2D botonAbout;	

	void OnGUI(){
		GUI.skin = Cool;

		if (!botonCerrar ) {
			Debug.Log ("Asigna una textura en el inspector al boton cerrar");
			return;
		}
		if (!botonIniciar ) {
			Debug.Log ("Asigna una textura en el inspector al boton iniciar");
			return;
		}

		/*Boton para cargar el nivel1*/
		if (GUI.Button (new Rect (Screen.width - 130, 0, 140, 50), botonIniciar)) {
			Application.LoadLevel("level1");
            Destroy(this);
		}

		/*Boton para los noobs que no saben como se juega xD*/
		if(GUI.Button(new Rect (Screen.width - 130, Screen.height/2, 140, 50), botonControles)){
			Application.LoadLevel("HowTo");
            Destroy(this);
		}

		#if(UNITY_ANDROID ||UNITY_STANDALONE )
		/*Boton para cerrar el juego*/
		if (GUI.Button (new Rect (-15, Screen.height - 40, 120, 38), botonCerrar)) {
			Application.Quit();
		}
		#endif

		if(GUI.Button(new Rect(Screen.width - 55,Screen.height - 80,70,70), botonAbout)){
			Application.LoadLevel ("about");
            Destroy(this);
		}
	}
}
