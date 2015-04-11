//slash tutorial 
using UnityEngine;
using System.Collections;
using System;	
												//use for the enum class
public class CharacterGenerator : MonoBehaviour {
	private PlayerCharacter _toon;
	private const int STARTING_POINTS = 290 ;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private int pointsLeft;


	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;

	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;

	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;

	private int statStartingPos = 40;

	public GUIStyle myStyle;
	public GUISkin mySkin;

	// Use this for initialization
	void Start () {
		_toon = new PlayerCharacter ();
		_toon.Awake ();

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
		}
		
	private void DisplayName(){
		GUI.Label (new Rect (10, 10, 50, 25), "Name");
		_toon.Name = GUI.TextField (new Rect (65, 10, 100, 25), _toon.Name);
	}

	private void DisplayAttributes(){
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET, 																//x
			                     statStartingPos + (cnt * LINE_HEIGHT), 								//y
			                     STAT_LABEL_WIDTH, 														//width
			                     LINE_HEIGHT), 															//height	
			           ((AttributeName)cnt).ToString (), myStyle);// add in creation design

			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET,												//x
			                   statStartingPos + (cnt* LINE_HEIGHT),									//y
			                   BASEVALUE_LABEL_WIDTH,													//width
			                   LINE_HEIGHT),															//height

			          _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString ());
			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH, 					//x
			                       statStartingPos +(cnt * BUTTON_HEIGHT),								//y
			                       BUTTON_WIDTH, 														//width
			                       BUTTON_HEIGHT),														//height
			              "-")){ //add "-", mystyle)){ for making design image on creation screen

				if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE){
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;
					_toon.StatUpDate ();
				}
			}

			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,	//x
			                       statStartingPos + (cnt * BUTTON_HEIGHT),								//y
			                       BUTTON_WIDTH,														//width
			                       BUTTON_HEIGHT),														//height	
			              "+" , myStyle)){ // mystyle)){ for making design image on creation screen

				if(pointsLeft > 0){
					_toon.GetPrimaryAttribute(cnt).BaseValue++;
					pointsLeft--;
					_toon.StatUpDate ();
				}
			}
		}
	}    

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
	private void DisplaySkills(){     //add Change to a different screen for skills**********
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
}
