using UnityEngine;

public class KeysPressed : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.GetChild(0).GetComponent<Animator>().SetBool("Pressed", true);
        else
            transform.GetChild(0).GetComponent<Animator>().SetBool("Pressed", false);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.GetChild(1).GetComponent<Animator>().SetBool("Pressed", true);
        else
            transform.GetChild(1).GetComponent<Animator>().SetBool("Pressed", false);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.GetChild(2).GetComponent<Animator>().SetBool("Pressed", true);
        else
            transform.GetChild(2).GetComponent<Animator>().SetBool("Pressed", false);
        if (Input.GetKey(KeyCode.Space))
            transform.GetChild(3).GetComponent<Animator>().SetBool("Pressed", true);
        else
            transform.GetChild(3).GetComponent<Animator>().SetBool("Pressed", false);
        if (Input.GetKey(KeyCode.F))
            transform.GetChild(4).GetComponent<Animator>().SetBool("Pressed", true);
        else
            transform.GetChild(4).GetComponent<Animator>().SetBool("Pressed", false);
    }
}
