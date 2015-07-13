using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class Loader_script : MonoBehaviour {

	//room prop bloc
	public string RoomName;
	public int RoomLevel;
	public int RoomLocation;
	public int RoomType;
	
	public int RoomSLOTLevel;
	public int RoomSLOTLocation;
	
	public int LadderSLOTLevel;
	//public int RoomSLOTLocation;
	
	public int LadderLevel;
	//public int RoomSLOTLocation;
	//position
	public float xPos;
	public float yPos;
	public float zPos;
	

	private Vector3 tempSlotVector;
	GameObject tempSlot1;
	GameObject RoomOperator;

	public List<string> RoomList;
	
	
	void Start()
	{
		if (File.Exists (Application.persistentDataPath + "/RoomList.dat")) 
		{
			//Load ();
			//InstantiateAllRooms ();
			CreateFirstLadder ();
		} else 
		{
			CreateFirstLadder ();
		}
	}


	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/RoomList.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open((Application.persistentDataPath + "/RoomList.dat"), FileMode.Open);
			RoomListCopySave RListCopy = (RoomListCopySave)bf.Deserialize(file);
			file.Close();


			game_manager.StaticGameManager.ResW = RListCopy.ResW;
			game_manager.StaticGameManager.ResS = RListCopy.ResS;
			room_manager.StaticRoomManager.RoomArray = RListCopy.RoomList;
			room_manager.StaticRoomManager.countGlobalActiveLevel = RListCopy.countGlobalActiveLevel;
			Debug.Log ("List found");

		}
	}

	public void InstantiateAllRooms(){
		//optimize this
		for (int i=0; i < room_manager.StaticRoomManager.RoomArray.Count; i++) {
			string fileCallName = room_manager.StaticRoomManager.RoomArray[i];

			LoadInstatiateOneRoom(fileCallName);
		}
	}


	public void LoadInstatiateOneRoom(string RoomFileName){
		if(File.Exists(Application.persistentDataPath + "/" + RoomFileName + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open((Application.persistentDataPath + "/" + RoomFileName + ".dat"), FileMode.Open);
			RoomPropertiesSave RoomData = (RoomPropertiesSave)bf.Deserialize(file);
			file.Close();
			
			RoomName = RoomData.RoomName;
			RoomLevel = RoomData.RoomLevel;
			RoomLocation = RoomData.RoomLocation;
			RoomType = RoomData.RoomType;
			RoomSLOTLevel = RoomData.RoomSLOTLevel;
			RoomSLOTLocation = RoomData.RoomSLOTLocation;
			LadderSLOTLevel = RoomData.LadderSLOTLevel;
			LadderLevel = RoomData.LadderLevel;
			xPos = RoomData.xPos;
			yPos = RoomData.yPos;
			zPos = RoomData.zPos;

			Debug.Log ("Room found");
			//Debug.Log (RoomType);

			if (RoomType == 1){
				RoomOperator = Instantiate(room_manager.StaticRoomManager.LadderSLOT) as GameObject;
			}
			else if (RoomType == 2){
				RoomOperator = Instantiate(room_manager.StaticRoomManager.firstRoomSLOT) as GameObject;
			}
			else if (RoomType == 3){
				RoomOperator = Instantiate(room_manager.StaticRoomManager.Ladder) as GameObject;
			}
			else if (RoomType == 4){
				RoomOperator = Instantiate(room_manager.StaticRoomManager.firstRoom1lv) as GameObject;
			}
			else if (RoomType == 5){
				RoomOperator = Instantiate(room_manager.StaticRoomManager.secondRoom1lv) as GameObject;
			}
			else {
				//CreateFirstLadder ();
				return;
			}
			RoomOperator.transform.position = new Vector3(xPos, yPos, zPos);
			RoomOperator.name = RoomName;
			RoomOperator.GetComponent<room_properties>().RoomType = RoomType;
			RoomOperator.GetComponent<room_properties>().RoomLevel = RoomLevel;
			RoomOperator.GetComponent<room_properties>().RoomLocation = RoomLocation;
			RoomOperator.GetComponent<room_properties>().RoomSLOTLevel = RoomSLOTLevel;
			RoomOperator.GetComponent<room_properties>().RoomSLOTLocation = RoomSLOTLocation;
			RoomOperator.GetComponent<room_properties>().LadderSLOTLevel = LadderSLOTLevel;
			RoomOperator.GetComponent<room_properties>().LadderLevel = LadderLevel;
		}

	}

	
	
	// Use this for initialization
	void CreateFirstLadder () {
		//check if there is a first ladder , if not create a slot
		if (!GameObject.Find ("Ladder(0)")) {
			GameObject tempSlot = room_manager.StaticRoomManager.LadderSLOT;
			tempSlotVector = new Vector3(3.31f,-2.19f,-0.2f);
			tempSlot1 = Instantiate (tempSlot , tempSlotVector, Quaternion.identity) as GameObject;
			tempSlot1.name = ("LadderSlot");
			
		}
	}

}

/*
[System.Serializable]
class RoomListCopy {
	public List<string> RoomList;
	
}
*/