using UnityEngine;
using System.Collections;

public class VirusZone : MonoBehaviour {

	public float timer = 4f;

	void Start () {
		StartCoroutine ("DisplayScene");
	}

	IEnumerator DisplayScene(){
		yield return new WaitForSeconds (timer);
		Application.LoadLevel ("menu");
		Destroy (this);
	}

}
