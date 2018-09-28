using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject player;
    public UberCanvasScript canvas;
    private void OnEnable()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>();
    }

    public void StartBulletMovement(Vector3 direction)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        


        Vector3 dir = direction.normalized + player.GetComponent<Rigidbody>().velocity/player.GetComponent<PlayerController>().maxSpeed;
        //Debug.Log(direction + " " + player.GetComponent<Rigidbody>().velocity);
        
        GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed);
        canvas.bulletsShot++;
        StartCoroutine(DestroyBullet());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(1);
            gameObject.SetActive(false);
            canvas.bulletsHit++;
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
