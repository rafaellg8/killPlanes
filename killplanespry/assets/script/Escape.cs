using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

	public float radioEscape = 10f;
	private Rotar rotar;
	private GameState estado;
	// Use this for initialization
	void Start () {
		rotar = GetComponent<Rotar> (); //Inicializamos el objeto funcion Rotar
		estado = GameState.GetComp<GameState> ("Controlador");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rotar.radioActual >= radioEscape)
						avatarEscapa ();
	
	}

	private void avatarEscapa(){
		Destroy (gameObject); //Destruimos avatar
		//Perdemos 1 punto o vida
		Debug.Log ("Escapa!!!");
		estado.GestionVidas ();
	}
}
