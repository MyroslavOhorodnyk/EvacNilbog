using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class build_all : MonoBehaviour {
	public bool BuildMode;

	public int countMaxLevels = 0;
	public int countLevel = 0;
	

	private GameObject Button;
	private GameObject Spawnroom;
	private GameObject Spawned;
	private GameObject Target;
	private GameObject SpawnladderSlot;
	private GameObject SpawnRoomSlot;

	//private Button InGameExitButton;

	private GameObject ButtonLadder;
	private GameObject Spawnladder;

	private Vector3 Slot;
	private Vector3 LadderSlotCoord;
	private Vector3 RoomSlotCoord;
	private Vector3 resetVector = Vector3.zero;


	private int ParseTypeINT;
	private int LocationInt;
	private int LevelInt;
	
	private float LadderSlotOffset = -7.0f;
	private float RoomLadderSlotOffset = 11.0f;
	private float RoomRoomSlotOffset = 15.0f;



	// Use this for initialization
	void Start () {
		//InGameExitButton = InGameExitButton.GetComponent<Button>();
		setButton ();

	}


	void setButton(){
		Button = game_manager.StaticGameManager.BuildButton;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}

	void activateButton(){
		BuildMode = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (BuildMode == true) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				try
				{
					Debug.Log ("CLICK");
					ParseTypeINT = game_manager.StaticGameManager.BuildTypeFORALL;
					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
					Target = GameObject.Find(hit.collider.name);
					Slot = (hit.transform.position);
				
				
					if(ParseTypeINT >= 4)
					{
						Debug.Log ("CLICK 1-1");
						if (hit.collider.name != null && hit.collider.tag == "CaveSlot") {
						LocationInt = Target.GetComponent<room_properties> ().RoomSLOTLocation;
						LevelInt = Target.GetComponent<room_properties> ().RoomSLOTLevel;
						tempBuildRoom (Slot, Target, LocationInt,LevelInt);
						BuildSlotsNearbyRoom (Slot, LocationInt,LevelInt);
					}
					}
					if(ParseTypeINT == 3)
					{
						Debug.Log ("CLICK 2-1");
						if (hit.collider.name != null && hit.collider.tag == "LadderSlot") 
						{
							tempBuildLadder (Slot, Target);
							countLevel += 1; //add 1 to level properties component before making slots
							room_manager.StaticRoomManager.countGlobalActiveLevel += 1;
							BuildSlotsNearbyLadder (Slot);	
						}
					}
					else
					{
						BuildMode = false;
					}
				}
				catch(Exception ex)
				{
					print("error!");
				}
			}
		}
	
	}

	//other functions

	//room-type build ROOM
	void tempBuildRoom(Vector3 coordinates, GameObject DestrSlot, int Location, int Level){
		
		if (BuildMode == true) {
			if(ParseTypeINT == 4){
				Spawnroom = room_manager.StaticRoomManager.firstRoom1lv;
			}
			if(ParseTypeINT == 5){
				Spawnroom = room_manager.StaticRoomManager.secondRoom1lv;
			}
			else{
				//Debug.Log ("MAJOR ERROR TEMP BUILD ROOM, INT PROBABLY == 1");
			}
			Spawned = (GameObject)Instantiate (Spawnroom);
			Spawned.name = "Room(X_" + Location + ")(Y_" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomLocation = Location;
			Spawned.GetComponent<room_properties>().RoomLevel = Level;
			Spawned.GetComponent<room_properties>().RoomType = ParseTypeINT;
			Spawned.transform.position = coordinates;
			BuildMode = false;
			Destroy(DestrSlot);
			room_manager.StaticRoomManager.RoomArray.Remove (DestrSlot.name);
			
			
		} else {
			return;
		}
	}

	//room_type build slots
	void BuildSlotsNearbyRoom(Vector3 coordinates, int Location, int Level){
		float coordinatesX = coordinates.x;
		float coordinatesY = coordinates.y;
		float coordinatesZ = coordinates.z;
		if (Location < 0 && Location > -3) {
			SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
			Spawned = (GameObject)Instantiate (SpawnRoomSlot);
			Spawned.name = "RoomSlot(X_" + (Location - 1) + ")(Y_" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomSLOTLocation = Location - 1;
			Spawned.GetComponent<room_properties> ().RoomSLOTLevel = Level;
			Spawned.GetComponent<room_properties>().RoomType = 2;
			RoomSlotCoord = new Vector3 (coordinatesX - RoomRoomSlotOffset, coordinatesY, coordinatesZ);
			Spawned.transform.position = RoomSlotCoord;
		}
		if (Location > 0 && Location < 3) {
			SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
			Spawned = (GameObject)Instantiate (SpawnRoomSlot);
			Spawned.name = "RoomSlot(X_" + (Location + 1) + ")(Y_" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomSLOTLocation = Location + 1;
			Spawned.GetComponent<room_properties> ().RoomSLOTLevel = Level;
			Spawned.GetComponent<room_properties>().RoomType = 2;
			RoomSlotCoord = new Vector3 (coordinatesX + RoomRoomSlotOffset, coordinatesY, coordinatesZ);
			Spawned.transform.position = RoomSlotCoord;
		}
	}
	
	//ladder-type build ladder
	void tempBuildLadder(Vector3 coordinates, GameObject DestrSlot){
		//if (BuildMode == true && countMaxLevels <= 3) {
		if (BuildMode == true && room_manager.StaticRoomManager.countGlobalActiveLevel <= 6) {
			Spawnladder = room_manager.StaticRoomManager.Ladder;
			Spawned = (GameObject)Instantiate (Spawnladder);
			Spawned.transform.position = coordinates;
			//Spawned.name = "Ladder(" + countMaxLevels + ")";
			Spawned.name = "Ladder(" + room_manager.StaticRoomManager.countGlobalActiveLevel + ")";
			Spawned.GetComponent<room_properties>().RoomType = 3;
			BuildMode = false;
			Destroy(DestrSlot);
			room_manager.StaticRoomManager.RoomArray.Remove (DestrSlot.name);
			coordinates = resetVector;
			//countMaxLevels += 1;
			//Spawned.GetComponent<room_properties> ().LadderLevel = countLevel;
			Spawned.GetComponent<room_properties> ().LadderLevel = room_manager.StaticRoomManager.countGlobalActiveLevel;
			
		} else {
			BuildMode = false;
			return;
		}
	}

	//ladder-type build slots
	void BuildSlotsNearbyLadder(Vector3 coordinates){
		float coordinatesX = coordinates.x;
		float coordinatesY = coordinates.y;
		float coordinatesZ = coordinates.z;
		//if (countMaxLevels <= 3) {
			if (room_manager.StaticRoomManager.countGlobalActiveLevel <=6){
			//build ladder 1 level lower
			SpawnladderSlot = room_manager.StaticRoomManager.LadderSLOT;
			Spawned = (GameObject)Instantiate (SpawnladderSlot);
			//Spawned.name = "LadderSlot(" + (countMaxLevels) + ")";
			Spawned.name = "LadderSlot(" + (room_manager.StaticRoomManager.countGlobalActiveLevel) + ")";
			LadderSlotCoord = new Vector3 (coordinatesX, coordinatesY + LadderSlotOffset, coordinatesZ);
			Spawned.transform.position = LadderSlotCoord;
			//Spawned.GetComponent<room_properties> ().LadderSLOTLevel = countLevel;
			Spawned.GetComponent<room_properties> ().LadderSLOTLevel = room_manager.StaticRoomManager.countGlobalActiveLevel;
			Spawned.GetComponent<room_properties>().RoomType = 1;
		}
		//generate room slots
		//left room
		SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
		Spawned = (GameObject)Instantiate (SpawnRoomSlot);
		//Spawned.name = "RoomSlot(X_" + (-1) + ")(Y_" + (countLevel-1) + ")";
		Spawned.name = "RoomSlot(X_" + (-1) + ")(Y_" + (room_manager.StaticRoomManager.countGlobalActiveLevel-1) + ")";
		RoomSlotCoord = new Vector3 (coordinatesX - RoomLadderSlotOffset, coordinatesY, coordinatesZ);
		Spawned.transform.position = RoomSlotCoord;
		Spawned.GetComponent<room_properties> ().RoomSLOTLocation = -1;
		//Spawned.GetComponent<room_properties> ().RoomSLOTLevel = countLevel-1;
		Spawned.GetComponent<room_properties> ().RoomSLOTLevel = room_manager.StaticRoomManager.countGlobalActiveLevel-1;
		Spawned.GetComponent<room_properties>().RoomType = 2;
		
		//right room
		Spawned = (GameObject)Instantiate (SpawnRoomSlot);
		//Spawned.name = "RoomSlot(X_" + 1 + ")(Y_" + (countLevel-1) + ")";
		Spawned.name = "RoomSlot(X_" + 1 + ")(Y_" + (room_manager.StaticRoomManager.countGlobalActiveLevel-1) + ")";
		RoomSlotCoord = new Vector3 (coordinatesX + RoomLadderSlotOffset, coordinatesY, coordinatesZ);
		Spawned.transform.position = RoomSlotCoord;
		Spawned.GetComponent<room_properties> ().RoomSLOTLocation = 1;
		//Spawned.GetComponent<room_properties> ().RoomSLOTLevel = countLevel-1;
		Spawned.GetComponent<room_properties> ().RoomSLOTLevel = room_manager.StaticRoomManager.countGlobalActiveLevel-1;
		Spawned.GetComponent<room_properties>().RoomType = 2;
	}

	//_______________________________________________________________________________
	//Button for in game exit (needs to be replaced)
	
	public void InGameExit ()
	{
		Application.Quit();
	}
}
