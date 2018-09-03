using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, 
						 cell_mirror,
						 sheet_0, 
						 sheet_1, 
						 mirror, 
						 lock_0, 
						 lock_1,
						 corridor_0,
						 corridor_1,
						 corridor_2,
						 corridor_3,
						 floor,
						 stairs_0,
						 stairs_1,
						 stairs_2,
						 closet_0,
						 closet_1,
						 closet_2,
						 closet_3,
						 courtyard};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell) 		{cell();} 
		else if (myState == States.cell_mirror) {cell_Mirror();} 
		else if (myState == States.sheet_0) 	{sheet_0();} 
		else if (myState == States.sheet_1) 	{sheet_1();} 
		else if (myState == States.mirror) 		{mirror();} 
		else if (myState == States.lock_0) 		{lock_0();} 
		else if (myState == States.lock_1) 		{lock_1();} 
		else if (myState == States.corridor_0) 	{corridor_0();} 
		else if (myState == States.corridor_1) 	{corridor_1();} 
		else if (myState == States.corridor_2) 	{corridor_2();} 
		else if (myState == States.corridor_3) 	{corridor_3();} 
		else if (myState == States.floor) 		{floor();} 
		else if (myState == States.stairs_0) 	{stairs_0();} 
		else if (myState == States.stairs_1) 	{stairs_1();} 
		else if (myState == States.stairs_2) 	{stairs_2();} 
		else if (myState == States.closet_0) 	{closet_0();} 
		else if (myState == States.closet_1) 	{closet_1();} 
		else if (myState == States.closet_2) 	{closet_2();} 
		else if (myState == States.closet_3) 	{closet_3();} 
		else if (myState == States.courtyard) 	{courtyard();}
	}


	#region State handler methods
	void cell() {
		text.text = "You are trapped in a dungeon and you want to escape. You see " + 
					"some dirty sheets on the bed, a mirror on the wall and a door " +
					"that is locked from the outside.\n\n" +
					"Look at:\n" +
					"Sheets\n" +
					"Mirror\n" +
					"Lock";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.sheet_0;}
		else if (Input.GetKeyDown(KeyCode.M)) {myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;}
	}

	void cell_Mirror() {
		text.text = "You're still trapped in the dungeon cells but at least you're now " + 
					"the proud owner of accessorize mirror.\n\n" +
					"Look at:\n" +
					"Sheets\n" +
					"Lock";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.sheet_1;} 
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_1;}
	}

	void sheet_0() {
		text.text = "Those are some filthy, filthy sheets.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void sheet_1() {
		text.text = "Those sheets are as filthy as they were before.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}

	void mirror() {
		text.text = "The mirror is too small to show your whole face.\n\n" +
					"...it looks like it can be removed from the wall.\n\n" +
					"Take mirror\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;} 
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.cell_mirror;}
	}

	void lock_0() {
		text.text = "You feel around the lock, from the other side.\n\n" +
					"Seems like it's a fairly simple hatch design that " + 
					"you can pick but you can't see what you're doing.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void lock_1() {
		text.text = "Using the mirror, you now get a clear display at the lock.\n\n" +
					"It should be an easy matter to open it now.\n\n" +
					"Open\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;} 
		else if (Input.GetKeyDown(KeyCode.O)) {myState = States.corridor_0;}
	}

	void corridor_0() {
		text.text = "You find yourself in a corridor. There are stairs leading up " + 
					"to outside and closet is to your side. This floor is also very " +
					"dirty and full of dirt and small junk.\n\n" +
					"search the Floor:\n" +
					"go up Stairs\n" +
					"check Closet";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_0;} 
		else if (Input.GetKeyDown(KeyCode.F)) {myState = States.floor;} 
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.closet_0;}
	}

	void corridor_1() {
		text.text = "You're still in the corridor. There are stairs leading up " + 
					"to outside and closet is to your side.\n\n" +
					"go up Stairs\n" +
					"check Closet";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;} 
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.closet_1;}
	}

	void corridor_2() {
		text.text = "You're still in the corridor. There are stairs leading up " + 
					"to outside and an open closet is to your side.\n\n" +
					"go up Stairs\n" +
					"check Closet";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_2;} 
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.closet_2;}
	}

	void corridor_3() {
		text.text = "You're still in the corridor. There are stairs leading up " + 
					"to outside and closet is to your side. You're dressed like a janitor.\n\n" +
					"go up Stairs\n" +
					"check Closet";
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.courtyard;} 
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.closet_3;}
	}

	void floor() {
		text.text = "The corridor has never seen a broom for as long as you've lived, you " + 
					"are certain. Hidden amongs the dirt are various useless pieces of junk. " +
					"The only noteworthy thing that you find is a hairclip.\n\n" +
					"Take hairclip\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;} 
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.corridor_1;}
	}

	void stairs_0() {
		text.text = "As you start to climb up the stairs, you hear that the outside is full " + 
					"of guards. There's no way you can sneak outside, without being seen.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void stairs_1() {
		text.text = "You hear that the courtyard outside is full of guards. " + 
					"Armed with your hairclip, you're certain you can't take them all.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
	}

	void stairs_2() {
		text.text = "The courtyard is still full of guards and it seems like they're not " + 
					"going away, anytime soon. They would spot you as soon as you leave.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
	}

	void closet_0() {
		text.text = "You check the closet and see that it's locked. It might be possible to " + 
					"pick it, if you had the right tools.\n\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void closet_1() {
		text.text = "The closet is locked but you might be able to pick it with your hairclip.\n\n" +
					"Pick lock\n" +
					"Return";		
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;} 
		else if (Input.GetKeyDown(KeyCode.P)) {myState = States.closet_2;}
	}

	void closet_2() {
		text.text = "The closet is open. There's a janitor suit inside.\n\n" +
					"Dress up\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;} 
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.closet_3;}
	}

	void closet_3() {
		text.text = "The closet is open and empty.\n\n" +
					"Undress\n" +
					"Return";
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_3;} 
		else if (Input.GetKeyDown(KeyCode.U)) {myState = States.closet_2;}
	}

	void courtyard() {
		text.text = "You walk outside in your disguise. As you're about to leave the courtyard, " +
		"one of the guards taps you on your shoulder and says: 'You thought we wouldn't " +
		"realize that you look nothing like our janitor?' he said, and took you back to your cell.\n\n" +
		"The end.\n\n" +
		"Return";
		if 		(Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
	}
	#endregion
}
