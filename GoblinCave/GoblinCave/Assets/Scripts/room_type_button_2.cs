using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class room_type_button_2 : MonoBehaviour {
	private GameObject Button;
	public bool Active = false;
	
	void Start () {
		setButton ();
		
		
	}
	
	void setButton(){
		//Button = GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildType2;
		Button = game_manager.StaticGameManager.BuildType2;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}
	
	void activateButton(){
		Active = true;
		//GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildTypeFORALL = 2;
		game_manager.StaticGameManager.BuildTypeFORALL = 5;
	}
}
