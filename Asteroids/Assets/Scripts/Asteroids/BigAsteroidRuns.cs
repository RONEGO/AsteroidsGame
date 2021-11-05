using UnityEngine;

public class BigAsteroidRuns : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void FixedUpdate()
    {
        if(RefClass.paused)
        {
            GetComponent<BigAsteroidRuns>().enabled = false;
            return;
        }

        Vector3 xyz = transform.localPosition;
        xyz.y += RefClass.BigAsteroid_Speed * Time.deltaTime;
        transform.localPosition = xyz;

        transform.parent.position = transform.position;
        xyz = transform.localPosition;
        xyz.y = 0;
        transform.localPosition = xyz;


        Vector2 WhereIsAster = Camera.main.WorldToViewportPoint(transform.position);
        if (WhereIsAster.x < 0
            || WhereIsAster.x > 1
            || WhereIsAster.y < 0
            || WhereIsAster.y > 1)
        {
            Camera.main.GetComponent<Teleporting>().Teleport(transform.parent, WhereIsAster.x, WhereIsAster.y);
        }
    }

    bool creating = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!creating && other.tag == "Bullet")
        {
            creating = true;

            Destroy(other.transform.parent.gameObject);
            Camera.main.GetComponent<Score>().score_get += 100;
            CreateTwoAsteroids();
        }

        if (!creating && other.tag == "Lazer")
        {
            creating = true;
            Camera.main.GetComponent<Score>().score_get += 100;
            CreateTwoAsteroids();
        }
    }
    
    void CreateTwoAsteroids()
    {
        Destroy(transform.parent.gameObject);
        GameObject SmallAst = Resources.Load<GameObject>("ToDownload/SmallAsteroidSpot");
        float angle = transform.parent.eulerAngles.z;
        if (angle > 180)
            angle -= 360;

        Transform Small = Instantiate(SmallAst, transform.parent.parent).transform;
        Small.localPosition = transform.parent.localPosition;
        Small.name = "SmallAsteroid";
        Small.Rotate(0, 0, angle + 45);

        Small = Instantiate(SmallAst, transform.parent.parent).transform;
        Small.localPosition = transform.parent.localPosition;
        Small.name = "SmallAsteroid";
        Small.Rotate(0, 0, angle - 45);
    }
}
