using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class part : MonoBehaviour
{
    public int i;
    public GameObject bola;
    Vector3 posicion;


    private float tiempo;
    private float tiempo0;
    float gravedad = 9.8f;
    public float masa;
    float vel0 = 0;
    public Text cantidad;
    string cantidads;
    int cantidadi;
    public Text letrero;

    public void iniciar(){
        cantidads = cantidad.text;
        if(cantidads == ""){
          letrero.text = "Por favor ingrese la cantidad de instancias que desea.";
        }
        else{
        int.TryParse(cantidads, out cantidadi);
                for (int n = 0; n < cantidadi; n++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 10, Random.Range(-10.0f, 10.0f));
            Instantiate(bola, position, Quaternion.identity);
     
        }
        letrero.text = "";
        }
    }

    // Use this for initialization
    void Start()
    {



        tiempo0 = Time.time;
        tiempo = Time.time;
        }
        // Update is called once per frame
        void Update()
        {
            posicion = bola.gameObject.GetComponent<Transform>().position;

            if (posicion.y >= 1)
            {
                tiempo = Time.time;
                float h = gravedad * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
                //ACCEDER A LA TRANSFORMADA DEL OBJETO
                float fuerza = masa * gravedad;


                posicion.z += h;
                bola.gameObject.GetComponent<Transform>().position = posicion;
            }
            else
            {
                posicion.y = 0;
                bola.gameObject.GetComponent<Transform>().position = posicion;

            }



        }
}