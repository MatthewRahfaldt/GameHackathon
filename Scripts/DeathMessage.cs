using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DeathMessage : MonoBehaviour {
	private DamagePlayer dp;
	private int currentNumberOfDeaths;
	private TMP_Text message;
	
	void Start() {
		dp = GameObject.GetObjectByType<DamagePlayer>();
		currentNumberOfDeaths = PlayerPrefs.getInt("Death Count");
		message = GetComponent<TMP_Text>();
	}

	void Update() {
		if (dp.getPlayerDeathStatus()) {
			deathMessage();
		}
	}

	void deathMessage() {
		string s;
		PlayerPrefs.setInt("Death Count", currentNumberOfDeaths + 1);
		if (PlayerPrefs.getInt("Death Count") == 1) {
			s = "You Have Crashed and are late to class. Two more lab abscenses and you fail chemistry";
		}
		if (PlayerPrefs.getInt("Death Count") == 2) {
			s = "You Have Crashed and are late to class. One more lab abscense and you fail chemistry";
		}
		if (PlayerPrefs.getInt("Death Count") == 3) {
			s = "You Have Crashed and are late to class. Because you have missed three labs you have failed chemistry and your life is a failure";
		}
		message.text = s;
		dp.triggerDeath();
	}
}