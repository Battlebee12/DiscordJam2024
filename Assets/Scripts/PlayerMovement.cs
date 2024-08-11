using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f); // 2D Movement speed to have independant axis speed
    private new Rigidbody2D rigidbody2D; 
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    [SerializeField] private GameObject playervisual;
    //[SerializeField] private Sprite playerVisual;
     public int MovementDirection { get; private set; }
     public int MovementDirectionVertical { get; private set; }

    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (inputVector.x > 0)
        {
            MovementDirection = 1; // Moving right
            playervisual.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputVector.x < 0)
        {
            MovementDirection = -1; // Moving left
            playervisual.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            MovementDirection = 0; // No horizontal movement
        }
        if (inputVector.y > 0)
        {
            MovementDirectionVertical = 1; // Moving up
            // You could add logic to flip or adjust the sprite when moving up if necessary
        }
        else if (inputVector.y < 0)
        {
            MovementDirectionVertical = -1; // Moving down
            // You could add logic to flip or adjust the sprite when moving down if necessary
        }
        else
        {
            MovementDirectionVertical = 0; // No vertical movement
        }
    }

    void FixedUpdate()
    {

        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }


}