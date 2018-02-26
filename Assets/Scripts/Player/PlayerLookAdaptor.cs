
using UnityEngine;

public class PlayerLookAdaptor : MonoBehaviour
{
    [Header("Pivots")]
    public Transform Horizontal;
    public Transform Vertical;

    [Header("Controls")]
    public Vector2 Angles;

    public void Update()
    {
        Horizontal.eulerAngles = new Vector3(0f, Angles.x, 0f);
        Vertical.localEulerAngles = new Vector3(Angles.y, 0f, 0f);
    }
}