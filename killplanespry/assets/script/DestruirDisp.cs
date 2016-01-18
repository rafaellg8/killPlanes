using UnityEngine;
using System.Collections;

public class DestruirDisp : MonoBehaviour {

	public float timeLife=10; //Lo que va a durar el disparo clone

	// Use this for initialization
	void Start () {
		Destroy (gameObject,timeLife); //Destruye el objeto cada 2"
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
