using UnityEngine;
using System.Collections;

public class RecordTitulo : MonoBehaviour {
	public TextMesh recordText;
	// Use this for initialization
	void Start () {
		recordText.text = "RECORD : " + PlayerPrefs.GetInt ("recordp",0).ToString ("D9");
		//recordt..text="RECORD!!!!!!!  " + puntos.ToString("D5");
	}
	
	// Update is called once per frame
}
