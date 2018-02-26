using UnityEngine;

[RequireComponent(typeof(PlayerLookAdaptor))]
public class PlayerLookInput : MonoBehaviour
{
    public PlayerLookAdaptor Look;

    [Header("Settings")]
    public float Sensitivity = 1;
    public bool InvertY;
    public Vector2 VerticalConstrains = new Vector2(-90f, 90f);

    [ReadOnly]
    public Vector2 Offset;

    public void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        x *= Sensitivity;
        y *= Sensitivity * (InvertY ? 1f : -1f);

        Offset.x += x;
        Offset.y += y;

        Offset.y = Mathf.Clamp(Offset.y, VerticalConstrains.x, VerticalConstrains.y);

        Look.Angles = Offset;
    }
}