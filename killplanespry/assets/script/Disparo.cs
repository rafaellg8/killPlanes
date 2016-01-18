using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (transform.forward * 1000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider otro){		//Destruye Objeto cuando choque collider
		if (otro.name == "Suelo") {
			Destroy(gameObject,1);
			GetComponentInChildren<ParticleSystem>().enableEmission=false;
			DestroyDisparo();
		}
		else if (otro.tag == "Avatar"){	//Si colsiona con el avatar
			DestroyDisparo();
			otro.SendMessage ("Muerto",SendMessageOptions.DontRequireReceiver); //LLama al metodo Muerto y si no lo tiene ignorar
		}
	}

	void DestroyDisparo(){
		Destroy (gameObject,1);
		GetComponentInChildren<ParticleSystem> ().enableEmission = false; //Deje emitir disparos
	}

}
