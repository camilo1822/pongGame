using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Manejar escenas
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {

	public Text scorePlayerText;
	public Text scoreEnemyText;

	int scorePlayerQuantity;
	int scoreEnemyQuantity;
	public SceneChanger sceneChanger;

	public AudioSource pointAudio;

	public FollowBall followBall;
	public PowerActivate powerActivate;

	/**
	Valida choques - colisiones
 	*/
	private void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Collision");
	}

	/**
	Valida cuando se atraviesa
	 */
	private void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log("Trigger");

		//gameObject se refiere al objeto al que le relacione el script
		if(gameObject.tag == "Izquierdo"){
			scoreEnemyQuantity++;
			UpdateScorelabel(scoreEnemyText,scoreEnemyQuantity);
			// si el puntaje enemigo es igual a n mostramos escena de perdedor
			if(scoreEnemyQuantity >= 5){
				sceneChanger.ChangeSceneTo("LoseScene");
			}
		}else if(gameObject.CompareTag("Derecho")){
			scorePlayerQuantity++;
			UpdateScorelabel(scorePlayerText,scorePlayerQuantity);
			//Si el puntaje del jugador es multiplo de n aumentamos la velocidad del enemigo
			if(calculateMultiplo(5,scorePlayerQuantity)){
				//aumentamos velocidad del enemigo
				followBall.speed += 0.003f;
			}
		}
		//Reiniciamos puntaje de poder
		powerActivate.powerPointsInt = 0;
		UpdateScorelabel(powerActivate.powerPoints,powerActivate.powerPointsInt);
		//Activamos audio de punto
		pointAudio.Play();
		//collider en este caso es la pelota, reiniciamos su posición
		collider.GetComponent<BallBehaviour>().gameStarted = false;
	}

	/**
	Actualizamos label de buntaje */
	private void UpdateScorelabel(Text label, int score){
		label.text = score.ToString();
	}

	private void CheckScoore(){

		//Cargamos escenas
		if(scorePlayerQuantity >= 5){
			
			sceneChanger.ChangeSceneTo("WinScene");
		}else if(scoreEnemyQuantity >= 5){
			sceneChanger.ChangeSceneTo("LoseScene");
		}
	}

	/**
	Metodo que valida si un número es multiplo de otro 
	*/
	private bool calculateMultiplo(int multiplo, int scoore){
		if(scoore % multiplo ==0){
			return true;
		}else{
			return false;
		}
	}
}
