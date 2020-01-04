using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerActivate : MonoBehaviour {

	public Text powerPoints;
	public int powerPointsInt;
	public Rigidbody2D rbBall;


	private void OnCollisionEnter2D(Collision2D collision){
		powerPointsInt++;
		UpdateLabel(powerPoints,powerPointsInt);
		if(powerPointsInt >= 3){
			rbBall.velocity = new Vector2(14,14);
			powerPointsInt = 0;
			UpdateLabel(powerPoints,powerPointsInt);
		}
	}

	private void UpdateLabel(Text label, int score){
		label.text = score.ToString();
	}
}
