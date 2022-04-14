using UnityEngine;

public class MysteryMove : MonoBehaviour
{
    float speed = 5f;
    float timer = 1f;
    SpriteRenderer sr;
  
    void Awake() => sr = GetComponent<SpriteRenderer>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) transform.position += new Vector3(0, 1);
        if (Input.GetKeyDown(KeyCode.E)) transform.position += new Vector3(0, -1);

        if (Input.GetKey(KeyCode.I))
            transform.position += Time.deltaTime * speed * new Vector3(1, 0);
        else if (Input.GetKey(KeyCode.U))
            transform.position += Time.deltaTime * speed * new Vector3(-1, 0);


        timer -= Time.deltaTime * 2f;

        if (timer <= 0f) 
        {
            sr.flipX = !sr.flipX;
            timer = 1f;
            sr.color = Color.white;
        }

        if (sr.flipX)  
        {
            Color newColor = sr.color;
            newColor.a -= 0.0667f; // .a is the alpha (0 = transparent, 1 = opaque)
            sr.color = newColor;
        }
    }
}
