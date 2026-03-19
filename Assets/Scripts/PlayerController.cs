using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Rigidbody2D rb2D;

    private float input;
    public int score;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        SetScore(0);
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
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
