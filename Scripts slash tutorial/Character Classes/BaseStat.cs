public class BaseStat{
	private int _baseValue;			//base value of this stat
	private int _buffValue;			//amount of buff values to stat
	private int _expToLevel;   		//exp needed to next level
	private float _levelModifer;	//modifer applied to exp needed to raise skill

	public BaseStat()
	{
		_baseValue = 0;
		_buffValue = 0;
		_levelModifer = 1.1f;
		_expToLevel = 100;

	}

	//set and get values
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


private int CalculateExpToLevel()
	{
		return (int)(_expToLevel * _levelModifer);
	}
	public void LevelUp()
	{
		_expToLevel = CalculateExpToLevel ();
		_baseValue++;
	}

	public int AdjustedBaseValue
	{
		get{ return _baseValue + _buffValue;}

	}
}


















