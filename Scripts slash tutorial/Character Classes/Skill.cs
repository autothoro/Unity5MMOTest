/// <summary>
/// Skill.cs
/// 2015
/// Whetsel
/// 
/// This class contains all the extra functions that are needed for a skill.
/// 
/// </summary>


public class Skill : ModifiedStat {

	private bool _known;					// boolean variable to toggle if a character knows a skill.

	/// <summary>
	/// Initializes a new instance of the <see cref="Skill"/> class.
	/// </summary>
	public Skill()
	{
		UnityEngine.Debug.Log ("Skill created");
		_known = false;
		ExpToLevel = 110;
		LevelModifier = 1.1f;
	}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="Skill"/> is known.
	/// </summary>
	/// <value><c>true</c> if known; otherwise, <c>false</c>.</value>
	public bool Known
	{
		get{ return _known;}
		set{ _known = value;}
	}

}

	/// <summary>
	/// this is just a list of skills that a character can learn. 
	/// </summary>

public enum SkillName
{
	UnArm,
	Sword,
	Axe,
	Staff,
	Melee_Defence,
	Bow,
	Ranged_Defence,
	Destruction_Magic, //add more magic options
	Magic_Defence,
	Smithing,
	Healing,
	Alchemy,
	Jump,
	Run,
	Fletching,
	Life_Magic,
	Summon_Creature,
	Cross_Bow

	//add more skills
	//add in crafting skills 

}