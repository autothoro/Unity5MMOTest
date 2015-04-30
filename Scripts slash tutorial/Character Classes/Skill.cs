public class Skill : ModifiedStat {

	private bool _known;

	public Skill()
	{
		_known = false;
		ExpToLevel = 110;
		LevelModifier = 1.1f;
	}

	public bool Known
	{
		get{ return _known;}
		set{ _known = value;}
	}

}

	//smithing,healing,alchemy,jump,run, arrow making(fletching)
	//summon creature,destruction magic, protection magic/healing magic/skills buff(creature magic)

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