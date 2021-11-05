using UnityEngine;

public class Bumping : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid" || other.tag=="UFO")
        {
            RefClass.paused = true;
            Camera.main.GetComponent<GameEnd>().EndGame();
        }
    }
}
