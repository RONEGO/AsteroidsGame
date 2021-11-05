using UnityEngine;

public class BulletRun : MonoBehaviour
{
    int TimeLife = 100;

    private void FixedUpdate()
    {
        Vector3 xyz = transform.localPosition;
        xyz.y += RefClass.Bullet_Speed * Time.deltaTime;
        transform.localPosition = xyz;

        transform.parent.position = transform.position;
        xyz = transform.localPosition;
        xyz.y = 0;
        transform.localPosition = xyz;


        if (--TimeLife < 0)
            Destroy(transform.parent.gameObject);

        Vector2 WhereIsBullet = Camera.main.WorldToViewportPoint(transform.position);
        if (WhereIsBullet.x < 0
            || WhereIsBullet.x > 1
            || WhereIsBullet.y < 0
            || WhereIsBullet.y > 1)
        {
            Camera.main.GetComponent<Teleporting>().Teleport(transform.parent, WhereIsBullet.x, WhereIsBullet.y);
        }
    }
}
