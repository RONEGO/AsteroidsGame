using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    IEnumerator Start()
    {
        transform.Find("Score").GetComponent<Text>().text = "Score " + RefClass.score;
        while (!Input.anyKeyDown)
        {
            Debug.Log("WAit!");
            yield return new WaitForFixedUpdate();
        }
        SceneManager.LoadScene(0);
    }
}
