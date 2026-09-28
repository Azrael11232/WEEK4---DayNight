using UnityEngine;

public class block : MonoBehaviour
{
    public SpriteRenderer color;
    public Collider2D colliding;

    public int enable;
    public int disable;

    public Color one;
    public Color two;

    public bool True;
    public bool False;

    public float en;
    public float dis;
    

    void Update()
    {
        ColorChange();
    }

    void ColorChange()
    {
        int Light = Game.instance.Light;

        if (Light == enable)
        {
            one.a = en;
            color.color = one;
            colliding.enabled = True;
            color.sortingOrder = 2;
        }
        
        else if (Light == disable)
        {
            two.a = dis;
            color.color = two;
            colliding.enabled = False;
            color.sortingOrder = 1;
        }
    }
}