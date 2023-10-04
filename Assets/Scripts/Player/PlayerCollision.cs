using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class PlayerCollision : MonoBehaviour
    {
        private const string PLAYER_ONE_HEAD = "Player_1_Head";
        private const string PLAYER_TWO_HEAD = "Player_2_Head";
        private HingeJoint2D hingeJoint2D;
        private Rigidbody2D rigidbody2D;
        private CircleCollider2D circleCollider2D;

        private void Start()
        {
            hingeJoint2D = GetComponent<HingeJoint2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }


        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.GetComponent<IDeadCollision>() != null)
            {
                hingeJoint2D.enabled = false;
                this.circleCollider2D.enabled = false;
                BounceHead();
                if(gameObject.name == PLAYER_ONE_HEAD) GameManager.Instance.PlayerTwoWin();
                else GameManager.Instance.PlayerOneWin();
            }
        }

        private void BounceHead()
        {
            float xDir = Random.Range(-1f, 1f);
            if (xDir == 0) xDir = 0.5f;
            Vector2 direction = new Vector2(xDir, 1);
            rigidbody2D.AddForce(direction.normalized * 50);
        }
    }
}