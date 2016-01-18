using UnityEngine;
using System.Collections;

public class InicioJuego : MonoBehaviour {
	// Update is called once per frame
	void Update () {

				if ((Input.GetButtonDown ("Fire1") || (Input.touchCount > 1))) {
						//Application.LoadLevel(3); //Carga la escena 1 que es la del juegoe
						Application.LoadLevel ("killPlanes");
				}
		}
}
