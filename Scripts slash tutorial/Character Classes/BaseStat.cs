/// <summary>
/// BaseStat
/// 2015
/// Base class for stats in game
///  </summary>
using UnityEngine;

public class BaseStat{
	public const int EXP_COST = 75;  //public value for all base stats 

	private int _baseValue;			  //base value of this stat
	private int _buffValue;			  //amount of buff values to stat
	private int _expToLevel;   		  //exp needed to next level
	private float _levelModifer;	  //modifer applied to exp needed to raise skill

	///																									BaseStat.levelModifier = BaseStat.levelModifier +10;
	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>
	public BaseStat()
	{
		UnityEngine.Debug.Log("BaseStat Create");
		_baseValue = 0;
		_buffValue = 0;
		_levelModifer = 1.1f;
		_expToLevel = EXP_COST;

	}

	public int BaseValue
	{
		get{return _baseValue;}
		set{ _baseValue = value;}
	}

	public int BuffValue 
	{
		get{ return _buffValue;}
		set{ _buffValue = value;}
	}

	public int ExpToLevel
	{
		get{ return _expToLevel;}
		set{ _expToLevel = value;}
	}

	public float LevelModifier 
	{
		get{ return _levelModifer;}
		set{ _levelModifer = value;}
	}

	/// <summary>
	/// Calculates the exp to level.
	/// </summary>
	/// <returns>The exp to level.</returns>
private int CalculateExpToLevel()
	{
		return (int)(_expToLevel * _levelModifer);
	}

	/// <summary>
	/// Levels up.
	/// </summary>
	public void LevelUp()
	{
		_expToLevel = CalculateExpToLevel ();
		_baseValue++;
	}
	/// <summary>
	/// Gets the adjusted base value.
	/// </summary>
	/// <value>The adjusted base value.</value>
	public int AdjustedBaseValue
	{
		get{ return _baseValue + _buffValue;}

	}
}


















