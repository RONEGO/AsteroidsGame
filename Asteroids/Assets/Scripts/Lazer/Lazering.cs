using System.Collections;
using UnityEngine;

public class Lazering : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Lazer());
    }

    IEnumerator Lazer()
    {
        GameObject bullet = Resources.Load<GameObject>("ToDownload/LazerBullet");

        float dif_bullet = bullet.transform.localScale.y * 2;

        Transform LastBullet;
        Vector3 WhereIsLastBullet;
        do
        {
            LastBullet = Instantiate(bullet, transform).transform;
            LastBullet.localPosition = new Vector3(0, (transform.childCount + 1) * dif_bullet);
            WhereIsLastBullet = Camera.main.WorldToViewportPoint(LastBullet.position);
            yield return new WaitForFixedUpdate();
        } while (WhereIsLastBullet.x >= 0 && WhereIsLastBullet.x <= 1 && WhereIsLastBullet.y >= 0 && WhereIsLastBullet.y <= 1);

        Transform[] bullets_lazer = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            bullets_lazer[i] = transform.GetChild(i);
        for (int i = 0; i < 50; i++)
            yield return new WaitForFixedUpdate();
        for (int i = 0; i < bullets_lazer.Length; i++)
        {
            Destroy(bullets_lazer[i].gameObject);
            yield return new WaitForFixedUpdate();
        }

        Destroy(this.gameObject);
    }
}
