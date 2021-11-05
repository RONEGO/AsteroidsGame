using System.Collections;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public void EndGame()
    {
        StartCoroutine(CameraZooming());
    }

    IEnumerator CameraZooming()
    {
        float during = 75f;

        float dif_orth = (RefClass.MaxOrthSize - RefClass.MinOrthSize)/during;
        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 dif_xyz = (transform.position - Player.position) / during;
        dif_xyz.z = 0;
        Player.GetComponent<Animator>().Play("Blink");
        Destroy(GameObject.Find("InGameCanvas").gameObject);
        for(int i=0; i < during; i++)
        {
            Camera.main.orthographicSize -= dif_orth;
            transform.position -= dif_xyz;
            yield return new WaitForFixedUpdate();
        }
        for(int i=0; i< 50; i++)
        {
            Player.GetComponent<Animator>().speed *= 1.1f;
            yield return new WaitForFixedUpdate();
        }
        Destroy(Player.gameObject);

        Transform EndBlack = Instantiate(Resources.Load<GameObject>("ToDownload/End"),
            GameObject.Find("Main Canvas").transform).transform;
        EndBlack.GetComponent<RectTransform>().anchoredPosition = new Vector2();
    }
}
