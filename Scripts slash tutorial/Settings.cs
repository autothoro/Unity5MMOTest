using UnityEngine;
using System.Collections;
using System;

public class Settings : MonoBehaviour {
	public const string CHARACTER_SPAWN_POINT = "Character Spawn Point";		//gameobject for the player to spawn  // add in more spawn points for towers beginner levels


	void Awake(){
		DontDestroyOnLoad (this);
	      }



	public void SaveData(){
		GameObject playerChar = GameObject.Find ("playerChar");

		PlayerCharacter playerCharClass = playerChar.GetComponent<PlayerCharacter> ();

		PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetString ("Player Name", playerCharClass.name);


		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Base Value", playerCharClass.GetPrimaryAttribute (cnt).BaseValue);
			PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Experience To Level", playerCharClass.GetPrimaryAttribute (cnt).ExpToLevel);
		}
	
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Base Value", playerCharClass.GetVital (cnt).BaseValue);
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Experience To Level", playerCharClass.GetVital (cnt).ExpToLevel);
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Current Value", playerCharClass.GetVital (cnt).CurValue);

//			PlayerPrefs.SetString(((VitalName)cnt).ToString() + "Mods", playerCharClass.GetVital (cnt).GetModifyingAttritubeString ());

			}
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			PlayerPrefs.SetInt (((SkillName)cnt).ToString () + " - Base Value", playerCharClass.GetSkill(cnt).BaseValue);
			PlayerPrefs.SetInt (((SkillName)cnt).ToString () + " - Experience To Level", playerCharClass.GetSkill (cnt).ExpToLevel);

//			PlayerPrefs.SetString(((SkillName)cnt).ToString() + "Mods", playerCharClass.GetSkill (cnt).GetModifyingAttritubeString ());
		}
	
	
	}

	public void LoadData(){
		GameObject playerChar = GameObject.Find ("playerChar");
		
		PlayerCharacter playerCharClass = playerChar.GetComponent<PlayerCharacter> ();

		playerCharClass.Name = PlayerPrefs.GetString ("Player Name", " Name me");

		//get values of attributes that have been stored
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			playerCharClass.GetPrimaryAttribute (cnt).BaseValue = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Base Value", 0);
			playerCharClass.GetPrimaryAttribute (cnt).ExpToLevel = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Experience To Level", Attribute.EXP_COST);
		}


		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			playerCharClass.GetVital (cnt).BaseValue = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value", 0);
			playerCharClass.GetVital (cnt).ExpToLevel = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Experience To Level", 0);

			//need to call the AjustedBaseValue will be updated before trying to call curValue
			playerCharClass.GetVital(cnt).Update();

			//get sorted value for curValue for each vital
			playerCharClass.GetVital(cnt).CurValue = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Cur Value", 1);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			playerCharClass.GetSkill(cnt).BaseValue = PlayerPrefs.GetInt (((SkillName)cnt).ToString () + " - Base Value", 0);
			playerCharClass.GetSkill (cnt).ExpToLevel = PlayerPrefs.GetInt (((SkillName)cnt).ToString () + " - Experience To Level", 0);

	
		}

		//output debug
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			Debug.Log (((VitalName)cnt).ToString() + ": " + playerCharClass.GetVital(cnt).CurValue);
		}
	}
}
