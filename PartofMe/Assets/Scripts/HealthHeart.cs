using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour {

	// TODO: Requires further testing
	[Header("Health")]
	int _health;
	[SerializeField] HeartSlot[] _heartSlot;

	[System.Serializable]
	private class HeartSlot {
		public CharacterType characterType;
		public int numOfHearts;
	}

	
	[Header("UI")]
	[SerializeField] Image[] _hearts;
	[SerializeField] Sprite _fullHeart;
	[SerializeField] Sprite _emptyHeart;


	private int GetHealth(CharacterType characterType) {
		return GetHeartSlot(characterType).numOfHearts;
	}

	public void ObtainHealthType(CharacterType characterType, int newHeart) {
		GetHeartSlot(characterType).numOfHearts += newHeart;
	}

	public void DisplayHearts(CharacterType characterType) {
		if(_health > GetHeartSlot(characterType).numOfHearts) {
			_health = GetHeartSlot(characterType).numOfHearts;
		}

		for(int i = 0; i < _hearts.Length; i++) {

			if(i < _health) {
				_hearts[i].sprite = _fullHeart;
			} else {
				_hearts[i].sprite = _emptyHeart;
			}

			if(i < GetHeartSlot(characterType).numOfHearts) {
				_hearts[i].enabled = true;
			} else {
				_hearts[i].enabled = false;
			}
		}
	}

	private HeartSlot GetHeartSlot(CharacterType characterType) {
		foreach(HeartSlot slot in _heartSlot) {
			if(slot.characterType == characterType) {
				return slot;
			}
		}
		return null;
	}
}
