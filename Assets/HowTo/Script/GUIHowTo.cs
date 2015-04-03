using UnityEngine;
using System.Collections;

public class GUIHowTo : MonoBehaviour {
	public GUISkin Style;

	void OnGUI(){
		GUI.skin = Style;
		if(GUI.Button(new Rect(0,Screen.height - 30,120,30)," Regresar")){
			Application.LoadLevel("menu");
			Destroy (this);
		}

		}
	}