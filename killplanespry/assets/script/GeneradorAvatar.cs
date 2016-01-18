using UnityEngine;
using System.Collections;

public class GeneradorAvatar : MonoBehaviour {

	public Transform prefabAvatar;
	public Transform padreAvatar;	//Padre prefabAvatar
	public float esperaNext=3;		//Tiempo de espera para crear
	public float tiempoAvatar=5;		//Tiempo entre un objeto y otro
	public Transform avatarRotacion; //Objeto en el que gira
	private float horaNextAvatar;


	public float timeLimit = 180f; //3 minutos para ir maxima velocidad avion
	public float velocidadRotInic = 100f; //Velocidad Inicial
	public float velocidadRotFin = 400f; //Velocidad pasar 3 minutos
	public float radioInic = 0.5f; //Radio gira inicio
	public float radioFin = 1f; //Radio gira final 180 seg
	private float diferVelocidad, diferRotacion;
	// Use this for initialization
	void Start () {
		horaNextAvatar = Time.time + esperaNext;
		diferVelocidad = velocidadRotFin - velocidadRotInic;
		diferRotacion = radioFin - radioInic;
	}
	
	// Update is called once per frame
	void Update () {
		//prefabAvatar.transform.Translate(Random.Range(-1,1),1,Random.Range(-1,1));
		if (Time.time >= horaNextAvatar) {
				horaNextAvatar = Time.time + tiempoAvatar;
			Transform avatarTransform = Instantiate(prefabAvatar,avatarRotacion.position,avatarRotacion.transform.rotation)
				as Transform;
			avatarTransform.position = new Vector3(Random.Range(-100,-50),Random.Range(0,5),0); //Aleatorio pos inicial
			avatarTransform.parent = padreAvatar;
			Rotar rotar = avatarTransform.GetComponent<Rotar>();
			rotar.objetoCentroRotacion = avatarRotacion;

			float valorRotacion = ((diferVelocidad * Time.timeSinceLevelLoad) /timeLimit) + velocidadRotInic; //Calculamos el valor rotacion que se ira incrementado
			float valorRadio = ((diferRotacion * Time.timeSinceLevelLoad)/timeLimit) * 10; //Lo mismo para radio
			rotar.rotacionPorSegundo = valorRotacion; //Asignamos los valores de rotacion referencia a rotar
			//rotar.incrementoRadioPorSegundo = valorRadio;

			rotar.transform.position = avatarTransform.transform.position;
			rotar.transform.Translate (avatarTransform.position);
			//Con todo esto lo asignamos ya programado no hace falta hacerlo en la escena
		}	
	}

	Transform Generapos (Transform pos){
		float rand;
		rand = Time.time%10;
		pos.transform.position = new Vector3(rand, 0, 0);

		return pos;
	}
}
