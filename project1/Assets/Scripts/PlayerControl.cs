using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 3.14f;
    public GameObject attackSprite;
    public float attackDuration = 0.125f;
    public float attackRange = 2f;

    Rigidbody2D rb;
    Camera cam;
    Transform orbHolder;
    Coroutine attacking;
    int health = 100;
    SimpleFlash flashEffect;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
        orbHolder = this.gameObject.transform.GetChild(1);
        flashEffect = GetComponent<SimpleFlash>();
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mousePos.z = 0f;
        Vector3 differ = mousePos - orbHolder.position;
        float rotationZ = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
        orbHolder.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attacking == null)
            {
                attacking = StartCoroutine("Attack", attackDuration);
            }
        }
    }

    void FixedUpdate()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(mx, my, 0f).normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(this.transform.position + moveDirection);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        flashEffect.Flash();
    }

    IEnumerator Attack(float duration)
    {
        Vector3 spawnPos = orbHolder.position + (orbHolder.GetChild(0).position - orbHolder.position).normalized * attackRange;
        GameObject attack = Instantiate(attackSprite, spawnPos, Quaternion.Euler(orbHolder.eulerAngles));
        attack.SetActive(true);
        yield return new WaitForSeconds(duration);
        Destroy(attack);
        attacking = null;
    }
}
