using UnityEngine;
using System.Collections;

public class GUICredits : MonoBehaviour {

	public GUISkin creditsSkin;

	void OnGUI(){
		GUILayout.BeginHorizontal();
		GUILayout.BeginArea(new Rect(Screen.width/4.0f,Screen.height/4.0f,Screen.width/2.0f,Screen.height));
		GUI.skin = creditsSkin;

		GUILayout.Label ("Desarrollo: David Ochoa Gutierrez");

		if(GUILayout.Button("Twitter")){
			Application.OpenURL("http://www.twitter.com/theradikalstyle");
		}

		GUILayout.EndArea();
		GUILayout.EndHorizontal();

		GUI.Box(new Rect(Screen.width/3,Screen.height/2 + 50,400,30),"Musica de juego: 8mm Vodka Shots - Marrach, Creative Commons");

		if(GUI.Button(new Rect(0,Screen.height - 30,120,30)," Regresar")){
			Application.LoadLevel("menu");
			Destroy (this);
		}
	}
}
