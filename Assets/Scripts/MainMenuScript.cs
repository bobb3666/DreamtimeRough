using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GUISkin GameSkin;
	public string gameTitle = "Name This Game";

	private bool _isFirstMenu = true;
	private bool _isLoadMenu = false;
	private bool _isOptionsMenu = false;
	private bool _isNewGameMenu = false;
	private string _playerName = "";
	private string _playerGender = "";
	
	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.skin = GameSkin;
		FirstMenu();
		LoadGame();
		Options();
		NewGameMenu();

		GUI.Label(new Rect(10,20,150,50),gameTitle, "Menu Title");

		if(_isLoadMenu == true || _isOptionsMenu == true || _isNewGameMenu)
		{
			if(GUI.Button(new Rect(10, Screen.height - 35, 150,25), "Back", "MyButton"))
			{
				_isLoadMenu = false;
				_isOptionsMenu = false;
				_isNewGameMenu = false;

				_isFirstMenu = true;
			}
		}
	}

	void FirstMenu()
	{
		if(_isFirstMenu)
		{
			if(GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "New Game", "MyButton"))
			{
				_isFirstMenu = false;
				_isNewGameMenu = true;
			}
			if(GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Load Game", "MyButton"))
			{
				_isFirstMenu = false;
				_isLoadMenu = true;
			}
			if(GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Options", "MyButton"))
			{
				_isFirstMenu = false;
				_isOptionsMenu = true;
			}
			if(GUI.Button(new Rect(10, Screen.height / 2 + 5, 150, 25), "Quit", "MyButton"))
			{
				Application.Quit ();
			}

		}
	}

	void LoadGame()
	{
		if(_isLoadMenu)
		{

			GUI.Label (new Rect(10,Screen.height / 2 - 150,150,50), "Load Menu", "SubHeading");
			GUI.Box(new Rect(10, Screen.height / 2 - 100, 300,300), "Put saved games here");
		}
	}

	void Options()
	{
		if(_isOptionsMenu)
		{

			GUI.Label (new Rect(10,Screen.height / 2 - 150,150,50), "Options Menu", "SubHeading");
			GUI.Box (new Rect(10, Screen.height /2 - 100, 300,300),""); 

			if(GUI.Button(new Rect(15, Screen.height / 2 , 150, 25), "Audio Options", "MyButton"))
			{

			}
			if(GUI.Button(new Rect(15, Screen.height / 2 + 35, 150, 25), "Graphics Options", "MyButton"))
			{

			}
		}
	}

	void NewGameMenu()
	{
		if(_isNewGameMenu)
		{
			GUI.Label (new Rect(10,Screen.height / 2 - 150,150,50), "New Game", "SubHeading");
			GUI.Box(new Rect(10, Screen.height / 2 - 100, 300,300), "");

			GUI.Label (new Rect(15,Screen.height / 2 ,150,50), "Player Name");
			_playerName = GUI.TextField(new Rect(100,Screen.height/2,200,25), _playerName);

			GUI.Label (new Rect(15,Screen.height / 2 + 35 ,150,50), "Player Gender");
			_playerGender = GUI.TextField(new Rect(100,Screen.height/2 + 35,200,25), _playerGender);
		}
	}
	
}
