using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    [SerializeField] float topPadding = 6f;
    InputAction moveAction;
    Vector3 moveVector;

    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); // Replace "Move" with the actual name of your input action
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position  + moveVector * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + padding, maxBounds.x - padding); // Clamp the player's position to stay within the screen bounds 
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + padding, maxBounds.y - topPadding);

        transform.position = newPos; // Adjust movement speed as needed
        
    }
}
