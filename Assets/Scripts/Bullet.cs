using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject player;

    public void StartBulletMovement(Vector3 direction)
    {
        player = GameObject.FindGameObjectWithTag("Player");
       


        Vector3 dir = direction.normalized + player.GetComponent<Rigidbody>().velocity/player.GetComponent<PlayerController>().maxSpeed;
        //Debug.Log(direction + " " + player.GetComponent<Rigidbody>().velocity);
        
        GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed);
        
        StartCoroutine(DestroyBullet());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(1);
            gameObject.SetActive(false);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    

}
