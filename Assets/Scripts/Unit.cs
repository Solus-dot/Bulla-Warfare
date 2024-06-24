﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MovesetEnum { SOHOM, RAVI, MANAS, HARSH, ARYA, KHUSH, ADITI, SARV, DAKSH }

[System.Serializable]
public class Move {
	public string moveName;			// Name of the move
	public string moveDesc;			// Description of the move in character selection
	public string moveMessage;		// Message to be printed on the dialogue when the move is used
	public string missMessage;		// Message to be printed on the dialogue when the move missed

	public bool isCooldown;			// Flag indicating if move causes cooldown
	public int accuracy;			// Percentage chance of hitting (optional)

	public bool isDamaging;			// Flag indicating if the move deals damage
	public int damage;				// Base damage dealt by the move

	public bool isHealingMove;		// Flag indicating if the move heals (optional)
	public int selfHealAmount;		// Amount of health healed by self (if isHealingMove is true)
	public int oppHealAmount;		// Amount of health healed by opponent

	public bool isStatChange;		// Flag indicating if the move changes stats
	public int selfAttackChange;	// Amount by which the self attack stat changes (positive for increase, negative for decrease)
	public int selfDefenseChange;	// Amount by which the self defense stat changes (positive for increase, negative for decrease)
	public int oppAttackChange;		// Amount by which the opponent attack stat changes (positive for increase, negative for decrease)
	public int oppDefenseChange;	// Amount by which the opponent defense stat changes (positive for increase, negative for decrease)

	public float recoil;			// Percentage recoil damage to self from the move (optional)
	public int flinch;				// Percentage of opponent getting flinched from the move (optional)

}

public class Unit : MonoBehaviour {
	public string unitName;
	public int unitLevel;
	public int maxHP;
	public int attack;
	public int defense;
	public int baseAccuracy = 100;

	public int attackStage = 0;
	public int defenseStage = 0;
	public int currentHP;
	public MovesetEnum moveset;
	public string cooldownMessage;

	public bool isFlinching;
	public bool isOnCooldown;

	private Renderer unitRenderer;
	private Color originalColor;
	private float flashDuration = 0.2f; 

	void Start() {
		unitRenderer = GetComponent<SpriteRenderer>();
		if (unitRenderer != null) {
			originalColor = unitRenderer.material.color;
		}
	}

	public bool TakeDamage(int damage) {
		currentHP -= damage;

		if (unitRenderer != null) {
			StartCoroutine(FlashRed());
		}
		if (currentHP <= 0) {
			currentHP = 0;
			return true;
		}
		return false;
	}

	public void Heal(int amount) {
		currentHP += amount;
		if (currentHP > maxHP) {
			currentHP = maxHP;
		}

		if (unitRenderer != null) {
			StartCoroutine(FlashGreen());
		}
	}

	public void TakeBuff(int attackChange, int defenseChange) {
		attackStage = Mathf.Clamp(attackStage + attackChange, -6, 6);
		defenseStage = Mathf.Clamp(defenseStage + defenseChange, -6, 6);

		// Recalculate attack and defense based on the new stages
		attack = Mathf.FloorToInt(attack * GetStatMultiplier(attackStage));
		defense = Mathf.FloorToInt(defense * GetStatMultiplier(defenseStage));
	}

	public void AttemptFlinch(Move move) {
		if (Random.Range(0, 100) < move.flinch) {
			isFlinching = true;
			Debug.Log(unitName + " flinched!");
		}
	}

	public void EndTurn() {
		isFlinching = false;	// Reset flinch at the end of the turn
		isOnCooldown = false;	// Reset cooldown at the end of the turn
	}

	public Move GetMove(int index) {
		if (moveset == MovesetEnum.SOHOM) {
			return Sohom.moves[index];
		} else if (moveset == MovesetEnum.RAVI) {
			return Ravi.moves[index];
		} else if (moveset == MovesetEnum.MANAS) {
			return Manas.moves[index];
		} else if (moveset == MovesetEnum.HARSH) {
			return Harsh.moves[index];
		} else if (moveset == MovesetEnum.ARYA) {
			return Arya.moves[index];
		} else if (moveset == MovesetEnum.KHUSH) {
			return Khush.moves[index];
		} else if (moveset == MovesetEnum.ADITI) {
			return Aditi.moves[index];
		} else if (moveset == MovesetEnum.SARV) {
			return Sarv.moves[index];
		} else if (moveset == MovesetEnum.DAKSH) {
			return Daksh.moves[index];
		} else {
			Debug.LogError("Unknown Moveset");
			return null;
		}
	}

	private float GetStatMultiplier(int stage) {
		switch (stage) {
			case -6: return 0.25f;
			case -5: return 0.28f;
			case -4: return 0.33f;
			case -3: return 0.40f;
			case -2: return 0.50f;
			case -1: return 0.66f;
			case 0: return 1f;
			case 1: return 1.5f;
			case 2: return 2f;
			case 3: return 2.5f;
			case 4: return 3f;
			case 5: return 3.5f;
			case 6: return 4f;
			default: return 1f;
		}
	}

	private IEnumerator FlashRed() {
		unitRenderer.material.color = Color.red;
		yield return new WaitForSeconds(flashDuration); // Use customizable duration
		unitRenderer.material.color = originalColor;
		yield return new WaitForSeconds(flashDuration);
		unitRenderer.material.color = Color.red;
		yield return new WaitForSeconds(flashDuration);
		unitRenderer.material.color = originalColor;
	}

	private IEnumerator FlashGreen() {
		unitRenderer.material.color = Color.green;
		yield return new WaitForSeconds(flashDuration); // Use customizable duration
		unitRenderer.material.color = originalColor;
		yield return new WaitForSeconds(flashDuration);
		unitRenderer.material.color = Color.green;
		yield return new WaitForSeconds(flashDuration);
		unitRenderer.material.color = originalColor;
	}
}
