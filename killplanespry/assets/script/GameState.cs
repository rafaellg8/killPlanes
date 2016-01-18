using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public GUITexture guiVidas; //Vidas interfaz
	public Texture[] vecVidas; //vector Texturas Vidas
	public GUIText puntuacion;
	public GUIText record;
	public int puntos=0;
	public int vidas=0;
	public int defecto = 3; //Vidas inicio juego

	internal bool gameover = false; //Se puede acceder a ella desde otras clase pero no se muestra interfaz
	private int recordp=0;

	private float timeOver = 3f; //Tiempo pantalla game Over 3 segundos
	private float menuTime;
	

	public GameObject camaraOver;
	public GameObject marcador;

	// Use this for initialization


	void Start () {
		vidas = defecto;
		marcador.SetActive (true);
		AcutalizarPuntos (); 
		guiVidas.guiTexture.texture = vecVidas [defecto]; //Asociamos textura vector vidas
		//Asi cada vecVidas[numeroVidas] mostrara segun numeroVidas tengamos
		recordp = PlayerPrefs.GetInt ("recordp",0); //Valor empezar juego
		menuTime = Time.realtimeSinceStartup + timeOver; //El tiempo reanudar tiene que ser mayor desde empezo y over
	}
	
	// Update is called once per frame
	void Update () {
				if (gameover && (Input.GetButtonDown ("Fire1") || Input.touchCount > 0) && Time.realtimeSinceStartup > menuTime) {
			gameover=false;
					Application.LoadLevel ("inicio");
				}
		}


	public void AcutalizarPuntos(){
		puntuacion.guiText.text=puntos.ToString("D9"); //Mostrar en GUItext puntuacion puntos
	}//D9 mostrar 0 y 9 digitos

	/*//Gana 1 punto si destruye objeto
	Llama a AvatarEstado cuando Muere*/

	public void GanaPuntos(int valor){ 
		puntos += valor;
		AcutalizarPuntos ();

	}

	public void GestionVidas (){ //Gestiona si un avion se escapa o no
		if (vidas > 0) {
						vidas--;
						Debug.Log (vidas);
				}
		if (vidas < 3) //para mostrar comprobamos que es menor que 4 num vidas
		guiVidas.guiTexture.texture = vecVidas [vidas];
		//Actualizamos textura segun vector, numero vidas tenemos
		//[1],[2],[3]


		if (vidas <= 0) //Si perdemos
						GameOver ();
	}

	public void GameOver(){
		menuTime = Time.realtimeSinceStartup + timeOver;

		gameover = true;
		Time.timeScale = 0f; //Pausamos el juego
		camaraOver.SetActive (true);  //Activamos camara


		if (puntos > recordp) {
			recordp = puntos;
			//Actualizar y guardar
			recordp = PlayerPrefs.GetInt ("recordp",puntos);
			record.guiText.text="RECORD!!!!!!!  " + puntos.ToString("D5");
		}
			//Record Superado
		else{
			record.guiText.text=puntos.ToString("D9");
		}
			}
	



	/*Devuele una referencia al objeto tipo T*/
	public static T GetComp<T>(string cadena) where T : UnityEngine.Component{	//Obtiene Componente T llamado "cadena"
		GameObject controlador = GameObject.Find (cadena);

		if (controlador != null)
						return controlador.GetComponent<T> ();
		else {
			Debug.LogError("No se encontro GameObjetc"+cadena);
			return null;
		}

	}
}
