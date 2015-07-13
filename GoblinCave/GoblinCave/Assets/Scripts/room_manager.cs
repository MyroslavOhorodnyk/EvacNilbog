using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class room_manager : MonoBehaviour {
	public static room_manager StaticRoomManager;

	//rooms
	public GameObject firstRoom1lv;
	public GameObject secondRoom1lv;
	public GameObject Ladder;

	//room list array
	public List<string> RoomArray;
	public int countGlobalActiveLevel = 0;


	//room slots
	public GameObject firstRoomSLOT;
	public GameObject LadderSLOT;

	void Awake(){
		if (StaticRoomManager == null) {
			DontDestroyOnLoad (gameObject);
			StaticRoomManager = this;
		}else if(StaticRoomManager != this){
			
			Destroy(gameObject);
		}
		
	}

}
