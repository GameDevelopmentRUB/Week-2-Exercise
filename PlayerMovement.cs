using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is the default sprite
    [SerializeField] Sprite idleSprite;

    // This array holds the walk cycle
    [SerializeField] Sprite[] sprites;

    // Time between sprite changes
    [SerializeField] float animationTime = 1f;

    // Speed of the character
    [SerializeField] float speed = 3f;

    SpriteRenderer sr;

    int spriteIndex = 0; 
    float timer;

    void Awake() => sr = GetComponent<SpriteRenderer>();
    void Start() => timer = animationTime;

    void Update()
    {
        Vector3 moveVector = Vector3.zero;

        // Get input and save state in moveVector
        if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
        if (Input.GetKey(KeyCode.A)) moveVector.x = -1;
        if (Input.GetKey(KeyCode.S)) moveVector.y = -1;
        if (Input.GetKey(KeyCode.D)) moveVector.x = 1;

        // Normalize vector, so that magnitude for diagonal movement is also 1
        moveVector.Normalize();

        // Frame rate independent movement
        transform.position += speed * Time.deltaTime * moveVector;

        // Flip the sprite if facing to the left
        if (moveVector.x != 0) sr.flipX = moveVector.x < 0;

        // Check if the character is moving
        if (moveVector != Vector3.zero)
        {
            // This will be at 0 after the seconds set by 'animationTime'
            timer -= Time.deltaTime;

            // 'animationTime' is at 0
            if (timer <= 0f)
            {
                // Load the next sprite and loop around when end of the array is reached
                spriteIndex = (spriteIndex + 1) % sprites.Length;
                sr.sprite = sprites[spriteIndex];

                // Reset the timer, otherwise it'll continue going down
                timer = animationTime;
            }
        }
        else
        {
            // Reset the sprite to idle if character is not moving
            sr.sprite = idleSprite;
        } 
    }
}
