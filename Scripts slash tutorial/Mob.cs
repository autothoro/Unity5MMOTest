using UnityEngine;
using System.Collections;

public class Mob : BaseCharacter {
	public int curHealth;
	public int maxHealth;



	// Use this for initialization
	void Start () {

//		GetPrimaryAttribute ((int)AttributeName.Endurance).BaseValue = 100;
//		GetVital ((int)VitalName.Health).Update();
		Name = "Goblin Mob";
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void DisplayHealth(){
		Messenger<float, float>.Invoke("Creature Health Update", curHealth, maxHealth);
	}
}
