using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;
using System.Runtime.CompilerServices;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public Animator animator;
        private Rigidbody rb;
        private int speed = 7;
        private float jumpForce = 8.0f;
        private float gravityModifier = 1.5f;
        private int jumpCounter = 0;
        public Transform gazeVirtualBone;
		public MultiAimConstraint headMultiAim; 
		public Transform rightHandIKVirtualBone, rightHandIKProgrammaticBone;

        [SerializeField]
		private GameObject selectionMarker;
        
		private bool _inputActive = true;

		
		private float _currentSpeed;

		
		private Transform _transform;
        public List<GameObject>  _interactableObjects = new List<GameObject>();

        [SerializeField]
        private GameObject[] _interactableObjects2;


		
		private Plane _forwardPlane;
		private float _gazeMaxSqrDistance = 9f;

		
		public GameObject _closest;

		
		private bool _wasLookingAtSomething = false;
		
		private bool _isLookingAtSomething = false;
		private Vector3 _destination;
		private Vector3 _closingInDir;
        
        // Start is called before the first frame update
        private void Awake()
		{
            animator = GetComponent<Animator>();
			_transform = GetComponent<Transform>();
			_forwardPlane = new Plane();
			selectionMarker.SetActive(false);
		}
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
            // Physics.gravity = new Vector3(0, -9.8F, 0);
            

        }
        private void SearchInteractables()
		{
            _interactableObjects.AddRange(GameObject.FindGameObjectsWithTag("berserkPotion"));
            _interactableObjects.AddRange(GameObject.FindGameObjectsWithTag("jumpPotion"));
            _interactableObjects.AddRange(GameObject.FindGameObjectsWithTag("fastPotion"));
            _interactableObjects.AddRange(GameObject.FindGameObjectsWithTag("healthPotion"));
            _interactableObjects.AddRange(GameObject.FindGameObjectsWithTag("Interactable"));
		}

        // Update is called once per frame
        void Update()
        {
            
            MovePlayer();

        }

        void MovePlayer()
        {
            // Physics.gravity = gravityModifier;

            // The GameObjects
            string playerOne = "playerOne";
            string playerTwo = "playerTwo";

            // Different Movement for the player
            Vector3 movementDirection = new Vector3(0,0,0);
            Vector3 movementDirectionLeft = new Vector3(0,0,-1);
            Vector3 movementDirectionRight = new Vector3(0,0,1);

           // Player 1 Movement (red) wasd
           if(gameObject.name == playerOne)
           {
                // Jump up
                if (Input.GetKeyDown(KeyCode.W) && jumpCounter < 2)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
                //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(movementDirection * Time.deltaTime * speed);
                }
                // Move Left
                if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(-1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
                // Move Right
                if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }

                

           }
           
           // Player 2 Movement (green) arrow keys
           if(gameObject.name == playerTwo)
           {
                // Jump up
                if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCounter < 2)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
                //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(movementDirection * Time.deltaTime * speed);
                }
                // Move Left
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(-1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
                // Move Right
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
           }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Make it so that players can run through each other sometimes without moving the other. 
            // Make it so that if I am falling, I cannot land on another player, preventing my jump from resetting. 
            if (collision.gameObject.CompareTag("Platform"))
            {
               jumpCounter = 0;
            }

            if (collision.gameObject.CompareTag("berserkPotion"))
            {
                speed = 11;
                jumpForce = 11.0f;
                Invoke("resetSpeed", 5);
                Invoke("resetJump", 5);
            }
            if (collision.gameObject.CompareTag("fastPotion"))
            {
               speed = 9;
               Invoke("resetSpeed", 7);
            }
            if (collision.gameObject.CompareTag("jumpPotion"))
            {
                jumpForce = 10.0f;
                Invoke("resetJump", 6);
            }
        }

        void resetJump()
        {
            jumpForce = 8.0f;
        }

        void resetSpeed()
        {
            speed = 7;
        }
        private void LateUpdate()
		{
			//Orient and move the plane which limits the gaze
            _forwardPlane.SetNormalAndPosition(_transform.forward, _transform.position);
			//Head aim routine
            _interactableObjects.Clear();
            SearchInteractables();
			if(_inputActive
				&& _interactableObjects != null
                && _interactableObjects.Count != 0)
			{
				_closest = null;
				float closestSqrDistance = Mathf.Infinity;

				for(int i=0; i<_interactableObjects.Count; i++)
				{
                    if (_interactableObjects[i] != null)
                    {
                        float sqrDistance = (_transform.position - _interactableObjects[i].transform.position).sqrMagnitude;
                        //If closer than the previous AND within gaze range AND on the right side of the plane
                        if(sqrDistance < closestSqrDistance
                            && sqrDistance <= _gazeMaxSqrDistance
                            && _forwardPlane.GetSide(_interactableObjects[i].transform.position))
                        {
                            _closest = _interactableObjects[i];
                            closestSqrDistance = sqrDistance;
                        }
                    }

				}

				//Fire the event for the GameplayManager
				if(!_wasLookingAtSomething && _closest != null)
				{
					selectionMarker.SetActive(true);
					_isLookingAtSomething = true;
				}
				else if(_closest == null)
				{
					selectionMarker.SetActive(false);
					_isLookingAtSomething = false;
				}

			}

			//Adjust the gaze constraint
			if(_isLookingAtSomething)
			{
				headMultiAim.weight = Mathf.Clamp01(headMultiAim.weight + Time.deltaTime * 5f);
				gazeVirtualBone.position = _closest.transform.position; //follow the object if it's moving (or if the character is moving)
				_wasLookingAtSomething = true;
			}
			else
			{
				headMultiAim.weight = Mathf.Clamp01(headMultiAim.weight - Time.deltaTime * 5f);
				_wasLookingAtSomething = false;
			}
		}
        
    }
}

