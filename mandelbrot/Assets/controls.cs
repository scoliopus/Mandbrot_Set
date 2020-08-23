using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    public mandel mandel;

    public Text text;

    private float h;
    private float w;
    
    void Start()
    {
        h = Camera.main.scaledPixelHeight;
        w = Camera.main.scaledPixelWidth;

        text.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && mandel.movingMode)
        {
            text.text = "";

            if (mandel.drawEdege)
            {
                mandel.image.rectTransform.sizeDelta = new Vector2(w, w);

                mandel.drawEdege = false;

                mandel.draw();
            }
            else
            {
                mandel.image.rectTransform.sizeDelta = new Vector2(h, h);

                mandel.drawEdege = true;

                mandel.draw();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && mandel.movingMode)
        {
            text.text = "";

            mandel.offset = Vector2.zero;
            mandel.bounds = 3;
            mandel.draw();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            text.text = "";

            mandel.iterations = mandel.iterationsBad;
            mandel.size = mandel.sizeBad;

            mandel.movingMode = true;

            mandel.draw();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            text.text = "";

            mandel.iterations = mandel.iterationsGood;
            mandel.size = mandel.sizeGood;

            mandel.movingMode = false;

            mandel.draw();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            text.text = "";

            mandel.iterations = mandel.iterationsGreat;
            mandel.size = mandel.sizeGreat;

            mandel.movingMode = false;

            mandel.draw();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            mandel.saveTexture();
        }

        if (Input.GetKey(KeyCode.W) && mandel.movingMode)
        {
            text.text = "";

            mandel.offset.y += mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }
        else if (Input.GetKey(KeyCode.S) && mandel.movingMode)
        {
            text.text = "";

            mandel.offset.y -= mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }

        if (Input.GetKey(KeyCode.D) && mandel.movingMode)
        {
            text.text = "";

            mandel.offset.x += mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }
        else if (Input.GetKey(KeyCode.A) && mandel.movingMode)
        {
            text.text = "";

            mandel.offset.x -= mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }

        if (Input.GetKey(KeyCode.E) && mandel.movingMode)
        {
            text.text = "";

            mandel.bounds -= mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }
        else if (Input.GetKey(KeyCode.Q) && mandel.movingMode)
        {
            text.text = "";

            mandel.bounds += mandel.bounds / 4 * Time.deltaTime;
            mandel.draw();
        }
    }
}
