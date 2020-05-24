using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    //usar arreglos mejor :)
    public GameObject[] masas;
    public GameObject[] paredes;
    public float[] angulos,vs;
    public float e;
    float[] vx1, vy1;
    float masa = 1;
    bool[,] control;
    bool[,] cpared;
    
    Vector3 p1, p2;

    float angulo(float ang)
    {
        float radianes = ang * Mathf.PI / 180;
        return radianes;
    }


    // Start is called before the first frame update
    void Start()
    {
        vx1 = new float[masas.Length];
        vy1 = new float[masas.Length];

        control = new bool[masas.Length,masas.Length];
        cpared = new bool[masas.Length,4];

        
        for (int i = 0; i < masas.Length; i++)
        {
            vx1[i] = vs[i] * Mathf.Cos(angulo(angulos[i]));
            vy1[i] = vs[i] * Mathf.Sin(angulo(angulos[i]));
            for (int f = 0; f < masas.Length; f++)
            {
                control[i,f] = true;
            }
            cpared[i,0] = true;
            cpared[i,1] = true;
            cpared[i,2] = true;
            cpared[i,3] = true;
        }
    }



    //void cambio_pared(float ang,int nmasa)
    //{
    //    //vx,vy 1
    //    float vx = vx1[nmasa], vy = vy1[nmasa], vp1, vn1, v1pp;
    //    vp1 = vx * Mathf.Cos(angulo(ang)) + vy * Mathf.Sin(angulo(ang));
    //    vn1 = -vx * Mathf.Sin(angulo(ang)) + vy * Mathf.Cos(angulo(ang));
    //    v1pp = 0;
        
    //    //caso 1
    //    vy = Mathf.Cos(angulo(ang)) * v1pp - Mathf.Sin(angulo(ang)) * vn1;
    //    vx = Mathf.Sin(angulo(ang)) * v1pp + Mathf.Cos(angulo(ang)) * vn1;
    //    angulos[nmasa] = Mathf.Atan(vy / vx) * 180 / Mathf.PI;
        

    //    vx1[nmasa] = vx;
    //    vy1[nmasa] = vy;

    //}

    void cambio_pared(float ang, int nmasa, int caso)
    {
      switch(caso)
        {
            //izq
            case 0:
                vx1[nmasa] = -vx1[nmasa];
                break;

            //der
            case 1:
                vx1[nmasa] = -vx1[nmasa];
                break;

            //arr
            case 2:
                vy1[nmasa] = -vy1[nmasa];
                break;

            //aba
            case 3:
                vy1[nmasa] = -vy1[nmasa];
                break;
        }


    }



    void velocidad(int nmasa)
    {
        p1 = masas[nmasa].gameObject.GetComponent<Transform>().position;
        p1 += new Vector3(vx1[nmasa], vy1[nmasa], 0)*0.1f;
        
               
        masas[nmasa].gameObject.GetComponent<Transform>().position = p1;

    }

    void cambio(float ang,int masa1,int masa2)
    {

        //vx,vy 1
        float vx = vx1[masa1], vy = vy1[masa1],vp1,vn1,vp2,vn2,v1pp,v2pp;
        vp1 =  vx * Mathf.Cos(angulo(ang)) + vy * Mathf.Sin(angulo(ang));
        vn1 = -vx * Mathf.Sin(angulo(ang)) + vy * Mathf.Cos(angulo(ang));

        //vx,vy 2
        vx = vx1[masa2];
        vy = vx1[masa2];

        vp2 = vx * Mathf.Cos(angulo(ang)) + vy * Mathf.Sin(angulo(ang));
        vn2 = -vx * Mathf.Sin(angulo(ang)) + vy * Mathf.Cos(angulo(ang));

        //calculo vp's
        v1pp = vp1 * (masa - e * masa) / (masa+ masa) + vp2 * ((1 + e) * masa) / (masa + masa);
        v2pp = vp2 * (masa - e * masa) / (masa + masa) + vp1 * ((1 + e) * masa) / (masa + masa);

        //caso 1

        vx = Mathf.Cos(angulo(ang)) * v1pp - Mathf.Sin(angulo(ang)) * vn1;
        vy = Mathf.Sin(angulo(ang)) * v1pp + Mathf.Cos(angulo(ang)) * vn1;

        angulos[masa1] = Mathf.Atan(vy / vx) * 180 / Mathf.PI;


        //saber que objeto es para vectores un contador
        
        vx1[masa1] = vx;
        vy1[masa1] = vy;
        

        //caso 2

        vx = Mathf.Cos(angulo(ang)) * v2pp - Mathf.Sin(angulo(ang)) * vn2;
        vy = Mathf.Sin(angulo(ang)) * v2pp + Mathf.Cos(angulo(ang)) * vn2;

        angulos[masa2] = Mathf.Atan(vy / vx)*180/Mathf.PI;


        //saber que objeto es
        vx1[masa2] = vx;
        vy1[masa2] = vy;



    }

    void pared(int nmasa)
    {
        float a;
        //Izquierda        
        a = Mathf.Abs(masas[nmasa].gameObject.GetComponent<Transform>().position.x - paredes[0].gameObject.GetComponent<Transform>().position.x);
        if (a <= 1 && cpared[nmasa, 0]) 
        {
                
            cpared[nmasa,0] = false;
            cpared[nmasa, 1] = true;
            cpared[nmasa, 2] = true;
            cpared[nmasa, 3] = true;

            for (int x = 0; x < masas.Length; x++)
            {
                if (x != nmasa)
                {
                    control[nmasa, x] = true;
                }
            }
            angulos[nmasa] = Mathf.Atan(vy1[nmasa] / vx1[nmasa]) * 180 / Mathf.PI;

            cambio_pared(Mathf.Abs(angulos[nmasa]-180), nmasa,0);

        }
        //Derecha
        a = Mathf.Abs(masas[nmasa].gameObject.GetComponent<Transform>().position.x - paredes[1].gameObject.GetComponent<Transform>().position.x);
        if (a <= 1 && cpared[nmasa, 1])
        {
            cpared[nmasa, 1] = false;
            cpared[nmasa, 0] = true;
            cpared[nmasa, 2] = true;
            cpared[nmasa, 3] = true;

            for (int x = 0; x < masas.Length; x++)
            {
                if (x != nmasa)
                {
                    control[nmasa, x] = true;
                }
            }
            angulos[nmasa] = Mathf.Atan(vx1[nmasa] / vy1[nmasa]) * 180 / Mathf.PI;

            Debug.Log(angulos[nmasa]);


            cambio_pared(Mathf.Abs(angulos[nmasa])-180, nmasa,1);

        }
        //Arriba
        a = Mathf.Abs(masas[nmasa].gameObject.GetComponent<Transform>().position.y - paredes[2].gameObject.GetComponent<Transform>().position.y);
        if (a <= 1 && cpared[nmasa, 2])
        {
            cpared[nmasa, 2] = false;
            cpared[nmasa, 1] = true;
            cpared[nmasa, 0] = true;
            cpared[nmasa, 3] = true;

            for (int x = 0; x < masas.Length; x++)
            {
                if (x != nmasa)
                {
                    control[nmasa, x] = true;
                }
            }
            angulos[nmasa] = Mathf.Atan(vy1[nmasa] / vx1[nmasa])*180/Mathf.PI;

            Debug.Log(angulos[nmasa]);
            cambio_pared(Mathf.Abs(angulos[nmasa]), nmasa,2);

            
        }
        //Abajo
        a = Mathf.Abs(masas[nmasa].gameObject.GetComponent<Transform>().position.y - paredes[3].gameObject.GetComponent<Transform>().position.y);
        if (a <= 1 && cpared[nmasa, 3])
        {
            cpared[nmasa, 3] = true;
            cpared[nmasa, 1] = true;
            cpared[nmasa, 2] = true;
            cpared[nmasa, 0] = true;

            for (int x = 0; x < masas.Length; x++)
            {
                if (x != nmasa)
                {
                    control[nmasa, x] = true;
                }
            }
            angulos[nmasa] = Mathf.Atan(vy1[nmasa] / vx1[nmasa]) * 180 / Mathf.PI;

            cambio_pared(Mathf.Abs(angulos[nmasa]-90), nmasa,3);

        }



    }

    void distancia(int nmasa)
    {
        Vector3 a;
        for (int i = 0; i < masas.Length; i++)
        {
            if (i != nmasa && control[nmasa,i])
            {
                a = (masas[nmasa].gameObject.GetComponent<Transform>().position - masas[i].gameObject.GetComponent<Transform>().position);
                                             
                if (a.magnitude <= 1)
                {
                    float ang = Mathf.Atan(a.y / a.x) * 180 / Mathf.PI;
                    control[nmasa,i] = false;
                    
                    //reset controles
                    for(int x=0;x<masas.Length;x++)
                    {
                        if (x != i)
                        {
                            control[nmasa,x] = true;
                        }
                    }
                    cpared[nmasa, 3] = true;
                    cpared[nmasa, 1] = true;
                    cpared[nmasa, 2] = true;
                    cpared[nmasa, 0] = true;


                    cambio(ang, nmasa,i);
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        

        for (int i = 0; i < masas.Length; i++)
        {
            pared(i);

            distancia(i);


                

            velocidad(i);


        }

    }
}
