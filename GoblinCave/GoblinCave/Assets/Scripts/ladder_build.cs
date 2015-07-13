using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ladder_build : MonoBehaviour {
	//legacy
	/*
	private GameObject ButtonLadder;
	private GameObject Spawnladder;
	private GameObject Spawned;
	private GameObject Target;
	public bool BuildMode;
	private Vector3 Slot;
	private float LadderSlotOffset = -7.0f;
	private float RoomSlotOffset = 11.0f;
	private Vector3 LadderSlotCoord;
	private Vector3 RoomSlotCoord;
	private Vector3 resetVector = Vector3.zero;

	public int countMaxLevels = 0;
	public int countLevel = 0;


	private GameObject SpawnladderSlot;
	private GameObject SpawnRoomSlot;

	// Use this for initialization
	void Start () {
		setButton ();
		
		
	}
	
	void setButton(){
		//ButtonLadder = GameObject.Find ("GameManager").GetComponent<game_manager> ().BuildButtonLadder;
		ButtonLadder = game_manager.StaticGameManager.BuildButtonLadder;
		ButtonLadder.GetComponent<Button>().onClick.AddListener (activateButton);

	}
	
	void activateButton(){
		BuildMode = true;
		//GameObject DeactivateOther = GameObject.Find ("GameManager").GetComponent<game_manager>().BuildButton;
		GameObject DeactivateOther = game_manager.StaticGameManager.BuildButton;
		DeactivateOther.GetComponent<room_build> ().BuildMode = false;
	}
	
	void Update(){
		if (BuildMode == true) {
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("CLICK");
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider.name != null && hit.collider.tag == "LadderSlot") {
					Debug.Log (hit.collider.name);
					Target = GameObject.Find(hit.collider.name);
					Slot = (hit.transform.position);
					tempBuild (Slot, Target);
					countLevel += 1; //add 1 to level properties component before making slots
					BuildSlotsNearby (Slot);
					Slot = Vector3.zero;
				
				}
				else{
					BuildMode = false;
				}
			}
		}
		
	}
	//build ladder
	void tempBuild(Vector3 coordinates, GameObject DestrSlot){
		if (BuildMode == true && countMaxLevels <= 2) {
			//Debug.Log ("generate ladder");
			//Spawnladder = GameObject.Find ("RoomManager").GetComponent<room_manager> ().Ladder;
			Spawnladder = room_manager.StaticRoomManager.Ladder;
			Spawned = (GameObject)Instantiate (Spawnladder);
			Spawned.transform.position = coordinates;
			Spawned.name = "Ladder(" + countMaxLevels + ")";
			BuildMode = false;
			Destroy(DestrSlot);
			coordinates = resetVector;
			countMaxLevels += 1;
			Spawned.GetComponent<room_properties> ().LadderLevel = countLevel;

		} else {
			BuildMode = false;
			return;
		}
	}

	//build slots 
	void BuildSlotsNearby(Vector3 coordinates){
		float coordinatesX = coordinates.x;
		float coordinatesY = coordinates.y;
		float coordinatesZ = coordinates.z;
		if (countMaxLevels <= 2) {
			//build ladder 1 level lower

			//SpawnladderSlot = GameObject.Find ("RoomManager").GetComponent<room_manager> ().LadderSLOT;
			SpawnladderSlot = room_manager.StaticRoomManager.LadderSLOT;
			Spawned = (GameObject)Instantiate (SpawnladderSlot);
			Spawned.name = "LadderSlot(" + (countMaxLevels) + ")";
			LadderSlotCoord = new Vector3 (coordinatesX, coordinatesY + LadderSlotOffset, coordinatesZ);
			Spawned.transform.position = LadderSlotCoord;
			Spawned.GetComponent<room_properties> ().LadderSLOTLevel = countLevel;
		}
		//generate room slots
		//left room

		//SpawnRoomSlot = GameObject.Find ("RoomManager").GetComponent<room_manager> ().firstRoomSLOT;
		SpawnRoomSlot = room_manager.StaticRoomManager.firstRoomSLOT;
		Spawned = (GameObject)Instantiate (SpawnRoomSlot);
		//Spawned.name = "RoomSlot(" + "-" + (countMaxLevels-1) + ")";
		Spawned.name = "RoomSlot(X:" + (-1) + ")(Y:" + (countLevel-1) + ")";
		RoomSlotCoord = new Vector3 (coordinatesX - RoomSlotOffset, coordinatesY, coordinatesZ);
		Spawned.transform.position = RoomSlotCoord;
		Spawned.GetComponent<room_properties> ().RoomSLOTLocation = -1;
		Spawned.GetComponent<room_properties> ().RoomSLOTLevel = countLevel-1;

		//right room
		Spawned = (GameObject)Instantiate (SpawnRoomSlot);
		//Spawned.name = "RoomSlot(" + (countMaxLevels-1) + ")";
		Spawned.name = "RoomSlot(X:" + 1 + ")(Y:" + (countLevel-1) + ")";
		RoomSlotCoord = new Vector3 (coordinatesX + RoomSlotOffset, coordinatesY, coordinatesZ);
		Spawned.transform.position = RoomSlotCoord;
		Spawned.GetComponent<room_properties> ().RoomSLOTLocation = 1;
		Spawned.GetComponent<room_properties> ().RoomSLOTLevel = countLevel-1;
	}
*/
}
