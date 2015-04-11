public class Attribute : BaseStat {

	public Attribute()
	{
		ExpToLevel = 50;
		LevelModifier = 1.05f;
	}
	//add base stats to 10?
}

public enum AttributeName 
{
	Strength,
	Endurance,
	Coordination,
	Quickness,
	Focus,
	Self //change to willpower?
}
