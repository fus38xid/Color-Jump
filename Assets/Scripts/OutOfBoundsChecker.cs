using UnityEngine;

public class OutOfBoundsChecker : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public bool IsOutOfView(Transform player)
    {
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(player.position);
        return screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y > 1;
    }
}
