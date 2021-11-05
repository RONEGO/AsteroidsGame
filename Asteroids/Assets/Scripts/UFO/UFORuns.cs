using System.Collections;
using UnityEngine;

public class UFORuns : MonoBehaviour
{
    public bool targeting = false;
    IEnumerator Start()
    {
        health = 3;
        minus_health = 1f / (float)health;
        if (!GameObject.FindGameObjectWithTag("Player"))
            yield break;

        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;
        while (transform.position != Player.position)
        {
            Vector3 dif = (Player.position - transform.position) / RefClass.UFOs_Speed;
            targeting = true;
            for (int i=0;i< RefClass.UFOs_Speed && !RefClass.paused; i++)
            {
                transform.position += dif;
                yield return new WaitForFixedUpdate();
            }
            targeting = false;
            if (RefClass.paused)
                break;
            for (int i = 0; i < 50; i++)
                yield return new WaitForFixedUpdate();
        }
    }

    int health = 0;
    float minus_health = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Lazer")
        {
            if(other.tag != "Lazer")
                Destroy(other.transform.parent.gameObject);
            if (--health > 0)
            {
                Color color = GetComponent<SpriteRenderer>().color;
                color.g -= minus_health;
                color.b -= minus_health;
                GetComponent<SpriteRenderer>().color = color;
            }
            else
            {
                Destroy(gameObject);
                Camera.main.GetComponent<Score>().score_get += 200;
            }
        }
    }
}
