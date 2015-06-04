using UnityEngine;
using System.Collections;
																		// create Vector3 for GameObject spawn points.
public class GameMaster : MonoBehaviour {

	public GameObject playerCharacter;
	public GameObject _Settings;
	public Camera mainCamera;


	//																fix the camera angles !!!!! 

	public float xOffset;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;
	public float yRotOffset;
	public float zRotOffset;

	private GameObject _playerChar;
	private PlayerCharacter _playerCharScript;

	private Vector3 _characterSpawnPointPos;  					//place in 3d where the character will spawn


	// Use this for initialization
	void Start () {
		_characterSpawnPointPos = new Vector3 (284f, 17f, 345f);		// character spawn default x,y,z. need to add more spwan points for towns.

		GameObject go = GameObject.Find (Settings.CHARACTER_SPAWN_POINT);			// if no character is in spawn point. will create character at the points

		if (go == null) {
			Debug.LogWarning("Can't find Character Spawn Point");

			go = new GameObject(Settings.CHARACTER_SPAWN_POINT);
			Debug.Log("Created Character Spawn Point");

			go.transform.position = _characterSpawnPointPos;							//use the go.transform.position for character spawn point. add for each newbie town, start spawn
			Debug.Log("Moved Character Spawn Point");

		}
		_playerChar = Instantiate (playerCharacter, go.transform.position, Quaternion.identity) as GameObject; // _playerChar = Instantiate (playerCharacter,// go.transform.position //
		//																																		^^will add to character spawn point^^

		_playerChar.name = "playerChar";

		_playerCharScript = _playerChar.GetComponent<PlayerCharacter> ();
											//trying to have the main character camera at the right angle
		xOffset = .2f;
		yOffset = 2.8f;
		zOffset = -3f;
		xRotOffset = 20f;
		yRotOffset = 2.5f;
		zRotOffset = 1.1f;


		mainCamera.transform.position = new Vector3(_playerChar.transform.position.x + xOffset, _playerChar.transform.position.y + yOffset, _playerChar.transform.position.z + zOffset);
		mainCamera.transform.Rotate(xRotOffset, yRotOffset, zRotOffset);

		LoadCharacter ();

		}
	public void LoadCharacter(){
		GameObject SettingGame = GameObject.Find ("__Settings");			//loads __Settings from CharacterGenerator

		if (SettingGame == null) {
			GameObject SettingGame1 = Instantiate(_Settings, Vector3.zero, Quaternion.identity) as GameObject;
			SettingGame1.name = "__Settings";
		}
		Settings _playerCharScript = GameObject.Find ("__Settings").GetComponent<Settings>(); 
		

		//Load character data
		_playerCharScript.LoadData();
	}

	

}
