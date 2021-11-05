using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public void Teleport(Transform object_, float x, float y)
    {
        x = (x < 0 || x > 1) ? -1 : 1;
        y = (y < 0 || y > 1) ? -1 : 1;
        object_.position = new Vector3((object_.position.x) * x, (object_.position.y) * y);
    }
}
