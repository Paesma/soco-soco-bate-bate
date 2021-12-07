using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anel : MonoBehaviour
{
    public AudioClip EfeitoSonoroAnel;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(EfeitoSonoroAnel);
            GetComponent<Animator>().SetBool("anelestrelas", true);
            StartCoroutine(espera());


        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
