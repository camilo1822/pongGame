using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public Transform paddle;
	public bool gameStarted = false;
	public Rigidbody2D rbBall;
	float posDif = 0;

	public AudioSource ballAudio;

	// Use this for initialization
	void Start () {
		//Posición de nuestra bola
		posDif = paddle.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		//Si el juego no ha iniciado la pelota sigue la paleta
		if(!gameStarted){
			
			transform.position = new Vector3(paddle.position.x - posDif, paddle.position.y,paddle.position.z);

			//Identificamos si se dio clic izquierdo = 0
			if(Input.GetMouseButtonDown(0)){
				//Agregamos velocida a la bola
				rbBall.velocity = new Vector2(8,8);
				
				gameStarted = true;
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision){
		ballAudio.Play();
	}
}
