using UnityEngine;
using System.Collections;

public class SpawnerVirus : MonoBehaviour {

	public float spawnTime =5f;
	public float spawnDelay = 5f;
	public GameObject[] enemigos;

	// Use this for initialization
	void Start () {
		//Inicia llamando al metodo spawn despues de un retardo
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);
	}

	void Spawn(){
		int enemyIndex = Random.Range (0, enemigos.Length);
		Instantiate (enemigos [enemyIndex], transform.position, transform.rotation);
	}

}
