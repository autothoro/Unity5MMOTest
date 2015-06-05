/// <summary>
/// Vital bar.
/// 2015
/// 
/// displaying vitals for palyer character or creature.
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VitalBar : MonoBehaviour {

	public Image Bar;
	public bool _isCharacterHealthBar;

	private float _maxBarLength; //how long will the  vital bar be at health percentage.
	private float _curBarLength; // how long the vital bar current health.


	//private Image _display;

	// Use this for initialization
	void Start () {
		_isCharacterHealthBar = true;

		//_maxBarLength = 1f;
		//_maxBarLength = (int) Bar.transform.localScale.x;
		OnEnable ();

	}
	
	// Update is called once per frame.
	void Update () {

	}


	// gameboject is enabled
	public void OnEnable(){
		if(_isCharacterHealthBar)
			Messenger<int, int>.AddListener("Character Health update", onChangeHalthBarSize);
		else
			Messenger<int, int>.AddListener("Creature Health update", onChangeHalthBarSize);
	}
	//called when gameobject is disabled.
	public void OnDisable(){
		if(_isCharacterHealthBar)
			Messenger<int, int>.RemoveListener("Character Health update", onChangeHalthBarSize);
		else
			Messenger<int, int>.RemoveListener("Creature Health update", onChangeHalthBarSize);

	}

	// will calculate the total size of healthbar in the percentage of health left.
	public void onChangeHalthBarSize(int curHealth, int maxHealth){
	//	Debug.Log ("Something Happens: curHealth = " + curHealth + " - maxHealth = " + maxHealth);
		_curBarLength =  MapValues(curHealth, 0, maxHealth, 0f, 1f);	//calculates the current length of the health bar percentage. curhealth value 0-1, 80/ 100 - 0.8f
		//Bar.transform.localScale = new Vector3 ( curHealth, Bar.transform.localScale.y, Bar.transform.localScale.z); 
		Image Bar = GetComponent<Image> ();

		Bar.fillAmount = Mathf.Lerp (Bar.fillAmount, _curBarLength, Time.deltaTime);
			//Mathf.Lerp (Bar.fillAmount, _curBarLength, Time.deltaTime);
			//CalculatePosition ();

	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
	// changing health bar to player or creature
	public void SetCharacterHealth(bool b) {
		_isCharacterHealthBar = b;
	}
	//calculate the max health and current health.
//	private Vector3 CalculatePosition()
//	{

	//	if (!_isCharacterHealthBar) {
		//	return Mathf.Lerp (Bar.fillAmount, _curBarLength, Time.deltaTime);
		//}//
		//return  Mathf.Lerp (Bar.fillAmount, _curBarLength, Time.deltaTime);
	//}
}
