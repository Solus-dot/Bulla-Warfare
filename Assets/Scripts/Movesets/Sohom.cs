// Sohom 

// Move 1: Chokehold
// comes sneakily behind the opponent and chokes them for some damage, 
// causes opponent to lose defense stat

// Move 2: MCDonel
// Orders Mcdonald's in the middle of the fight, 
// heals 30% of total HP

// Move 3: Brainrot Spew
// Spews insane brainrot phrases at the opponent, 
// causes the opponent to lose his attack by two stages

// Move 4: Mr Fresher Smash
// Uses his status as Mr Fresher to summon hordes of fangirls to attack the opponent, 
// deals massive damage but needs to be recharged after used

using UnityEngine;
using System.Collections.Generic;

public class Sohom : MonoBehaviour 
{
	public List<Move> moves = new List<Move>() {
		// Chokehold Move
		new Move() {
			moveName = "Chokehold",
			moveDesc = "Comes up sneakily behind the opponent and chokes them for some damage, \nCauses the opponent to lose Defense.",
			isDamaging = true,
			damage = 20,
			cooldown = 0,
			accuracy = 100,
			isHealingMove = false,
			healAmount = 0,
			isStatChange = true,
			attackChange = 0,
			defenseChange = -1
		},

		// MCDonel Move
		new Move() {
			moveName = "MCDonel",
			moveDesc = "Orders Mcdonald's in the middle of the fight,\nHeals 30% of total HP.",
			isDamaging = false,
			damage = 0,
			cooldown = 0,
			accuracy = 100,
			isHealingMove = true,
			healAmount = 100, //100 for now, will switch to 30% later
			isStatChange = false,
			attackChange = 0,
			defenseChange = 0
		},

		// Brainrot Spew Move
		new Move() { 
			moveName = "Brainrot Spew",
			moveDesc = "Spews insane brainrot phrases at the opponent, \nCauses the opponent to lose his Attack by two stages.",
			isDamaging = false,
			damage = 0,
			cooldown = 0,
			accuracy = 100,
			isHealingMove = false,
			healAmount = 0,
			isStatChange = true,
			attackChange = -2,
			defenseChange = 0
		},

		// Mr Fresher Smash Move
		new Move() {
			moveName = "Mr. Fresher Smash",
			moveDesc = "Uses his status as Mr. Fresher to summon hordes of fangirls to attack the opponent,\nDeals massive damage but needs to be recharged after used.",
			isDamaging = true,
			damage = 20,
			cooldown = 1,
			accuracy = 100,
			isHealingMove = false,
			healAmount = 0,
			isStatChange = false,
			attackChange = 0,
			defenseChange = 0
		}
	};

	public Move GetMoveAt(int index) {
        if (index >= 0 && index < moves.Count) {
            return moves[index];
        }
        return null;
    }
}
