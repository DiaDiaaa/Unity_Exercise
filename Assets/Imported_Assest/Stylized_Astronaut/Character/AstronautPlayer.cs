using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			//Get inputs from the player
			if (Input.GetKey ("w")) {
				//Based on the input and set animation display of the avatar
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}
			//Check if the character lands on a physical plane
			if(controller.isGrounded){
				//Move character based on the preset speed and direction
				//Vertical as up  and down arrow key
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}
			//Controll character to rotate
			//Horizontal as left and right arrow keys
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
	}
}
