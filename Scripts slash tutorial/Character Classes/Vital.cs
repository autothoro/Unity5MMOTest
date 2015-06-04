/// <summary>
/// Vital.cs
/// 2015
/// Whetsel
/// 
/// 
/// 
/// Class contains all the funtions for a  character's vitals.
/// </summary>

public class Vital : ModifiedStat {
	private int _curValue;	//current value of this vital


	/// <summary>
	/// Initializes a new instance of the <see cref="Vital"/> class.
	/// </summary>
	public Vital()
	{
		UnityEngine.Debug.Log ("Vital Created");
		_curValue = 0;
		ExpToLevel = 110;
		LevelModifier = 1.1f;
	}

	/// <summary>
	/// when getting the _curValue, check that it is not greater than our AdjustedBaseValue.
	/// If it is, make it the same value as our AdjustedBaseValue.
	/// </summary>
	/// <value>The current value.</value>
	public int CurValue
	{
		get {
			if(_curValue < AdjustedBaseValue)
				_curValue = AdjustedBaseValue;

			return _curValue;

		}
		set{ _curValue = value;}
	}
}
/// <summary>
/// List of vitals names that the character will have.
/// </summary>
public enum VitalName {
	Health,
	Stamina,  
	Mana
}
