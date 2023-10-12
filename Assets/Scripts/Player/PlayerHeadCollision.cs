using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHeadCollision : MonoBehaviour
    {
        private const string PLAYER_ONE_HEAD = "Player_One_Head";
        private const string PLAYER_TWO_HEAD = "Player_Two_Head";

        private HingeJoint2D hingeJoint2D;
        private new Rigidbody2D rigidbody2D;
        private CircleCollider2D circleCollider2D;
        [SerializeField] private float reflectForce = 10f;
        
        private void Start()
        {
            hingeJoint2D = GetComponent<HingeJoint2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (!GameManager.Instance.IsOnePlayerDead() && collision2D.gameObject.GetComponent<IDeadCollision>() != null)
            {
                DisableComponent();
                BounceHead(collision2D);
                if (gameObject.name.Equals(PLAYER_ONE_HEAD))
                {
                    GameManager.Instance.PlayerTwoWin();
                    UIManager.Instance.MainGameUI.AppearResultPlayers(isPlayerOneWin: false);
                }
                else
                {
                    GameManager.Instance.PlayerOneWin();
                    UIManager.Instance.MainGameUI.AppearResultPlayers(isPlayerOneWin: true);
                }
            }
        }

        private void DisableComponent()
        {
            hingeJoint2D.enabled = false;
            this.circleCollider2D.enabled = false;
        }

        private void BounceHead(Collision2D collision2D)
        {
             rigidbody2D.gravityScale = 0f;
             Vector2 contactPoint = collision2D.GetContact(0).point;
             
             Vector2 reflectVectorNormalize = Vector2.Reflect(rigidbody2D.velocity, contactPoint.normalized).normalized;
             if (reflectVectorNormalize.y < 0) reflectVectorNormalize.y = -reflectVectorNormalize.y;
             
             rigidbody2D.velocity = reflectVectorNormalize * reflectForce;
        }
    }
}