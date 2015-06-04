/// <summary>
///MMO
///2015
///Character Main creation screen 
/// add a push down input to auto add points.
///  </summary>
using UnityEngine;
using System.Collections;
using System;	
												//use for the enum class
public class CharacterGenerator : MonoBehaviour {
	public PlayerCharacter _toon;
	private const int STARTING_POINTS = 270 ;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int MAX_ATTRIBUTE_VALUE = 100;
	private int pointsLeft;

	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;

	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;

	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;



	private int statStartingPos = 40;

	public GUISkin mySkin; //Character creation design page

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		GameObject playerChar = Instantiate (playerPrefab,Vector3.zero, Quaternion.identity) as GameObject;


		playerChar.name = "playerChar";


		_toon = playerChar.GetComponent<PlayerCharacter> ();

		pointsLeft = STARTING_POINTS;

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			_toon.GetPrimaryAttribute (cnt).BaseValue = MIN_STARTING_ATTRIBUTE_VALUE;  //skills base starting value 
		}
		_toon.StatUpDate ();
	}

	// Update is called once per frame
	void Update () {

	
	}

	void OnGUI() {
		GUI.skin = mySkin;

		DisplayName ();
		DisplayAttributes ();
		DisplayVitals ();
		DisplaySkills ();
		DisplayPointsLeft ();


		if(_toon.Name == "" || pointsLeft > 0)
		DisplayCreateLabel ();
		else
		DisplayCreateButton ();//create char




	}
		/// <summary>
		/// D//////////////////////////////////////////////////add in a game name above character name DisplayName		/// </summary>
	private void DisplayName(){
		GUI.Label (new Rect (OFFSET, 10, 50, 25), "Name");
		_toon.Name = GUI.TextField (new Rect (65, 10, 100, 25), _toon.Name);
	}

	private void DisplayAttributes(){
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET, 																//x
			                     statStartingPos + (cnt * LINE_HEIGHT), 								//y
			                     STAT_LABEL_WIDTH, 														//width
			                     LINE_HEIGHT), 															//height	
			           ((AttributeName)cnt).ToString ());// add in creation design
					

			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET,												//x
			                 statStartingPos + (cnt* LINE_HEIGHT),									//y
			               BASEVALUE_LABEL_WIDTH,													//width
			             LINE_HEIGHT),															//height

			          _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString ());


			if(GUI.RepeatButton(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH, 					//x
			                       statStartingPos +(cnt * BUTTON_HEIGHT),								//y
			                       BUTTON_WIDTH, 														//width
			                       BUTTON_HEIGHT),													//height
			              "-")){ // mystyle)){ for making design image on creation screen//make a push down input to quickly remove points

				if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE ){
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;
					_toon.StatUpDate ();

				}



			}


				if(GUI.RepeatButton(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,	//x
			                       statStartingPos + (cnt * BUTTON_HEIGHT),								//y
			                       BUTTON_WIDTH,														//width
			                       BUTTON_HEIGHT),														//height	
			              "+")){ // mystyle)){ for making design image on creation screen// make a push down input to quickly add points

				if(pointsLeft > 0){
					_toon.GetPrimaryAttribute(cnt).BaseValue++;
					pointsLeft--;
					_toon.StatUpDate ();

				}

			}
		
	}    
}


//	}
	private void DisplayVitals(){
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET,																//x
			                     statStartingPos + ((cnt + 7)*LINE_HEIGHT),								//y
			                     STAT_LABEL_WIDTH,														//width
			                     LINE_HEIGHT),															//height
			           ((VitalName)cnt).ToString ());

			GUI.Label (new Rect (OFFSET + STAT_LABEL_WIDTH,												//x
			                     statStartingPos + ((cnt + 7) * LINE_HEIGHT),							//y
			                     BASEVALUE_LABEL_WIDTH,													//width
			                     LINE_HEIGHT),															//height

			           _toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}
	private void DisplaySkills(){     //add Change to a different screen for skills**********Add skill points
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET * 4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2,  //x
			                     statStartingPos + (cnt* LINE_HEIGHT),                                      //y
			                     STAT_LABEL_WIDTH,                                                          //width
			                     LINE_HEIGHT),                                                              //height  
			                 ((SkillName)cnt).ToString ());

			GUI.Label (new Rect (OFFSET * 4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + STAT_LABEL_WIDTH,				//x
			                     statStartingPos + (cnt * LINE_HEIGHT),																		//y	
			                     BASEVALUE_LABEL_WIDTH,																						//width
			                     LINE_HEIGHT),																								//height									
			           _toon.GetSkill(cnt).AdjustedBaseValue.ToString ());
		}
	}



	private void DisplayPointsLeft(){
		GUI.Label (new Rect (250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
	}
	//private void DisplaySkillButton(){   // Need to creat a new script for next button page for skills.
	//}

	private void DisplayCreateLabel(){
		GUI.Label (new Rect (Screen.width / 2 - 50,										        //x
		                         statStartingPos + (10 * LINE_HEIGHT),							//y
		                         STAT_LABEL_WIDTH + 10,											//width
		                         LINE_HEIGHT													//height
		                         ), "Create Character", "Button");
	}
	private void DisplayCreateButton(){				//will change this to after skill selection to create character . ////////can change a label to a button/ a button to a label.
		if(GUI.Button (new Rect (Screen.width / 2 - 50,										//x
	                        statStartingPos + (10 * LINE_HEIGHT),							//y
	        	            STAT_LABEL_WIDTH + 10,											//width
	    	                LINE_HEIGHT														//height
		                  ), "New Character")){
		
		
		Settings SettingGameScript = GameObject.Find ("__Settings").GetComponent<Settings>(); 
	
	//change current value of the vitals to the max mod value of that vital

			UpdateCurrentVitalValues();
			//save character data
			SettingGameScript.SaveData();

			Application.LoadLevel("MainWorld"); //Main Server World // for loadlevel ("slashing"); can also do File/building Settings to find number code
					}
			}

	private void UpdateCurrentVitalValues(){
		for (int cnt = 0; cnt <Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			_toon.GetVital(cnt).CurValue = _toon.GetVital(cnt).AdjustedBaseValue;
			}
		}
}
