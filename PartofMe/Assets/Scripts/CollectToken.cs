using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectToken : MonoBehaviour {

	[SerializeField] GameObject _collectedCharacter;
	[SerializeField] GameObject _mainPlayer;
	GameObject _playerParent;
	const string PLAYER_PARENT_NAME = "Player";

	void CreatePlayerParent() {
		_playerParent = GameObject.Find(PLAYER_PARENT_NAME);

		if(!_playerParent) {
			_playerParent = new GameObject(PLAYER_PARENT_NAME);
		}
	}

	void InstantiateCharacter() {
		GameObject newCharacter = Instantiate(_collectedCharacter, _mainPlayer.transform.position, Quaternion.identity);

		newCharacter.transform.parent = _playerParent.transform;
		newCharacter.gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Touched");
		CreatePlayerParent();
		InstantiateCharacter();
		Destroy(gameObject);
	}
}

/*	TODO: STEPS: 

	X.) When Player sees token, collect it
	X.) Token disappears
	X.) In the Hierarchy, new character is child under the Player parent
	4.) New current character is active on previous character location
	5.) Each time a character is switched, their posisition should be the same
	
 */