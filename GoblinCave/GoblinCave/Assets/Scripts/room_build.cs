using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class room_build : MonoBehaviour {
	//legacy
	/*
	private GameObject Button;
	private GameObject Spawnroom;
	private GameObject Spawned;
	private GameObject Target;
	public bool BuildMode;
	private Vector3 Slot;

	private GameObject SpawnRoomSlot;
	private float RoomSlotOffset = 15.0f;
	private Vector3 RoomSlotCoord;
	private int LocationInt;
	private int LevelInt;
	private int ParseTypeINT;

	// Use this for initialization
	void Start () {
		setButton ();

	
	}
	
	void setButton(){
		//Button = GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildButton;
		Button = game_manager.StaticGameManager.BuildButton;
		Button.GetComponent<Button> ().onClick.AddListener (activateButton);
	}

	void activateButton(){
		BuildMode = true;

		//GameObject DeactivateOther = GameObject.Find ("GameManager").GetComponent<game_manager>().BuildButtonLadder;
		GameObject DeactivateOther = game_manager.StaticGameManager.BuildButtonLadder;
		DeactivateOther.GetComponent<ladder_build> ().BuildMode = false;
	}

	void Update(){
		if (BuildMode == true) {
			if (Input.GetMouseButtonDown (0)) {
				//ParseTypeINT =  GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildTypeFORALL;
				ParseTypeINT = game_manager.StaticGameManager.BuildTypeFORALL;
				Debug.Log ("CLICK");
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider.name != null && hit.collider.tag == "CaveSlot") {
					Debug.Log (hit.collider.name);
					Target = GameObject.Find(hit.collider.name);
					Slot = (hit.transform.position);
					LocationInt = Target.GetComponent<room_properties> ().RoomSLOTLocation;
					LevelInt = Target.GetComponent<room_properties> ().RoomSLOTLevel;
					tempBuild (Slot, Target, LocationInt,LevelInt);
					BuildSlotsNearby (Slot, LocationInt,LevelInt);
				}
				else{
					BuildMode = false;
				}

			}
		}

	}

	void tempBuild(Vector3 coordinates, GameObject DestrSlot, int Location, int Level){

		if (BuildMode == true) {
			if(ParseTypeINT == 2){
				//Spawnroom = GameObject.Find ("RoomManager").GetComponent<room_manager> ().firstRoom1lv;
				Spawnroom = room_manager.StaticRoomManager.firstRoom1lv;
			}
			else{
				//Spawnroom = GameObject.Find ("RoomManager").GetComponent<room_manager> ().secondRoom1lv;
				Spawnroom = room_manager.StaticRoomManager.secondRoom1lv;
			}
			Spawned = (GameObject)Instantiate (Spawnroom);
			Spawned.name = "RoomSlot(X:" + Location + ")(Y:" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomLocation = Location;
			Spawned.GetComponent<room_properties>().RoomLevel = Level;
			Spawned.transform.position = coordinates;
			BuildMode = false;
			Destroy(DestrSlot);
			//SetROOMtype();


		} else {
			return;
		}
	}
	//build slots

	void BuildSlotsNearby(Vector3 coordinates, int Location, int Level){
		float coordinatesX = coordinates.x;
		float coordinatesY = coordinates.y;
		float coordinatesZ = coordinates.z;
		if (Location < 0 && Location > -2) {
			//SpawnRoomSlot = GameObject.Find ("RoomManager").GetComponent<room_manager> ().firstRoomSLOT;
			SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
			Spawned = (GameObject)Instantiate (SpawnRoomSlot);
			Spawned.name = "RoomSlot(X:" + (Location - 1) + ")(Y:" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomSLOTLocation = Location - 1;
			Spawned.GetComponent<room_properties> ().RoomSLOTLevel = Level;
			RoomSlotCoord = new Vector3 (coordinatesX - RoomSlotOffset, coordinatesY, coordinatesZ);
			Spawned.transform.position = RoomSlotCoord;
		}
		if (Location > 0 && Location < 2) {
			//SpawnRoomSlot = GameObject.Find ("RoomManager").GetComponent<room_manager> ().firstRoomSLOT;
			SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
			Spawned = (GameObject)Instantiate (SpawnRoomSlot);
			Spawned.name = "RoomSlot(X:" + (Location + 1) + ")(Y:" + Level + ")";
			Spawned.GetComponent<room_properties>().RoomSLOTLocation = Location + 1;
			Spawned.GetComponent<room_properties> ().RoomSLOTLevel = Level;
			RoomSlotCoord = new Vector3 (coordinatesX + RoomSlotOffset, coordinatesY, coordinatesZ);
			Spawned.transform.position = RoomSlotCoord;
		}
	}

*/
}