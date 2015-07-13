using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resource_add : MonoBehaviour {
	public Resource_add CallRes;
   
	private Text ResText;
	// Use this for initialization
	void Start () {
		ResText = GameObject.Find ("Resources").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ResText.text = ("Resources- Wood:" + game_manager.StaticGameManager.ResW.ToString() + " Steel:" + game_manager.StaticGameManager.ResS.ToString());
	}





}
