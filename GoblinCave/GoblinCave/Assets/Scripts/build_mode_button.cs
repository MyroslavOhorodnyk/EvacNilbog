using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class build_mode_button : MonoBehaviour {
	public bool isShowing = false;
	private GameObject HideUnhideTemporary;
	private GameObject Button;

	void Start () {
		setButton ();
	}
	
	void setButton(){
		HideUnhideTemporary = game_manager.StaticGameManager.BuildButtonFolder;
		Button = game_manager.StaticGameManager.BuildButtonPopUp;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}

	void activateButton(){

		isShowing = !isShowing;
		
		HideUnhideTemporary.SetActive(isShowing);

	}


}
