 using UnityEngine;
using System.Collections;

public class AvatarEstado : MonoBehaviour {
	public Transform prefabExplosion;
	private GameState estado;
	// Use this for initialization
	void Start () {
		estado = GameState.GetComp<GameState>("Controlador");
	}

	// Update is called once per frame
	void Update () {
	
	}

	void Muerto(){
		estado.GanaPuntos (1); //Gana 1 punto si muere
		Instantiate (prefabExplosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}


}
