using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour
{
    Transform Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if(Player == null)
        {
            GetComponent<Stats>().enabled = false;
            return;
        }
        float x = Mathf.Round(Player.position.x * 100) / 100f;
        float y = Mathf.Round(Player.position.y * 100) / 100f;

        GetComponent<Text>().text = "(" + x + " ; " + y + ") " + Mathf.Round(Player.eulerAngles.z) + "°";
    }
}
