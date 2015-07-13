using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
//using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class room_properties : MonoBehaviour {
	public GameObject FirstCharacterSlot;


	public int RoomLevel;
	public int RoomLocation;
	public int RoomType;

	public int RoomSLOTLevel;
	public int RoomSLOTLocation;

	public int LadderSLOTLevel;
	//public int RoomSLOTLocation;

	public int LadderLevel;
	//public int RoomSLOTLocation;

	public string RoomName;
	private Vector3 RoomPosition;
	public float xPos;
	public float yPos;
	public float zPos;


	//room work slots
	public bool FirstSlot = false;
	public bool SecondSlot = false;
	
	void Start(){


		RoomName = this.gameObject.name;
		RoomPosition = this.transform.position;
		xPos = RoomPosition.x;
		yPos = RoomPosition.y;
		zPos = RoomPosition.z;
		//optimize this
		try{
		room_manager.StaticRoomManager.RoomArray.Remove (RoomName);
		}
		catch
		{
			Debug.Log("wtf am i doing");
		}
		room_manager.StaticRoomManager.RoomArray.Add (RoomName);


		AddResOnTimer ();

	}

	void AddResOnTimer(){
		if (RoomType == 4) {
			game_manager.StaticGameManager.ResW += 10 ;
		}
		if (RoomType == 5) {
			game_manager.StaticGameManager.ResS += 2 ;
		}

		Invoke ("AddResOnTimer", 5.0f);
	}

}


