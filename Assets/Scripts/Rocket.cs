using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float bulletSpeed;
    public GameObject player;
    public UberCanvasScript canvas;
    private void OnEnable()
    {

    }

    public void StartRocketMovement(Vector3 direction)
    {

        Vector3 dir = direction.normalized;
        GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed);
        StartCoroutine(DestroyRocket());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(2);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }

    }

    IEnumerator DestroyRocket()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
