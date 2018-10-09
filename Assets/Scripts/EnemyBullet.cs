using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private float bulletSpeed;

    public void StartBulletMovement(Vector3 direction)
    {
        bulletSpeed = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>().difficultyLevel.enemyBulletSpeed;


        Vector3 dir = direction.normalized;
        GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed);
        StartCoroutine(DestroyBullet());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(1);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
