using UnityEngine;

public class BulletsSpot : MonoBehaviour
{
    GameObject BulletPrefab;
    private void Start()
    {
        BulletPrefab = Resources.Load<GameObject>("ToDownload/DirectionBullet");
    }

    public void CreateBullet()
    {
        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform Bullet = Instantiate(BulletPrefab, transform).transform;
        Bullet.name = "Bullet";

        Vector3 xyz = Player.position;
        xyz.z += 1;
        Bullet.position = xyz;

        float angle = Player.eulerAngles.z;
        if (angle > 180)
            angle = angle - 360f;

        Bullet.Rotate(0, 0, angle);
    }
}
