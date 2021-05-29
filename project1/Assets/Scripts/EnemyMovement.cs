using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   //Should use NavMesh or at least A*
    public GameObject player;
    public float moveSpeed = 3f;
    public int enemyHealth;

    Rigidbody2D rb;
    SimpleFlash flashEffect;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        flashEffect = this.GetComponent<SimpleFlash>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = (player.transform.position - this.transform.position);
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1) * 5.6f;
        }
        else
        {
            transform.localScale = Vector3.one * 5.6f;
        }
        //if (moveDirection.sqrMagnitude > 4f)
        //{
        //    rb.MovePosition(this.transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
        //}
        rb.MovePosition(this.transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackSprite")
        {
            takeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().takeDamage(25);
        }
    }

    public void takeDamage(int d = 25)
    {
        enemyHealth -= d;
        flashEffect.Flash();
    }
}
