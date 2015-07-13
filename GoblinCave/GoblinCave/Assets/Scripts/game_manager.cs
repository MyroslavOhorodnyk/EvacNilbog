using UnityEngine;
using System.Collections;

public class game_manager : MonoBehaviour {
	public static game_manager StaticGameManager;

	public GameObject BuildButton;
	//public GameObject BuildButtonLadder;
	public GameObject BuildType1;
	public GameObject BuildType2;
	public GameObject BuildTypeLadder;

	public GameObject BuildButtonFolder;
	public GameObject BuildButtonPopUp;

	
	public int BuildTypeFORALL = 3;

	public int ResW = 0;
	public int ResS = 0;

	void Awake(){
		if (StaticGameManager == null) {
			DontDestroyOnLoad (gameObject);
			StaticGameManager = this;
		}else if(StaticGameManager != this){
			Destroy(gameObject);
		}
	}
}


