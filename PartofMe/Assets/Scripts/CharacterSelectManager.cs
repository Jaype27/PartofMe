using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour {

	public int _selectedCharacter = 0;

	// Use this for initialization
	void Start () {
		SelectedCharacter();
	}
	
	// Update is called once per frame
	void Update () {

		int previousCharacter = _selectedCharacter;


		if(Input.GetAxis("Mouse ScrollWheel") > 0) {
			if(_selectedCharacter >= transform.childCount - 1){
				_selectedCharacter = 0;
			} else {
				_selectedCharacter++;
			}
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0) {
			if(_selectedCharacter <= 0) {
				_selectedCharacter = transform.childCount - 1;
			} else {
				_selectedCharacter--;
			}
		}

		if(previousCharacter != _selectedCharacter) {
			SelectedCharacter();
		}
	}

	void SelectedCharacter() {
		int i = 0;
		
		foreach(Transform character in transform) {
			
			if(i == _selectedCharacter) {
				character.gameObject.SetActive(true);
			} else {
				character.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
