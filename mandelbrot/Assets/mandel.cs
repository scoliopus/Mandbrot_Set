using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class mandel : MonoBehaviour
{
    public float iterationsGreat;
    public float sizeGreat;
    public float iterationsGood;
    public float sizeGood;
    public float iterationsBad;
    public float sizeBad;
    
    public RawImage image;

    public Text text;

    [HideInInspector] public bool drawEdege = false;
    [HideInInspector] public bool movingMode = false;

    [HideInInspector] public float iterations;
    [HideInInspector] public float size;
    [HideInInspector] public float bounds;

    [HideInInspector] public Vector2 offset;

    private float h;
    private float w;
    
    private Texture2D texture;
    
    void Start()
    {
        offset = Vector2.zero;

        size = sizeGood;
        iterations = iterationsGood;
        bounds = 3;

        h = Camera.main.scaledPixelHeight;
        w = Camera.main.scaledPixelWidth;

        iterations = iterationsGood;
        size = sizeGood;

        image.rectTransform.sizeDelta = new Vector2(w, w);

        draw();
    }
    
    public void draw()
    {
        float m;
        float edge;

        Vector2 vector2;

        edge = size / w * ((w - h) * 0.5f);

        texture = new Texture2D(Mathf.RoundToInt(size), Mathf.RoundToInt(size));

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if (((y < edge) || (y > (size - edge))) && !drawEdege)
                {
                    m = 0.5f;
                }
                else
                {
                    vector2 = new Vector2(Mathf.Lerp(-bounds, bounds, x / size), Mathf.Lerp(-bounds, bounds, y / size));
                    vector2 += offset;
                    m = isStable(vector2);
                    if (m < iterations) m = Mathf.Sqrt(m / iterations);
                    else m = 0;
                }

                texture.SetPixel(x, y, new Color(m, m, m, 1));
            }
        }
        
        image.texture = texture;

        texture.Apply(true);
    }


    private float isStable(Vector2 c)
    {
        Vector2 z;
        z = Vector2.zero;

        for (int i = 0; i < iterations; i++)
        {
            z = new Vector2((z.x * z.x) - (z.y * z.y), (z.x * z.y) + (z.y * z.x));
            z += c;
            if (z.magnitude >= 2) return i - Mathf.Log(Mathf.Log(z.magnitude) / Mathf.Log(2));
        }

        return iterations;
    }

    public void saveTexture()
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveImages/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "Image" + Path.GetRandomFileName() + ".png", bytes);

        text.text = "Saved in: " + dirPath;
    }
}