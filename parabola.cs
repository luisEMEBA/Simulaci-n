﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parabola : MonoBehaviour
{
    public float v0;
    public GameObject bola1, bola2, bola3;
    float y01, x01, y11, x11, y02, x02, y12, x12, y03, x03, y13, x13;
    float g =9.98f;
    float tiempo, tiempoi, tiempo2, tiempoi2, tiempo3, tiempoi3;
    public float delta;
    public float potencia, alfa;
    public float fuerza_del_viento;
    float k1x, k2x, k1y, k2y;
    float q1x, q1y, q2x, q2y, q3x, q3y, q4x, q4y;
    Vector3 posicion1, posicion2, posicion3;
    // Start is called before the first frame update
    void Start()
    {
        tiempoi = Time.time;
        tiempoi2 = Time.time;
        tiempoi3 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        posicion1 = bola1.gameObject.GetComponent<Transform>().position;
        y01 = posicion1.y;
        x01 = posicion1.x;
        if (posicion1.y >= 1)
        {
            tiempo = Time.time;
            tiempo = tiempo - tiempoi;
            y11 = y01 + (delta * ((Mathf.Sin(alfa)) * tiempo * v0) - ((g) * (Mathf.Pow(tiempo, 2)))) + potencia;
            y01 = y11;
            posicion1.y = y11;

            x11 = x01 + (delta * (v0 * Mathf.Cos(alfa) * tiempo)) + potencia;
            x01 = x11;
            posicion1.x = x11;
			Debug.Log("LLEGA");
        }
        else
        {

        }
        bola1.gameObject.GetComponent<Transform>().position = posicion1;


        posicion2 = bola2.gameObject.GetComponent<Transform>().position;
        y02 = posicion2.y;
        x02 = posicion2.x;
        tiempo2 = Time.time;
        tiempo2 = tiempo2 - tiempoi2;

        if (posicion2.y >= 1)
        {
            k1y = (v0 * (Mathf.Sin(alfa)) * tiempo2) - (g * (Mathf.Pow(tiempo2, 2)) ) + potencia;
            k2y = (v0 * (Mathf.Sin(alfa)) * (tiempo2 + delta)) - (g * (Mathf.Pow((tiempo2 + delta), 2))) + potencia;
            y12 = y02 + (delta * (0.5f * k1y + 0.5f * k2y)) + potencia;
            y02 = y12;
            posicion2.y = y12;

            k1x = (v0*(Mathf.Cos(alfa))*tiempo2) + potencia;
            k2x = (v0 * (Mathf.Cos(alfa)) * (tiempo2+delta)) + potencia;
            x12 = x02 + (delta * (0.5f * k1x + 0.5f * k2x)) + potencia;
            x02 = x12;
            posicion2.x = x12;
        }
        else
        {

        }
        bola2.gameObject.GetComponent<Transform>().position = posicion2;

        posicion3 = bola3.gameObject.GetComponent<Transform>().position;
        y03 = posicion3.y;
        x03 = posicion3.x;
        tiempo3 = Time.time;
        tiempo3 = tiempo3 - tiempoi3;

        if (posicion3.y >= 0) {
            q1y = (v0 * (Mathf.Sin(alfa)) * tiempo3) - (g * (Mathf.Pow(tiempo3, 2))) + potencia;
            q2y = (v0 * (Mathf.Sin(alfa)) * (tiempo3 + (0.5f * delta))) - (g * (Mathf.Pow((tiempo3 + (0.5f * delta)), 2)) + potencia);
            q3y = q2y;
            q4y = (v0 * (Mathf.Sin(alfa)) * (tiempo3 + delta)) - (g * (Mathf.Pow(tiempo3 + delta, 2)) ) + potencia;
            y13 = y03 + (q1y / 6) + (q2y / 3) + (q3y / 3) + (q4y / 6) + potencia;
            y03 = y13;
            posicion3.y = y13;

            q1x = (v0 * Mathf.Cos(alfa) * tiempo3) + potencia;
            q2x = (v0 * Mathf.Cos(alfa) * (tiempo3+0.5f*delta)) + potencia;
            q3x = q2x;
            q2x = (v0 * Mathf.Cos(alfa) * (tiempo3+delta)) + potencia;
            x13 = x03 + (q1x / 6) + (q2x / 3) + (q3x / 3) + (q4x / 6) + potencia;
            x03 = x13;
            posicion3.x = x13;
        }
        else
        {

        }
        bola3.gameObject.GetComponent<Transform>().position = posicion3;
    }
}
