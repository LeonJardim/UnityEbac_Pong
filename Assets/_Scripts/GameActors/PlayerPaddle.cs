using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed = 5f;
    private PlayerInputActions playerControls;
    private InputAction move;
    public SpriteRenderer spriteRenderer;

    #region Enable/Disable
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        move = playerControls.Player.UpDown;
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    #endregion
    
    void Start()
    {
        spriteRenderer.color = SaveController.Instance.playerColor;
    }
    private void FixedUpdate()
    {
        float directionToMove = move.ReadValue<float>();
        Vector3 newPosition = transform.position + directionToMove * speed * Time.deltaTime * Vector3.up;
        newPosition.y = Mathf.Clamp(newPosition.y, -3.7f, 3.7f);

        transform.position = newPosition;
    }
}
