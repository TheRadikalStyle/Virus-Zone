using UnityEngine;
using System.Collections;

public class ParallaxFX : MonoBehaviour {
	
	public GameObject player;
	
	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PersonajeBehaviour>().isMoving) //Verifica si el jugador se esta o no moviendo, si lo esta se crea parallax effect
		{
		
			
			GameObject [] objetos = GameObject.FindGameObjectsWithTag("renderObject"); //Conjunto de GameObjects con tag renderObject
			foreach (GameObject objeto in objetos) { //Accediendo a las capas de cada objeto para control independiente de movimiento para parallax effect
				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "Background") { //sky
					//95% de movilidad AL 100% NO SE MULTIPLICA POR NADA AL ULTIMO
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal")  * .075f)*.95f;
					//pos.x += (player.GetComponent<PersonajeBehaviour>().h) * .43f;
					objeto.transform.localPosition = pos;
				}

				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "Suelo") {//Suelo para crear efecto inifito en el
					//95% de movilidad AL 100% NO SE MULTIPLICA POR NADA AL ULTIMO
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal")  * .075f)*.95f;
					//pos.x +=(player.GetComponent<PersonajeBehaviour>().h) * .43f;
					objeto.transform.localPosition = pos;
				}

				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "Ground") { //suelo
					//95% de movilidad AL 100% NO SE MULTIPLICA POR NADA AL ULTIMO
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal") * .075f)*.95f;
					//pos.x +=(Input.acceleration.x * .095f);
					objeto.transform.localPosition = pos;
				}

				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "FarFarLayer") { //Cerro
					//65% de movilidad AL 100% NO SE MULTIPLICA POR NADA AL ULTIMO
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal") * .075f)*.65f;
					//pos.x +=(player.GetComponent<PersonajeBehaviour>().h) * .55f;
					objeto.transform.localPosition = pos;
				}

				
				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "FarLayer")
				{
					//65% de movilidad
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal") * .075f) * .65f;
					//pos.x +=(player.GetComponent<PersonajeBehaviour>().h) * .65f;
					objeto.transform.localPosition = pos;
				}
				
				
				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "NearLayer")
				{
					//30% de movilidad
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal") * .075f) *.30f;
					//pos.x +=(player.GetComponent<PersonajeBehaviour>().h) * .30f;
					objeto.transform.localPosition = pos;
				}

				if (objeto.GetComponent<SpriteRenderer>().sortingLayerName == "NearNearLayer") //En realidad no es tan far far hahahaha
				{
					//15% de movilidad
					Vector3 pos = objeto.transform.localPosition;
					pos.x += (Input.GetAxis("Horizontal") * .075f) *.15f;
					//pos.x +=(player.GetComponent<PersonajeBehaviour>().h) * .15f;
					objeto.transform.localPosition = pos;
				}
				
			}//foreach llave
		}//if padre llave
	}//Update llave
}