using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour 
{

    public Text moneyText; 

	// Update is called once per frame
	void Update () {
		if (!GameManager.GameIsOver) {
			moneyText.text = "€" + PlayerStats.Money.ToString();
		}
	}
}
