public class Skill : ModifiedStat {

	private bool _known;

	public Skill()
	{
		_known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
	}

	public bool Known
	{
		get{ return _known;}
		set{ _known = value;}
	}

}


public enum SkillName
{
	Melee_UA,
	Melee_Defence,
	Ranged_Bow,
	Ranged_Defence,
	Magic_Offence,
	Magic_Defence
	//unarm,sword,staff need to add
	//add in crafting skills 

}