using UnityEngine;

public class Shooting : MonoBehaviour
{
    BulletsSpot bullets;
    int Count_CoolDown = 0;

    private void Start()
    {
        bullets = GameObject.Find("Bullets").GetComponent<BulletsSpot>();
    }

    private void FixedUpdate()
    {
        if (RefClass.paused || ++Count_CoolDown < RefClass.BulletCoolDown)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            bullets.CreateBullet();
            Count_CoolDown = 0;
        }
    }
}
