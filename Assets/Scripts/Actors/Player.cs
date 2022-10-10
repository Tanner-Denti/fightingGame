using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Actors
{
    public class Player : MonoBehaviour
    {
        private GameObject playerObject;
        private Rigidbody rb;

        private int health;
        private int speed;
        private int jumpCounter;
        private float jumpForce;
        // Constructor
        public Player(GameObject playerObject, int health = 100, int speed = 7, int jumpCounter = 0, float jumpForce = 8.0f)
        {
            this.playerObject = playerObject;
            this.rb = playerObject.GetComponent<Rigidbody>();
            this.health = health;
            this.speed = speed;
            this.jumpCounter = jumpCounter;
            this.jumpForce = jumpForce;
        }


        public float GetJumpForce()
        {
            return jumpForce;
        }
        public int GetJumpCounter()
        {
            return jumpCounter;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public int GetHealth()
        {
            return health;
        }

        //Not sure if this set method is really needed
        //public void SetHealth(int health)
        //{
        //    this.health = health;
        //}
    }
}

