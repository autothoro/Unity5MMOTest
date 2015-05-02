using UnityEngine;
using System.Collections;
using System;

public class TestSlideBar : MonoBehaviour {
	public PlayerCharacter _toon;
	private const int STARTING_POINTS = 276 ;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private int pointsLeft;
	
	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;
	
	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	

	private float[] sliderValue = new float[6];
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
			GUI.Label (new Rect (OFFSET, 																	//x
				                     statStartingPos + (cnt * LINE_HEIGHT), 								//y
				                     STAT_LABEL_WIDTH, 														//width
				                     LINE_HEIGHT), 															//height	
				           ((AttributeName)cnt).ToString ());// add in creation design
				
				
			GUI.Label (new Rect (STAT_LABEL_WIDTH + OFFSET,													//x
				                   statStartingPos + (cnt * LINE_HEIGHT),									//y
				                   BASEVALUE_LABEL_WIDTH,													//width
				                   LINE_HEIGHT),															//height
				          
				          _toon.GetPrimaryAttribute (cnt).AdjustedBaseValue.ToString ());

		
				///NEED TO CHANGE THIS TYPEOF AND THE GETVALUE

	
			sliderValue[cnt] =  GUI.HorizontalSlider (new Rect(STAT_LABEL_WIDTH + OFFSET * 7,									//x
			                                             statStartingPos + (cnt * LINE_HEIGHT),									//y
			                                             BASEVALUE_LABEL_WIDTH * 6,												//width
			                                             LINE_HEIGHT),
			                                          	 sliderValue[cnt], 0.0f, 90.0f);





		//	GUI.Box (new Rect (STAT_LABEL_WIDTH + OFFSET,												//x
		//	                   statStartingPos + (cnt * LINE_HEIGHT),									//y
		//	                   BASEVALUE_LABEL_WIDTH + 2,													//width
		//	                   LINE_HEIGHT),"" + Mathf.Round(sliderValue[cnt]));

			if(_toon.GetPrimaryAttribute(cnt).BaseValue - sliderValue[cnt] > MIN_STARTING_ATTRIBUTE_VALUE){ /// was for the - button. need to change for a slider value right and left.
				_toon.GetPrimaryAttribute(cnt).BaseValue--;
				pointsLeft++;
				_toon.StatUpDate ();
				}

		//	sliderValue[cnt] = Mathf.Round(_toon.GetPrimaryAttribute(cnt).BaseValue);
		//	if(_toon.GetPrimaryAttribute(cnt).BaseValue - sliderValue[cnt] > MIN_STARTING_ATTRIBUTE_VALUE){ /// was for the - button. need to change for a slider value right and left.
		//		_toon.GetPrimaryAttribute(cnt).BaseValue++;
		//		pointsLeft--;
		//		_toon.StatUpDate ();
		//	}

			if(pointsLeft > 0){
				_toon.GetPrimaryAttribute(cnt).BaseValue++;
				pointsLeft--;
				_toon.StatUpDate ();
			}


	//		sliderValue [cnt] = sliderValue [cnt] + _toon.GetPrimaryAttribute (cnt).AdjustedBaseValue.ToString ();
	//		Debug.Log("- :" +sliderValue[cnt]);

		

			
				
				//sliderValue = "Stuff" + Mathf.RoundToInt(sliderValue).ToString();

		//		if(sliderValue[cnt] != sliderValue[cnt])
		//		{
		//		 substance.SetProceduralFloat(_toon.GetPrimaryAttribute (cnt).BaseValue, sliderValue[cnt]);
		//		}
		//	substance = sliderValue[cnt];

		//	if(sliderValue[cnt] < pointsLeft)
		//	{
		//		_toon.GetPrimaryAttribute (cnt).BaseValue++();
		//		pointsLeft -- ;
		//		_toon.StatUpDate ();

		//	}
	
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