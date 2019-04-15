using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotController : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    Texture2D _texture;
    public Texture2D Texture
    {
        get
        {
            return this._texture;
        }
        set
        {
            this._texture = value;
            this.sprites = Resources.LoadAll<Sprite>("Images/Sprites/" + value.name);
            this.m_Image.sprite = sprites[currentSprite];
        }
    }

    Sprite[] sprites;
    int currentSprite = 0;

    int _column;
    public int Column { get; set; }
    int _row;
    public int Row { get; set; }

    float timeOut;
    public float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        // RotateSprites();
    }

    private void RotateSprites()
    {
        if (Time.fixedTime > timeOut + deltaTime)
        {
            this.m_Image.sprite = sprites[currentSprite++];
            this.timeOut += deltaTime;
            if (currentSprite >= this.sprites.Length)
            {
                currentSprite = currentSprite % this.sprites.Length;
            }
        }
    }

    public void Init(int column, int row)
    {
        this.Column = column; this.Row = row;
    }

    public void OnClick()
    {
        Debug.Log(Row + " " + Column + " clicked");
    }
}
