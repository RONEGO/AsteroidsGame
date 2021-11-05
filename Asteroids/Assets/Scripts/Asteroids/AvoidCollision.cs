using System.Collections;
using UnityEngine;

public class AvoidCollision : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SphereCollider>().enabled = false;
    }

    IEnumerator Start()
    {
        for (int i = 0; i < 50; i++)
            yield return new WaitForFixedUpdate();
        GetComponent<SphereCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Detecter")
        {
            StartCoroutine(TwoAsteroids(transform.parent.parent,
                other.transform.parent.parent));
        }
        if(other.tag == "UFO")
        {
            StartCoroutine(OneAsteroid(transform.parent.parent));
        }
    }

    IEnumerator TwoAsteroids(Transform Asteroid1, Transform Asteroid2)
    {

        Debug.Log("TWO");
        int Rotation = Random.Range(45, 90);
        int speed_rot = 50;

        float speedRot = -(float)Rotation / speed_rot;
        for(int i=0; i < speed_rot; i++)
        {
            if (Asteroid1 == null || Asteroid2 == null)
                break;
            Asteroid1.Rotate(0, 0, speedRot);
            Asteroid2.Rotate(0, 0, speedRot);
            yield return new WaitForFixedUpdate();
        }

    }

    IEnumerator OneAsteroid(Transform Asteroid)
    {

        int Rotation = 180;
        int speed_rot = 25;

        float speedRot = -(float)Rotation / speed_rot;

        for (int i = 0; i < speed_rot; i++)
        {
            if (Asteroid == null)
                break;
            Asteroid.Rotate(0, 0, speedRot);
            yield return new WaitForFixedUpdate();
        }

    }
}
