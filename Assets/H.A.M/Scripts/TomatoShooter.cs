using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoShooter : MonoBehaviour
{
    public GameObject tomatoPrefab;
    public Camera mainCamera;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootTomato();
        }
    }

    void ShootTomato()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(mousePosition.x, mousePosition.y, -mainCamera.transform.position.z)
        );

        targetPosition.z = 0;

        GameObject tomato = Instantiate(
            tomatoPrefab,
            transform.position,
            Quaternion.identity
        );

        TomatoProjectile projectile = tomato.GetComponent<TomatoProjectile>();

        projectile.Launch(targetPosition);
        
    }
}