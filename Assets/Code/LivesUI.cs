using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText;
	
	void Update () 
    {
		if (!GameManager.GameIsOver) {
			livesText.text = PlayerStats.Lives + " LIVES";
		}
	}
}
