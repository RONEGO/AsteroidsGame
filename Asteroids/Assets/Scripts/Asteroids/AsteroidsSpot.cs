using UnityEngine;
using System.Collections;

public class AsteroidsSpot : MonoBehaviour
{
    int count = 1;

    GameObject Asteroid;

    IEnumerator Start()
    {
        Asteroid = Resources.Load<GameObject>("ToDownload/BigAsteroidSpot");
        for (count = 1; count < RefClass.Asteroids_MaxCount; count++)
            for (int j = 0; j < 5 * 50; j++)
                yield return new WaitForFixedUpdate();
    }

    int timer = timer_max;
    const int timer_max = 100;

    private void FixedUpdate()
    {
        if (RefClass.paused)
            return;

        if (timer < timer_max)
            timer++;

        if(timer >= timer_max && GameObject.FindGameObjectsWithTag("Asteroid").Length < count)
        {
            timer = 0;
            StartCoroutine(Creating());
        }
    }

    int direction = 0;

    IEnumerator Creating()
    {
        Transform asteroid = Instantiate(Asteroid, transform).transform.GetChild(0);
        asteroid.parent.name = "BigAsteroid";

        asteroid.GetComponent<BigAsteroidRuns>().enabled = false;
        asteroid.parent.localPosition = new Vector3();

        Vector3 xyz;
        int prev_direction = direction;
        do
        {
            direction = Random.Range(0, 4);
        } while (direction == prev_direction);

        switch(direction)
        {
            //down
            case 0:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).y  > -0.1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.y--;
                    asteroid.parent.position = xyz;
                }
                break;
            //left
            case 1:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).x > -0.1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.x--;
                    asteroid.parent.position = xyz;
                }
                break;
            //up
            case 2:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).y < 1.1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.y++;
                    asteroid.parent.position = xyz;
                }
                break;
            //right
            case 3:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).x < 1.1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.x++;
                    asteroid.parent.position = xyz;
                }
                break;
        }
        
        asteroid.GetComponent<SpriteRenderer>().enabled = true;
        asteroid.GetComponent<SphereCollider>().enabled = false;
        asteroid.parent.gameObject.transform.Rotate(0, 0, Random.Range(-45, 45) - (direction*90));

        float speed = 1;
        switch (direction)
        {
            //down
            case 0:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).y <= 0f)
                {
                    xyz = asteroid.parent.position;
                    xyz.y += speed*Time.deltaTime;
                    asteroid.parent.position = xyz;
                    yield return new WaitForFixedUpdate();
                }
                break;
            //left
            case 1:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).x <= 0f)
                {
                    xyz = asteroid.parent.position;
                    xyz.x += speed * Time.deltaTime;
                    asteroid.parent.position = xyz;
                    yield return new WaitForFixedUpdate();
                }
                break;
            //up
            case 2:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).y >= 1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.y -= speed * Time.deltaTime;
                    asteroid.parent.position = xyz;
                    yield return new WaitForFixedUpdate();
                }
                break;
            //right
            case 3:
                while (Camera.main.WorldToViewportPoint(asteroid.parent.position).x >= 1f)
                {
                    xyz = asteroid.parent.position;
                    xyz.x -= speed * Time.deltaTime;
                    asteroid.parent.position = xyz;
                    yield return new WaitForFixedUpdate();
                }
                break;
        }
        asteroid.GetComponent<SphereCollider>().enabled = true;
        asteroid.GetComponent<BigAsteroidRuns>().enabled = true;

        /*
        while ((up && Camera.main.WorldToViewportPoint(asteroid.position).y >= 0.9f) ||
            (!up && Camera.main.WorldToViewportPoint(asteroid.position).y <= 0.1f))
        {
            xyz = asteroid.localPosition;
            xyz.y += 1 * Time.deltaTime;
            asteroid.localPosition = xyz;
            yield return new WaitForFixedUpdate();
        }
        asteroid.GetComponent<SphereCollider>().enabled = true;
        asteroid.GetComponent<BigAsteroidRuns>().enabled = true;
        */

    }
}
