using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization (Se ejecuta una vez al principio)
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Pintamos posición del mouse
		//Debug.Log(Input.mousePosition);
		//transform.position (Variable) -> Modificamos los valores del gameObject "Transform"
		//Pero estan en coordenadas diferents. 1 -> worldSpace, 2 -> pixeles
		//transform.position = Input.mousePosition;

		//Transformamos coordenadas para que coincidan, transforma de pixeles a posición en el mundo
		// Para que Camera.main funcione debemos ponerle a nuestar camara el tag "MainCamera"
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.position.z queremos que la posición en x y z se mantenga
		//transform.position = new Vector3(transform.position.x,mousePos.y,transform.position.z);

		//Ahora haremos que en y no se salga de la pantalla
		transform.position = new Vector3(transform.position.x,Mathf.Clamp(mousePos.y,-3.8f,3.8f),transform.position.z);
	}
}
