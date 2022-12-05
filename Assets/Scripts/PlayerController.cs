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
		public float speedMultiplier = 3f;
		public Transform gazeVirtualBone;
		public MultiAimConstraint headMultiAim;
		public Transform rightHandIKVirtualBone, rightHandIKProgrammaticBone;
		public GameObject selectionMarker;

		private bool _inputActive = true;
		private bool _needToGetCloser = false;
		private float _currentSpeed;
		private Transform _transform;
		private GameObject[] _interactableObjects;
		private Plane _forwardPlane;
		private float _gazeMaxSqrDistance = 9f;
		private float _interactSqrDistance = 1f;
		public GameObject _closest;
		private bool _wasLookingAtSomething = false;
		private bool _isLookingAtSomething = false;
		private Vector3 _destination;
		private Vector3 _closingInDir;

		public UnityAction GazeConnected, GazeDisconnected;

		void Awake()
		{
			animator = GetComponent<Animator>();
			_transform = GetComponent<Transform>();
			_forwardPlane = new Plane();
			selectionMarker.SetActive(false);
		}

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			Physics.gravity *= gravityModifier;
			SearchInteractables();

		}

		private void SearchInteractables()
		{
			_interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");
		}

		void Update()
		{
			MovePlayer();
		}

		private void LateUpdate()
		{
			//Orient and move the plane which limits the gaze
				_forwardPlane.SetNormalAndPosition(_transform.forward, _transform.position);

			//Head aim routine
			if(_inputActive
				&& _interactableObjects != null
				&& _interactableObjects.Length != 0)
			{
				_closest = null;
				float closestSqrDistance = Mathf.Infinity;
				for(int i=0; i<_interactableObjects.Length; i++)
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

				//Fire the event for the GameplayManager
				if(!_wasLookingAtSomething && _closest != null)
				{
					selectionMarker.SetActive(true);
					_isLookingAtSomething = true;
					GazeConnected.Invoke();
				}
				else if(_wasLookingAtSomething && _closest == null)
				{
					selectionMarker.SetActive(false);
					_isLookingAtSomething = false;
					GazeDisconnected.Invoke();
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

		private void PlayReachingAnimation()
		{
			Transform handPoseRefT = _closest.GetComponent<Interactable>().handPoseRef.transform;
			rightHandIKProgrammaticBone.SetPositionAndRotation(handPoseRefT.position, handPoseRefT.rotation);  //lock the programmatic virtual bone in position to pick up the Interactable
			
			selectionMarker.SetActive(false);
			_closest.tag = "Untagged";
			_isLookingAtSomething = false; //will progressively reset the head

			animator.SetTrigger("Gathering");
		}

		private void ObjectGrabbed()
		{
			_closest.transform.SetParent(rightHandIKVirtualBone, true);
		}

		private void InteractionOver()
		{
			Destroy(_closest);

			//Cleanup		
			_closest = null;
			_interactableObjects = null;
			GazeDisconnected.Invoke();
			
			_inputActive = true;
		}

		private void Step(Vector3 movementVector)
		{
			float input = movementVector.magnitude;
			Vector3 newPosition = _transform.position + movementVector * Time.deltaTime * speedMultiplier;
					
			NavMeshHit hit;
			NavMesh.SamplePosition(newPosition, out hit, .3f, NavMesh.AllAreas);
			bool hasMoved = (_transform.position - hit.position).magnitude >= .02f;
			
			if(hasMoved)
			{
				_transform.position = hit.position;
				animator.SetBool("isRunning", hasMoved);
				_transform.forward = Vector3.Slerp(_transform.forward, movementVector, Time.deltaTime * 7f);
			}
			else
			{
				//stops the animation when the character reaches the border of the NavMesh (even if input is still on)
				animator.SetBool("isRunning", false);
			}

			animator.SetFloat("CurrentSpeed", input);
		}
		void MovePlayer()
			{

				string playerOne = "playerOne";
				string playerTwo = "playerTwo";

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
					if(Input.GetKeyDown(KeyCode.Space))
					{
						if(_closest != null)
						{
							_inputActive = false;
							
							_closingInDir = _closest.transform.position-_transform.position;
							_closingInDir.y = 0f;
							_destination = transform.position + _closingInDir;

							if(Vector3.SqrMagnitude(_closingInDir) > _interactSqrDistance)
							{
								//need to get closer
								if(_closingInDir.sqrMagnitude > 1f)
								{
									_closingInDir.Normalize();
								}
								_needToGetCloser = true;
							}
							else
							{
								PlayReachingAnimation();
							}				
							}
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
			}
	}
}
