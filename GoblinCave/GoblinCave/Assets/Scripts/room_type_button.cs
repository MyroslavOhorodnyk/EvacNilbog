using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class room_type_button : MonoBehaviour {
	private GameObject Button;
	public bool Active = false;
	
	void Start () {
		setButton ();
		
		
	}
	
	void setButton(){
		//Button = GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildType1;
		Button = game_manager.StaticGameManager.BuildType1;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}
	
	void activateButton(){
		Active = true;
		//GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildTypeFORALL = 1;
		game_manager.StaticGameManager.BuildTypeFORALL = 4;
	}
}
