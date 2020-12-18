using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;
    Rigidbody2D enemyRigidbody;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        if (IsFacingRight()) {
            enemyRigidbody.velocity = new Vector2(enemySpeed, 0f);
        } else {
            enemyRigidbody.velocity = new Vector2(-enemySpeed, 0f);
        }
    }

    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other) {
        transform.localScale = new Vector2 (-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
    }
}
