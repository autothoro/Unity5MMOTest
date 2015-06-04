public class PlayerCharacter : BaseCharacter {
	void update(){
		Messenger<int, int>.Invoke("Character Health update", 80, 100);


	}

}
