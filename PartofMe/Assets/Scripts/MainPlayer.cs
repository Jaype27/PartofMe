using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

	[SerializeField] float _moveSpeed;
	[SerializeField] float _jumpHeight;
	private float _input;
	private Rigidbody _rb;
	[SerializeField] float _rayDistance;
	public LayerMask _layerMask;
	bool _isGrounded = true;

	[SerializeField] HealthHeart _healthSlot;
	[SerializeField] CharacterType _characterType;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
		JumpAction();
		_healthSlot.DisplayHearts(_characterType);
	}

	void MovePlayer() {
		_input = Input.GetAxisRaw("Horizontal");
		_rb.velocity = new Vector2(_input * _moveSpeed, _rb.velocity.y);
		// TODO: Flip character depending on direction
	}

	void JumpAction() {
		Ray _ray = new Ray(transform.position, Vector3.down);
		RaycastHit _hitInfo;

		if(Physics.Raycast(_ray, out _hitInfo, _rayDistance, _layerMask) && !_isGrounded) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				_rb.velocity = Vector3.up * _jumpHeight;
			}
			Debug.DrawLine(_ray.origin, _hitInfo.point, Color.green);
		} else {
			_isGrounded = false;
			Debug.DrawLine(_ray.origin, _ray.origin + _ray.direction * _rayDistance, Color.red);
		}
	}
}
