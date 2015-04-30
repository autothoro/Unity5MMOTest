using UnityEngine;
using System.Collections;
using System;

public class TestSlideBar : MonoBehaviour {
	public PlayerCharacter _toon;
	private const int STARTING_POINTS = 290 ;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private int pointsLeft;
	
	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;
	
	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	
	private float maxSliderValue = 90.0f;
	private float sliderValue = 0.0F;
	private float sliderValueY;

	private ProceduralMaterial substance;

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
	//	DisplaySliderBar ();
		
		//if(_toon.Name == "" || pointsLeft > 0)
		//	DisplayCreateLabel ();
		//else
		//	DisplayCreateButton ();//create char
	}

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
				
				
			GUI.Label (new Rect (STAT_LABEL_WIDTH + OFFSET,												//x
				                   statStartingPos + (cnt * LINE_HEIGHT),									//y
				                   BASEVALUE_LABEL_WIDTH,													//width
				                   LINE_HEIGHT),													//height
				          
				          _toon.GetPrimaryAttribute (cnt).AdjustedBaseValue.ToString ());

		
				///NEED TO CHANGE THIS TYPEOF AND THE GETVALUE

	
			sliderValue =  GUI.HorizontalSlider (new Rect(STAT_LABEL_WIDTH + OFFSET + 13,												//x
			                                             statStartingPos + (cnt * LINE_HEIGHT),									//y
			                                             BASEVALUE_LABEL_WIDTH * 6,													//width
			                                             LINE_HEIGHT), sliderValue, 0.0f, 100.0f);
				
		
			if(sliderValueY != sliderValue)
			{
				 substance.SetProceduralFloat(_toon.GetPrimaryAttribute (cnt).BaseValue.ToString (), sliderValue);
			}
			sliderValueY = sliderValue;

			if(sliderValue < pointsLeft)
			{
				_toon.GetPrimaryAttribute (cnt).BaseValue.ToString();
				pointsLeft -- ;
				_toon.StatUpDate ();

			}
	
			//sliderValueY = Mathf.RoundToInt(sliderValueY);
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
	private void DisplaySkills(){     //add Change to a different screen for skills**********Add skill points
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 10,  //x
			                     statStartingPos  + (cnt* LINE_HEIGHT),                                      //y
			                     STAT_LABEL_WIDTH,                                                          //width
			                     LINE_HEIGHT),                                                              //height  
			           ((SkillName)cnt).ToString ());
			
			GUI.Label (new Rect (OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 10 + STAT_LABEL_WIDTH,				//x
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