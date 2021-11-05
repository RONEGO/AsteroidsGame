using System.Collections;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        RefClass.paused = true;
        Camera.main.orthographicSize = RefClass.MinOrthSize;
        Camera.main.transform.position = new Vector3(-2, 0, -10f);
    }
    IEnumerator Start()
    {
        GameObject InGameUI = GameObject.Find("InGameCanvas");
        Transform TapToPlay = Instantiate(Resources.Load<GameObject>("ToDownload/TapToPlay"),
            GameObject.Find("Main Canvas").transform).transform;

        InGameUI.SetActive(false);

        for (int i = 0; i < 50; i++)
            yield return new WaitForFixedUpdate();

        while (!Input.anyKeyDown)
            yield return null;
        float during = 50;
        float dif_orth = (RefClass.MaxOrthSize  - RefClass.MinOrthSize)/ during;
        Vector3 dif_pos = -transform.position/during;
        dif_pos.z = 0;

        Destroy(TapToPlay.gameObject);
        for(int i=0; i < during; i++)
        {
            Camera.main.orthographicSize += dif_orth;
            transform.position += dif_pos;
            yield return new WaitForFixedUpdate();
        }
        Camera.main.orthographicSize = RefClass.MaxOrthSize;
        transform.position = new Vector3(0, 0, -10f);
        
        InGameUI.SetActive(true);
        GetComponent<Score>().Starting();
        RefClass.paused = false;
    }
}
