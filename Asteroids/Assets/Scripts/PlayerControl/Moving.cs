using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 0;

    Transform Parent;

    Vector3 direction;

    private void Start()
    {
        Parent = transform.parent;
    }

    private void FixedUpdate()
    {
        if (RefClass.paused)
            return;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (speed < RefClass.SpeedPlayer)
                speed += RefClass.SpeedPlayer / 75f;
            else
                speed = RefClass.SpeedPlayer;
        }

        if (!Input.GetKey(KeyCode.UpArrow))
        {
            if (speed > 0)
                speed -= RefClass.SpeedPlayer / 100f;
            else
                speed = 0;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Parent.position = transform.position;
            transform.localPosition = new Vector3();

            Parent.Rotate(0, 0, RefClass.SpeedPlayer);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Parent.position = transform.position;
            transform.localPosition = new Vector3();

            Parent.Rotate(0, 0, -RefClass.SpeedPlayer);

        }

        direction = transform.localPosition;
        direction.y += speed * Time.deltaTime;
        transform.localPosition = direction;

        Vector2 WhereIsPlayer = Camera.main.WorldToViewportPoint(transform.position);

        if(WhereIsPlayer.x < 0
            || WhereIsPlayer.x > 1
            || WhereIsPlayer.y < 0
            || WhereIsPlayer.y > 1)
        {
            Parent.position = transform.position;
            transform.localPosition = new Vector3();
            Camera.main.GetComponent<Teleporting>().Teleport(Parent, WhereIsPlayer.x, WhereIsPlayer.y);
        }
            
    }
}
