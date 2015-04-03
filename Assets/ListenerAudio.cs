using UnityEngine;
using System.Collections;
//Asignar Sonidos
public class ListenerAudio : MonoBehaviour {

	public AudioClip[] Sonidos;
	private AudioSource FuenteAudio;

	// Use this for initialization
	void Start () {
		FuenteAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.transform.Translate(Vector3.up*2.0f);
			FuenteAudio.clip = Sonidos[0];
			FuenteAudio.Play();
		}
	}
}
