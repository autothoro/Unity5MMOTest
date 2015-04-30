/// <summary>
/// Attribute.
/// 2015
/// 
/// base skills classes
/// </summary>

public class Attribute : BaseStat {
	new public const int EXP_COST = 75;  //starting cost for all attributes

	private string _name;				//name of attribute


	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>
	public Attribute()
	{
		UnityEngine.Debug.Log("Attribute Create");
		_name = "";      //just work!
		ExpToLevel = EXP_COST;
		LevelModifier = 1.1f;
	}
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name {
		get{ return _name;}
		set{ _name = value; }
	}

}
/// <summary>
/// Attribute name.
/// </summary>
public enum AttributeName 
{
	Strength,
	Endurance,
	Coordination,
	Quickness,
	Focus,
	Self //change to willpower?
}
