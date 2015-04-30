///MMo
///base character skill.
using UnityEngine;
using System.Collections;
using System;					//access the enum class
								//smithing,healing,alchemy,jump,run, arrow making(fletching)
								//summon creature,destruction magic, protection magic/healing magic/skills buff(creature magic)

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	public void Awake() 
	{
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;


		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName )).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes ();
		SetupVitals ();
		SetupSkills ();
	}


	public string Name {
		get{ return _name;}
		set{ _name = value;}
	}

	public int Level {
		get{ return _level;}
		set{ _level = value;}
	}

	public uint FreeExp {
		get{ return _freeExp;}
		set{ _freeExp = value;}
	}

	public void AddExp(uint exp){
		_freeExp += exp;

		CalculateLevel ();
	}


	//take average of all of the player's skills and assign that as a the player level
	public void CalculateLevel (){

	}

	private void SetupPrimaryAttributes()
	{
		for (int cnt= 0; cnt < _primaryAttribute.Length; cnt++) {
			_primaryAttribute [cnt] = new Attribute ();
			_primaryAttribute [cnt].Name = ((AttributeName)cnt).ToString ();
		}
	}

	private void SetupVitals()
	{
		for (int cnt= 0; cnt < _vital.Length; cnt++) 
			_vital[cnt] = new Vital ();

		SetupVitalModifiers ();
	}

	private void SetupSkills()
	{
		for (int cnt= 0; cnt < _skill.Length; cnt++) 
			_skill [cnt] = new Skill ();

		SetupSkillModifier ();

	}

	public Attribute GetPrimaryAttribute(int index){
		return _primaryAttribute [index];
	}
	public Vital GetVital(int index){
		return _vital [index];
	}
	public Skill GetSkill(int index){
		return _skill [index];
	}
	private void SetupVitalModifiers(){
		//health
		GetVital ((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Endurance), .5f));

		//stamina
		GetVital ((int)VitalName.Stamina).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Endurance), 1));

		//mana
		GetVital ((int)VitalName.Mana).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Self), 1));

	}

	private void SetupSkillModifier(){ //add in much more skills
		//Melee Offence   would like to add in more melee types
		GetSkill ((int)SkillName.UnArm).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), .7f));
		GetSkill ((int)SkillName.UnArm).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .7f));
		//Melee Sword
		GetSkill ((int)SkillName.Sword).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), .3f));
		GetSkill ((int)SkillName.Sword).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .3f));
		//Melee Axe
		GetSkill ((int)SkillName.Axe).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .3f));
		GetSkill ((int)SkillName.Axe).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .3f));
		//Melee Staff
		GetSkill ((int)SkillName.Staff).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .5f));
		GetSkill ((int)SkillName.Staff).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .5f));


		GetSkill ((int)SkillName.Smithing).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), .4f));
		GetSkill ((int)SkillName.Smithing).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .4f));

		GetSkill ((int)SkillName.Alchemy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .4f));
		GetSkill ((int)SkillName.Alchemy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .4f));

		GetSkill ((int)SkillName.Jump).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), .8f));
		GetSkill ((int)SkillName.Jump).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .2f));

		GetSkill ((int)SkillName.Run).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Quickness), .4f));

		GetSkill ((int)SkillName.Fletching).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .4f));
		GetSkill ((int)SkillName.Fletching).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .4f));

		GetSkill ((int)SkillName.Healing).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), .6f));
		GetSkill ((int)SkillName.Healing).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .6f));

		//Melee Defence
		GetSkill ((int)SkillName.Melee_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Quickness), .10f));
		GetSkill ((int)SkillName.Melee_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Endurance), .10f));
		//ADD IN MAGIC SPELLS, DESTRUCTION, PROTECTION, HEALDING, BUFFS!!!MORE


		//Magic Offence
		GetSkill ((int)SkillName.Destruction_Magic).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .8f));
		GetSkill ((int)SkillName.Destruction_Magic).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Self), .8f));
		//Magic Defence     woud like to add in different spell classes
		GetSkill ((int)SkillName.Magic_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .12f));
		GetSkill ((int)SkillName.Magic_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .12f));

		GetSkill ((int)SkillName.Life_Magic).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .8f));
		GetSkill ((int)SkillName.Life_Magic).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .8f));


		GetSkill ((int)SkillName.Summon_Creature).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .8f));
		GetSkill ((int)SkillName.Summon_Creature).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .8f));

		//Cross_Bow
		GetSkill ((int)SkillName.Cross_Bow).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Focus), .5f));
		//Ranged Offence   
		GetSkill ((int)SkillName.Bow).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Quickness), .8f));

		//Ranged Defence
		GetSkill ((int)SkillName.Ranged_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Quickness), .8f));
		GetSkill ((int)SkillName.Ranged_Defence).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Coordination), .8f));
	}
	public void StatUpDate(){
		for (int cnt = 0; cnt < _vital.Length; cnt++)
			_vital [cnt].Update ();

		for (int cnt = 0; cnt < _skill.Length; cnt++)
			_skill [cnt].Update ();
	}

}
