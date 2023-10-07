using UnityEngine;
using Unity.Collections;
using System.Collections;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class PlayerCollision : MonoBehaviour
    {
        private const string PLAYER_ONE_HEAD = "Player_1_Head";
        private const string PLAYER_TWO_HEAD = "Player_2_Head";
        private HingeJoint2D hingeJoint2D;
        private Rigidbody2D rigidbody2D;
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
            if (collision2D.gameObject.GetComponent<IDeadCollision>() != null && !GameManager.Instance.IsOnePlayerDead())
            {
                DisableComponent();
                BounceHead(collision2D);
                StartCoroutine(this.ReloadScene());
                if(gameObject.name == PLAYER_ONE_HEAD) GameManager.Instance.PlayerTwoWin();
                else GameManager.Instance.PlayerOneWin();
            }
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(1.5f);
            int numberScene = SceneManager.GetActiveScene().buildIndex;
            GameManager.Instance.PlayeAgain();
            SceneManager.LoadScene(numberScene);
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