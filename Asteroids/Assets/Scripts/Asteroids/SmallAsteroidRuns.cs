using UnityEngine;

public class SmallAsteroidRuns : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (RefClass.paused)
        {
            GetComponent<SmallAsteroidRuns>().enabled = false;
            return;
        }

        Vector3 xyz = transform.localPosition;
        xyz.y += RefClass.SmallAsteroid_Speed * Time.deltaTime;
        transform.localPosition = xyz;

        transform.parent.position = transform.position;
        xyz = transform.localPosition;
        xyz.y = 0;
        transform.localPosition = xyz;

        Vector2 WhereIsAsteroid = Camera.main.WorldToViewportPoint(transform.position);
        if (WhereIsAsteroid.x < 0
            || WhereIsAsteroid.x > 1
            || WhereIsAsteroid.y < 0
            || WhereIsAsteroid.y > 1)
            Camera.main.GetComponent<Teleporting>().Teleport(transform.parent, WhereIsAsteroid.x, WhereIsAsteroid.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Camera.main.GetComponent<Score>().score_get += 50;
            Destroy(transform.parent.gameObject);
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag == "Lazer")
        {
            Camera.main.GetComponent<Score>().score_get += 50;
            Destroy(transform.parent.gameObject);
        }
    }
}
