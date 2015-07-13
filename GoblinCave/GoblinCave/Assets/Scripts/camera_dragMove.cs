using UnityEngine;
using System.Collections;

public class camera_dragMove : MonoBehaviour {

	private Vector3 ResetCamera;
	private Vector3 Origin;
	private Vector3 Diference;
	private Vector3 ZoomOrigin;//temp
	private bool Drag=false;
	public bool CameraGoblinDrag=false;
	//private float ZoomDist = 0.5f;

	void Start () {
		ResetCamera = Camera.main.transform.position;
	}
	void LateUpdate () {
		if(CameraGoblinDrag == false){
			if (Input.GetMouseButton (0)) {
				Diference=(Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
				if (Drag==false){
					Drag=true;
					Origin=Camera.main.ScreenToWorldPoint (Input.mousePosition);
				}
			} else {
				Drag=false;
			}
			if (Drag==true){
				Camera.main.transform.position = Origin-Diference;
			}

			//RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
			if (Input.GetMouseButton (1)) {
				Camera.main.transform.position=ResetCamera;
			}
			if (Input.GetMouseButtonDown (2)) {
				ZoomOrigin=Camera.main.ScreenToWorldPoint (Input.mousePosition);

			}
			if (Input.GetMouseButtonUp (2)) {
				if(ZoomOrigin.y > Camera.main.transform.position.y){				
					Camera.main.orthographicSize += Mathf.Abs(ZoomOrigin.y - Camera.main.transform.position.y);
				}
				if(ZoomOrigin.y < Camera.main.transform.position.y){				
					Camera.main.orthographicSize -= Mathf.Abs(ZoomOrigin.y - Camera.main.transform.position.y);
				}
			}
		}	
	}
}
