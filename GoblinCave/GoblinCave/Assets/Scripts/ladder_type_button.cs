using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ladder_type_button : MonoBehaviour {

	private GameObject Button;
	public bool Active = false;
	
	void Start () {
		setButton ();
		
		
	}
	
	void setButton(){
		//Button = GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildType2;
		Button = game_manager.StaticGameManager.BuildTypeLadder;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}
	
	void activateButton(){
		Active = true;
		//GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildTypeFORALL = 2;
		game_manager.StaticGameManager.BuildTypeFORALL = 3;
	}
}
