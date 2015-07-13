using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AI_controller : MonoBehaviour {

	public static AI_controller AIc;
	//general character conroller block
	public List<string> CharArray; //list of characters (for save)
	public GameObject charPrefab; //link to prefab
	public int GoblinCount = 0; //counting goblins for names
	private string ZeroPads; //adding zeroes for goblins


	//this script code block
	private GameObject Goblin; //using in code
	private GameObject CmdTargetGoblin;
	private GameObject TargetRoom;
	


	//camera activity block
	private bool Drag = false;
	private camera_dragMove CameraDrag;



	// Use this for initialization
	void Start () {
		CameraDrag = GameObject.Find ("Main Camera").GetComponent<camera_dragMove>();//find camera script
		Vector3 allah = new Vector3 (12.5f, 3.17f, -0.16f); //temporary start pos, later edit this
		CreateGoblin(allah); //later edit this and set this as a trigger
	}
	
	// Update is called once per frame
	void Update () {
		DragGoblin ();	
	}
	//creates one goblin in a first position ONSTART, gives name to it
	void CreateGoblin(Vector3 position){
		//put stat and visual randomization here
		Goblin = (GameObject)Instantiate (charPrefab);
		Goblin.transform.position = position;
		GoblinCount += 1;
		Goblin.name = ("G" + GoblinCount.ToString().PadLeft(4, '0'));
		
	}


	void DragGoblin()
	{
		try {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hitG = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				Debug.Log ("click");
				if (hitG.collider.tag == "Goblin") {
					Drag = true;
					CameraDrag.CameraGoblinDrag = Drag; //deactivate camera drag
					CmdTargetGoblin = GameObject.Find (hitG.collider.name);
					Debug.Log ("found goblin:" + CmdTargetGoblin);
				}
			}

			if (Input.GetMouseButtonUp (0) && Drag == true) {
				Debug.Log ("click up");
				RaycastHit2D hitR = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hitR.collider.tag == "CaveRoom" && Drag == true) {
					TargetRoom = GameObject.Find (hitR.collider.name);
					AccesGoblinAIcmd (CmdTargetGoblin, TargetRoom);
				}
				Drag = false;
				CameraDrag.CameraGoblinDrag = Drag; //activate camera drag
			}
		} catch (Exception e) {
			print ("error");
		}
	}

	
	void AccesGoblinAIcmd(GameObject GTarget, GameObject RTarget){
		Debug.Log ("give command");
		AI_singular GoblinAI = GTarget.GetComponent<AI_singular> ();
		GoblinAI.Statustrigger = true;
		GoblinAI.Target = RTarget;

	}



}
