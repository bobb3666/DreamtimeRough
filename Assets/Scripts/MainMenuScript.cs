using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GUISkin GameSkin;
	public string gameTitle = "Name This Game";

	private bool _isFirstMenu = true;
	private bool _isLoadMenu = false;
	private bool _isOptionsMenu = false;
	private bool _isNewGameMenu = false;
	private bool _isAudioOptions = false;
	private bool _isGraphicsOptions = false;

	private string _playerName = "";
	private string _playerGender = "";
	private string _currentLevel = "Level01";
	private float _gameVolume = 0.8f;
	private float _gameFOV = 65.0f;

	
	void Start () 
	{
		_gameVolume = PlayerPrefs.GetFloat ("Game Volume", _gameVolume);

		if (PlayerPrefs.HasKey ("Game Volume")) {
			AudioListener.Volume = PlayerPrefs.GetFloat ("Game Volume", _gameVolume);	
		} else {
			PlayerPrefs.SetFloat ("Game Volume", _gameVolume);
		}
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
		AudioOptionsDisplay ();
		GraphicsOptionsDisplay ();

		GUI.Label(new Rect(10,20,150,50),gameTitle, "Menu Title");

		if(_isLoadMenu == true || _isOptionsMenu == true || _isNewGameMenu)
		{
			if(GUI.Button(new Rect(10, Screen.height - 35, 150,25), "Back", "MyButton"))
			{
				_isLoadMenu = false;
				_isOptionsMenu = false;
				_isNewGameMenu = false;
				_isAudioOptions = false;
				_isGraphicsOptions = false;

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
			GUI.Box(new Rect(10, Screen.height / 2 - 100, 300,300), "");

			if (PlayerPrefs.HasKey ("Player Name")) {
				GUI.Label (new Rect (15, Screen.height / 2, 200, 25), "Player Name: " + PlayerPrefs.GetString ("Player Name"));

				if (GUI.Button (new Rect (15, Screen.height / 2 + 75, 200, 25), "Load Character")) {
					Application.LoadLevel (PlayerPrefs.GetString ("Current Level"));
				}
				if (GUI.Button (new Rect (15, Screen.height / 2 + 150, 200, 25), "Delete Character")) {
					PlayerPrefs.DeleteAll ();
				}
			}
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
				_isGraphicsOptions = false;
				_isAudioOptions = true;
			}
			if(GUI.Button(new Rect(15, Screen.height / 2 + 35, 150, 25), "Graphics Options", "MyButton"))
			{
				_isAudioOptions = false;
				_isGraphicsOptions = true;
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

			if (_playerName != "" && _playerGender != "") {
				if (GUI.Button (new Rect (15, Screen.height / 2 + 70, 150, 50), "Start")) {
					PlayerPrefs.SetString ("Player Name", _playerName);
					PlayerPrefs.SetString ("Player Gender", _playerGender);
					PlayerPrefs.SetString ("Current Level", _currentLevel);

					Application.LoadLevel ("Level01");
				}
			} else {
				if (GUI.Button (new Rect (15, Screen.height / 2 + 70, 150, 50), "Generating")) {

				}
			}
		}
	}

	public void AudioOptionsDisplay() {
		if(_isAudioOptions){

			GUI.Label (new Rect (25, 25, 200, 25), "Sound Volume");

			_gameVolume = GUI.HorizontalSlider (new Rect (25, Screen.Height / 2, 100, 25), _gameVolume, 0.0f, 1.0f);
			AudioListener.Volume = _gameVolume;


			if(GUI.Button(new Rect(25, Screen.Height /2 + 35, 25, 25),"Apply"){
				PlayerPrefs.SetFloat("Game Volume", _gameVolume);
			}
		}
	}

	public void GraphicsOptionsDisplay() {
		if (_isGraphicsOptions) {

		}
	}
	
}
