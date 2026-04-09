using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Rigidbody2D rb2D;

    private float input;
    public int score;
    private LE9Input playerInput;

    private void Awake()
    {
        playerInput = new LE9Input();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        SetScore(0);
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
        playerInput.Player.Move.performed += Move;
        playerInput.Player.Move.canceled += Move;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.performed -= Move;
        playerInput.Player.Move.canceled -= Move;
        playerInput.Player.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb2D.linearVelocityX) <= maxSpeed)
        {
            rb2D.AddForceX(input * moveForce);
        }
        else
        {
            if (Mathf.Sign(input) != Mathf.Sign(rb2D.linearVelocityX))
            {
                rb2D.AddForceX(input * moveForce);
            }
        }

    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = $"Score: {score}";
    }

    public void IncrementScore(int score)
    {
        SetScore(this.score + score);
    }

}
