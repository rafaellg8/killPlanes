using UnityEngine;
using System.Collections;

public class Rotar : MonoBehaviour {
	public Transform objetoCentroRotacion;
	public float rotacionPorSegundo = 75f; //Grados rot. sgundo
	
	public float radioActual = 0.5f;
	public float incrementoRadioPorSegundo =1f;
	float x,y,z;


	// Use this for initialization
	void Start () {

		x =Random.Range (-3, -1);
		y = Random.Range (0, 3);
		z = Random.Range (0, 0);
		//objetoCentroRotacion = Generapos (objetoCentroRotacion);
	}

	// Update is called once per frame
	void Update () {
		radioActual += incrementoRadioPorSegundo * Time.deltaTime;
		transform.position = new Vector3 (objetoCentroRotacion.position.x, 1, objetoCentroRotacion.position.z);
		transform.Translate (x,y,0); //Hacer girar izda.
		transform.RotateAround (objetoCentroRotacion.position, Vector3.up, rotacionPorSegundo * Time.deltaTime);

	}

	void Generapos (){
		transform.position = new Vector3(Random.Range(-8,8), 0, Random.Range(-3,3));
		transform.TransformDirection (Random.Range(-8,8), 0, Random.Range(-3,3));
		transform.Rotate (Random.Range(-8,8),0,0);
	}
} //Timedelta time tiempo que tarda en pasar de un fotograma a otro

