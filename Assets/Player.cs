using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer color;
    public Rigidbody2D rb;
    public int speed;
    public int jump;
    public bool OnGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        ColorChange();
    }



    void movement()
    {
        float x = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            x = -speed;
        if (Input.GetKey(KeyCode.RightArrow))
            x = speed;
        if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround == true)
        {
            rb.AddForce(Vector2.up * jump);
            OnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Game.instance.Light = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Game.instance.Light = 2;

        rb.linearVelocity = new Vector2(x,rb.linearVelocityY);
    }

    void ColorChange()
    {
        int Light = Game.instance.Light;

        if (Light == 1)
        {
            color.color = Color.white;
            color.sortingOrder = 3;
        }
        else if (Light == 2)
            color.color = Color.black;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("floor"))
            OnGround = true;
    }

    void OnCollisionStay2D(Collision2D wall)
    {
        if (wall.gameObject.CompareTag("wall"))
        {
            OnGround = true;
            if (rb.linearVelocityY < -3)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, -5);
            }
        }
    }
}
