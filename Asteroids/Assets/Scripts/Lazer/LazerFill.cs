using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LazerFill : MonoBehaviour
{
    float dif_image = 0;
    int count_lazers;
    int count_get
    {
        get
        {
            return count_lazers;
        }
        set
        {
            count_lazers = value;
            transform.Find("LazerCount").GetComponent<Text>().text = count_lazers.ToString();
        }
    }

    void Start()
    {
        dif_image = 1f / (RefClass.Lazer_CoolDown *50);
        count_get = 0;
        LazerOut();
    }

    bool updating =false;
    public void LazerOut()
    {
        updating = true;
        GetComponent<Image>().fillAmount = 0;
        StartCoroutine(Filling());
    }

    IEnumerator Filling()
    {
        while (RefClass.paused)
            yield return null;

        for(int i=0; i < RefClass.Lazer_CoolDown * 50; i++)
        {
            GetComponent<Image>().fillAmount += dif_image;
            yield return new WaitForFixedUpdate();
        }
        GetComponent<Image>().fillAmount = 1;
        for(int i=0; i < 10; i++)
            yield return new WaitForFixedUpdate();

        if (++count_get < RefClass.Max_Lazer)
            LazerOut();
        else
            updating = false;
    }

    int cool_down = 0;
    private void FixedUpdate()
    {
        if (RefClass.paused || ++cool_down < 50)
            return;
        if(Input.GetKey(KeyCode.F) && count_lazers > 0)
        {
            cool_down = 0;
            CreateLazer();
        }
    }

    void CreateLazer()
    {
        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform LazerSpot = Instantiate(Resources.Load<GameObject>("ToDownload/LazerSpot")).transform;
        LazerSpot.position = Player.position;

        float angle = Player.eulerAngles.z;
        if (angle > 180)
            angle = angle - 360f;
        LazerSpot.Rotate(0, 0, angle);
        count_get--;
        if (!updating)
            LazerOut();
    }
}
