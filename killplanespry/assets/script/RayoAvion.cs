using UnityEngine;
using System.Collections;

public class RayoAvion : MonoBehaviour {

	public Transform prefabDisparo; //Variable prefab Disparo
	private float tiempoDisparo = 0.5f;
	private float nextDisparo = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextDisparo) {	//si movemos el raton o pulsamos pantalla
			nextDisparo = Time.time + tiempoDisparo;
			transform.position = new Vector3 (0,0,-1);
			Instantiate (prefabDisparo,transform.position,transform.rotation); //creamos disparo a la misma direccion donde este objeto
		}
		
	}
}