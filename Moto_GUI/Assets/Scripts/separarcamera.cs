using UnityEngine;

public class separarcamera : MonoBehaviour
{
    [SerializeField] private bool isPlayer1 = true;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        if (cam == null) cam = GetComponentInChildren<Camera>();

        if (cam != null)
        {
            if (isPlayer1)
            {
                cam.rect = new Rect(0f, 0f, 0.5f, 1f);
            }
            else
            {
                cam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
            }
        }
    }
}