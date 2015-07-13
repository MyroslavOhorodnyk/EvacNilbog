using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


public class Save_module : MonoBehaviour {
	public static Save_module SaveRoom;


	private GameObject Button;

	void Awake () {
		if(SaveRoom == null)
		{
			DontDestroyOnLoad(gameObject);
			SaveRoom = this;
		}
		else if(SaveRoom != this)
		{
			Destroy(gameObject);
		}
	}

	void Start () {
		setButton ();
	}


	void setButton(){

		Button = this.gameObject;
		Button.GetComponent<Button> ().onClick.AddListener (CallSave);
	}

	void CallSave(){
		//optimize this
		for (int i=0; i < room_manager.StaticRoomManager.RoomArray.Count; i++) {
			string fileCallName = room_manager.StaticRoomManager.RoomArray[i];
			Save(fileCallName);

		}
		SaveRoomList();
	}

	void Save (string FileName) {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/" + FileName + ".dat");
		
		RoomPropertiesSave RoomData = new RoomPropertiesSave();
		GameObject TargetProps = GameObject.Find (FileName);
		RoomData.RoomLevel = TargetProps.GetComponent<room_properties> ().RoomLevel;
		RoomData.RoomLocation = TargetProps.GetComponent<room_properties> ().RoomLocation;
		RoomData.RoomType = TargetProps.GetComponent<room_properties> ().RoomType;
		RoomData.RoomSLOTLevel = TargetProps.GetComponent<room_properties> ().RoomSLOTLevel;
		RoomData.RoomSLOTLocation = TargetProps.GetComponent<room_properties> ().RoomSLOTLocation;
		RoomData.LadderSLOTLevel = TargetProps.GetComponent<room_properties> ().LadderSLOTLevel;
		RoomData.LadderLevel = TargetProps.GetComponent<room_properties> ().LadderLevel;
		RoomData.RoomName = TargetProps.GetComponent<room_properties> ().RoomName;
		RoomData.xPos = TargetProps.GetComponent<room_properties> ().xPos;
		RoomData.yPos = TargetProps.GetComponent<room_properties> ().yPos;
		RoomData.zPos = TargetProps.GetComponent<room_properties> ().zPos;
		Debug.Log(FileName + "- Saved");

		bf.Serialize(file, RoomData);
		file.Close();
	}



	void SaveRoomList(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/RoomList.dat");
		RoomListCopySave RListCopy = new RoomListCopySave();
		RListCopy.RoomList = room_manager.StaticRoomManager.RoomArray;
		RListCopy.countGlobalActiveLevel = room_manager.StaticRoomManager.countGlobalActiveLevel;
		RListCopy.ResS = game_manager.StaticGameManager.ResS;
		RListCopy.ResW = game_manager.StaticGameManager.ResW;


		Debug.Log( "List - Saved");
		bf.Serialize(file, RListCopy);
		file.Close();
	}
	





}

[System.Serializable]
class RoomListCopySave {

	public List<string> RoomList;
	public int countGlobalActiveLevel;
	//later move to misc save script
	public int ResW;
	public int ResS;
}



[System.Serializable]
class RoomPropertiesSave {
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
	public float xPos;
	public float yPos;
	public float zPos;
}


