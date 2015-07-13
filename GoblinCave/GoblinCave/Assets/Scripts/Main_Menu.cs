using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	public Canvas ExitSubMenu;
	public Button ContinueButton;        //Continu Button itself
	public Button ExitButtonText;	  //Exit Button itself

	// Use this for initialization
	void Start () 

	{
		ExitSubMenu = ExitSubMenu.GetComponent<Canvas> ();
		ContinueButton = ContinueButton.GetComponent<Button> ();
		ExitButtonText = ExitButtonText.GetComponent<Button> ();	
		ExitSubMenu.enabled = false;
	}


	public void ContinueGame()     //needs to remake
	{
		Application.LoadLevel (1);
	}



	public void ExitPress() //opens submenu and disables other buttons
	{
		ExitSubMenu.enabled = true;
		ContinueButton.enabled = false;
		ExitButtonText.enabled = false;
	}

	public void NoPressExit()  //closes submenu and enables other buttons
	{
		ExitSubMenu.enabled = false;
		ContinueButton.enabled = true;
		ExitButtonText.enabled = true;
	}

	public void ExitGame() 
	{
		Application.Quit();
	} 


}
