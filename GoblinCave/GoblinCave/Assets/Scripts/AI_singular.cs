using UnityEngine;
using System.Collections;

public class AI_singular : MonoBehaviour {
	//onMouse block
	private Color mouseOverColor = Color.green;
	private Color originalColor = Color.white;
	//status check code block
	public GameObject Currentlocation;
	public GameObject Target;


	//commands block
	public Vector3 CurrentTargetPos;//used for movement
	public float Speed = 4.0f; //changed based on character class and stats

	public string CommandSingAI; //used when calling this script
	public string CurrentState; //used for sheduling the movement
	public Transform CharacterPos;
	
	//location properties
	public int GoblinLevel;
	public int GoblinLocation;
	public GameObject HomeRoom; //room where the goblin is at the moment, is used in code
	public bool OnUpperLevel = true; //means that the character didnt enter the cave
	public bool IsMember = false; //has been approved as a citizen


	public bool Statustrigger = false; // triggers the status check for later command

	private int CLLevel;
	private int CLLocation;
	private int TargetLevel;
	private int TargetLocation;
	public int GoblinPosition = 1;
	
	void Start(){
		//set starting properties
		CommandSingAI = "Stay";
		CurrentState = "Stay";
		GoblinLevel = -1; //this part of code says that it has no room, is waiting outside
		GoblinLocation = 0;
		HomeRoom = null; //may be deleted
		CharacterPos = this.gameObject.transform;

	}
	

	void StatusCheck(){
		if(Currentlocation == null ){ //if goblin doesnt have a base
			Currentlocation = GameObject.Find("Cave");
		}
		//parse target location properties and current location properties


		if (Statustrigger == true && OnUpperLevel == true) {
			CommandSingAI = "Enter cave and his room";
			CurrentState = "Waiting outside";
			CurrentTargetPos = this.gameObject.transform.position;
		}
		if (Statustrigger == true && OnUpperLevel == false) { //TEMPORARY
			LeavePosition();
			CLLevel = Currentlocation.GetComponent<room_properties> ().RoomLevel;
			//CLLocation = Currentlocation.GetComponent<room_properties> ().RoomLocation;
			TargetLevel = Target.GetComponent<room_properties> ().RoomLevel;
			//TargetLocation = Target.GetComponent<room_properties> ().RoomLocation;
			if(CLLevel != TargetLevel){
				CommandSingAI = "Move to Target room";
				CurrentState = "MoveToLocalLadder";
				CurrentTargetPos = this.gameObject.transform.position;	
			}
			else if(CLLevel == TargetLevel){
				CommandSingAI = "Move to Target room";
				CurrentState = "Moving to target ladder";
				CurrentTargetPos = this.gameObject.transform.position;
			}
		}
		Statustrigger = false;
	}

	void LeavePosition(){
		Debug.Log ("left position");
		if (GoblinPosition == 1) {
			Debug.Log ("left position 1");
			Currentlocation.GetComponent<room_properties>().FirstSlot = false;
			GoblinPosition = 0;
		}
		else if (GoblinPosition == 2) {
			Debug.Log ("left position 2");
			Currentlocation.GetComponent<room_properties>().SecondSlot = false;
			GoblinPosition = 0;
		}


	}
	
	void FixedUpdate () {
		StatusCheck ();
		if(Target != null){
			if(CommandSingAI == "Enter cave and his room"){
				CharacterPos.position = Vector3.MoveTowards (CharacterPos.position, CurrentTargetPos, Speed*Time.deltaTime);		
				if (CharacterPos.position == CurrentTargetPos) {
					EnterCave();
				}
			}
			if(CommandSingAI == "Move to Target room"){
				CharacterPos.position = Vector3.MoveTowards (CharacterPos.position, CurrentTargetPos, Speed*Time.deltaTime);		
				if (CharacterPos.position == CurrentTargetPos) {
					ChangeRoom();
				}
			}
		}
	}
	
	
	void EnterCave (){
		if(CommandSingAI == "Enter cave and his room"){
			if(CurrentState == "Waiting outside"){
				CurrentTargetPos = GameObject.Find("Cave").GetComponent<Transform>().position;
				CurrentState = "Moving to cave";
				IsMember = true;
				Currentlocation =  GameObject.Find("Cave");
			}
			else if(CurrentState == "Moving to cave"){
				OnUpperLevel = false;
				int LTarget = Target.GetComponent<room_properties> ().RoomLevel;
				CurrentTargetPos = GameObject.Find ("Ladder(" + LTarget +")").GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
				CurrentState = "Moving to target ladder";
				Currentlocation = GameObject.Find ("Ladder(" + LTarget +")");
			}
			else if(CurrentState == "Moving to target ladder"){
				CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
				Currentlocation = Target;			
				CurrentState = "Moving to room";
			}
			else if(CurrentState == "Moving to room"){
				if(Target.GetComponent<room_properties>().FirstSlot == false){
					CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(1).GetComponent<Transform>().position;
					Target.GetComponent<room_properties>().FirstSlot = true;
					GoblinPosition = 1;
					CurrentState = "Go to Work";
					Currentlocation = Target;
				}
				else if(Target.GetComponent<room_properties>().SecondSlot == false){
					CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(2).GetComponent<Transform>().position;
					Target.GetComponent<room_properties>().SecondSlot = true;
					GoblinPosition = 2;
					CurrentState = "Go to Work";
					Currentlocation = Target;
				}

				
			}
			else if(CurrentState == "Go to Work"){
				CurrentState = "Working";
				CommandSingAI = " ";
			}
		}
	}
	void ChangeRoom(){
		if(CommandSingAI == "Move to Target room"){
			if(CurrentState == "Moving to local ladder"){
				
				int LTarget = Target.GetComponent<room_properties> ().RoomLevel;
				CurrentTargetPos = GameObject.Find ("Ladder(" + LTarget +")").GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
				Currentlocation = GameObject.Find ("Ladder(" + LTarget +")");
				CurrentState = "Moving to target ladder";
			}
			else if(CurrentState == "Moving to target ladder"){
				CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
				//Currentlocation = Target;
				CurrentState = "Moving to target";
			}
			else if(CurrentState == "Moving to target"){
				//CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(1).GetComponent<Transform>().position;
				if(Target.GetComponent<room_properties>().FirstSlot == false){
					CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(1).GetComponent<Transform>().position;
					Target.GetComponent<room_properties>().FirstSlot = true;
					GoblinPosition = 1;
					Currentlocation = Target;
					CurrentState = "Go to Work";
				}
				else if(Target.GetComponent<room_properties>().SecondSlot == false){
					CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(2).GetComponent<Transform>().position;
					Target.GetComponent<room_properties>().SecondSlot = true;
					GoblinPosition = 2;
					CurrentState = "Go to Work";
					Currentlocation = Target;

				}
				else if(Target.GetComponent<room_properties>().SecondSlot == false && Target.GetComponent<room_properties>().FirstSlot == false){
					CurrentTargetPos = Target.GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
					Currentlocation = Target;
					GoblinPosition = 0;
					CurrentState = "Go to Work";
				}

			}
			else if(CurrentState == "Go to Work"){
				CurrentState = "Working";
				CommandSingAI = " ";
			}
			else if(CurrentState == "MoveToLocalLadder"){
				int LBase = Currentlocation.GetComponent<room_properties> ().RoomLevel;
				CurrentTargetPos = GameObject.Find ("Ladder(" + LBase +")").GetComponent<Transform> ().GetChild(0).GetComponent<Transform>().position;
				CurrentState = "Moving to local ladder";
			}
		}
	}






	void OnMouseEnter()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().color = mouseOverColor;
		//SpriteRenderer.color = mouseOverColor;
	}
	
	void OnMouseExit()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
		//SpriteRenderer.color = originalColor;
	}
}
