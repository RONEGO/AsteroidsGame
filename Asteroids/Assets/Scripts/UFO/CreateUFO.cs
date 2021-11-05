using System.Collections;
using UnityEngine;

public class CreateUFO : MonoBehaviour
{
    bool wait;

    GameObject UFO;

    IEnumerator Start()
    {
        wait = true;
        UFO = Resources.Load<GameObject>("ToDownload/UFO");
        for (int i = 0; i < 20; i++)
            yield return new WaitForSeconds(1f);
        wait = false;
    }

    int counter = 0;
    private void FixedUpdate()
    {
        if (RefClass.paused)
            return;

        if (wait)
            return;
        if (++counter >= RefClass.UFOs_CoolDown_Creating && GameObject.FindGameObjectsWithTag("UFO").Length < RefClass.UFOs_MaxCount)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("UFO");
            foreach (GameObject gameObject in gameObjects)
                if (!gameObject.GetComponent<UFORuns>().targeting)
                    return;
            counter = 0;
            StartCoroutine(CreateUFO_());
        }
    }

    IEnumerator CreateUFO_()
    {
        Transform ufo = Instantiate(UFO, transform).transform;
        ufo.name = "UFO";
        ufo.GetComponent<SphereCollider>().enabled = false;
        ufo.localPosition = new Vector3();

        Vector3 xyz;
        while(Camera.main.WorldToViewportPoint(ufo.position).y < 1.1f)
        {
            xyz = ufo.position;
            xyz.y += 1f;
            ufo.position = xyz;
        }
        ufo.GetComponent<UFORuns>().enabled = false;
        for (int i = 0; i < 5; i++)
            yield return new WaitForSeconds(1f);
        ufo.GetComponent<UFORuns>().enabled = true;
        ufo.GetComponent<SphereCollider>().enabled = true;
    }
}
