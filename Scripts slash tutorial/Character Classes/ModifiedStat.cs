/// <summary>
///2015
/// base class for all stats that will be modified by attrritubes 
/// </summary>

using System.Collections.Generic;								/// Generic was added to use List<c>

public class ModifiedStat : BaseStat
	{															//list of attributes modify stat 
	private List<ModifyingAttribute>_mods;
	private int _modValue;										//amount added to the baseValue from modifiers


	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStat"/> class.
	/// </summary>
	public ModifiedStat()
	{
		UnityEngine.Debug.Log("ModifiedStat Create");
		_mods = new List<ModifyingAttribute> ();
		_modValue = 0;
	}

	/// <summary>
	/// Adds the modifier.
	/// </summary>
	/// <param name="mod">Mod.</param>
	public void AddModifier(ModifyingAttribute mod)
	{
		_mods.Add (mod);
	}

	/// <summary>
	/// Calculates the mod value.
	/// if we have a modified attribute add mod value
	/// </summary>
	private void CalculateModValue()
	{
		_modValue = 0;

		if(_mods.Count > 0)
			foreach(ModifyingAttribute att in _mods)
				_modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
	}
	/// <summary>
	/// calculate the adjusted base value from base,buff,mod, values.
	/// new int adjustedbasevalue is over riding old adjustedbasevalue
	/// </summary>
	/// <value>The adjusted base value.</value>
	public new int AdjustedBaseValue
	{
		get{ return BaseValue + BuffValue + _modValue;}
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update()
	{
		CalculateModValue ();
	}
	public string GetModifyingAttritubeString(){
		string temp = "";

//		UnityEngine.Debug.Log (_mods.Count);

		for (int cnt = 0; cnt < _mods.Count; cnt++) {
			temp += _mods[cnt].attribute.Name;
			temp += "_";
			temp += _mods[cnt].ratio;

			if(cnt < _mods.Count - 1){
			temp += "|";
			}


//			UnityEngine.Debug.Log (_mods[cnt].attribute.Name);
//			UnityEngine.Debug.Log ( _mods[cnt].ratio);
			}
		UnityEngine.Debug.Log (temp);
		return temp;
	}

}

/// <summary>
/// Modifying attribute. hold attribute and ratio add as a mod attribute to our mod stats
/// </summary>
public struct ModifyingAttribute 
	{
	public Attribute attribute;
	public float ratio;

	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name="att">Att.</param> att to be used
	/// <param name="rat">Rat.</param>ratio to be used
	public ModifyingAttribute(Attribute att, float rat){
		UnityEngine.Debug.Log("ModifyingAttribute Create");
		attribute = att;
		ratio = rat;
	}

}

