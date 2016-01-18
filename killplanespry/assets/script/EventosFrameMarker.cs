using UnityEngine;
using System.Collections;

public class EventosFrameMarker : MonoBehaviour
{
	public GUIText notif;
	private bool detener;
	private GameState gamestate;

		// Use this for initialization
		void Start ()
		{
		gamestate = GetComponent<GameState> (); //Inicializamos una variable referencia GameState
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (detener && Time.frameCount >= 2) //corregir problemo pause Android
						Time.timeScale = 0f;
				if (Input.GetKeyDown (KeyCode.S)) //Si pulsamos la tecla S, perdemos marcador
						MarcadorPerdido ();
				else if (Input.GetKeyDown (KeyCode.W)) //Encontramos marcador
						MarcadorEncontrado ();
		}
	public void MarcadorPerdido ()
	{
		if (gamestate.gameover)	return;
		if (notif != null) {
			notif.enabled = true;
			//Pause
			Time.timeScale=0f; //Paramos el juego
			detener = true;
			//Todos los elementos que depende tiempo se paran
			//Debug.Log ("Perdido");
		}
	}

		public void MarcadorEncontrado ()
		{
		if (gamestate.gameover) return; //Si acabo el juego termina
		if (notif != null) {
						notif.enabled = false;
			Time.timeScale=1f;
			detener = false;
						//Resume		
						//Debug.Log ("Encontrado");
				}
		}

		}
