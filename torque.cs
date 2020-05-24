using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //PROPICIA EL USO DE CAMPOS DE TEXTO
public class torque : MonoBehaviour
{
    public Text data;
    public GameObject punto_torque;
    Vector3 posicion_punto_torque;
    Vector3 posicion_raton_inicial;
    Vector3 posicion_raton_final;
    float escala_barra_torque = 0;
    int direccion;
    float fuerza = 0;
    float torque_val = 0;
    float radio = 0;
    float escala = 0.1f;
    //empieza variables ensayo arrastre.
    private Camera cam;
    private GameObject go;
    public static string btnName;
    private Vector3 screenSpace;
    private Vector3 offset;
    private bool isDrage = false;
    int control = 0;
    Vector3 vector_control;
    int contador_prueba = 0;
    //finaliza variables ensayo arrastre.
    void Start()
    {
        //inicializamos cámara ensayo movimiento
        cam = Camera.main;
        //finaliza cámara ensayo movimiento
    }

    // Update is called once per frame
    void Update()
    {
        rayos();
    }
    void calculo_torque(){
        if(posicion_raton_inicial.y < posicion_raton_final.y){
                direccion = 1;
        }
        if(posicion_raton_inicial.y == posicion_raton_final.y){
                fuerza = 0;
        }
        if(posicion_raton_inicial.y > posicion_raton_final.y){
                direccion = -1;
        }
        fuerza = (Mathf.Abs(posicion_raton_final.y - posicion_raton_inicial.y)) * escala;
        radio = Mathf.Abs(punto_torque.gameObject.GetComponent<Transform>().position.x - posicion_raton_inicial.x) * escala;
        torque_val = ((direccion * fuerza) * radio) * escala;
        Debug.Log("El torque equivale a: " + torque_val + " Con un radio de: " + radio + " Y con una dirección de :" + direccion);
        string res = "El torque equivale a: " + torque_val + " Con un radio de: " + radio + " Y con una dirección de :" + direccion;
        data.text = res;      
    }
    void rayos(){
    //empieza arrastre
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (isDrage == false)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                //The scribed rays can only be seen in the scene view
                Debug.DrawLine(ray.origin, hitInfo.point);
                go = hitInfo.collider.gameObject;
                print(btnName);
                screenSpace = cam.WorldToScreenPoint(go.transform.position);
                offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                btnName = go.name;
            }
            else
            {
                btnName = null;
            }
            if (control == 2) //de haber alcanzado este punto implica que se agarró y soltó donde era permitido, por lo tanto se procede 
            {   //a calcular el torque pues ya se cuenta con una fuerza (saca a partir de componentes Y de inicio y final)
                //y se conoce desde un principio el punto de torque.
                calculo_torque();
                control = 0;
            }
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;
            if (btnName != null)
            {
                if (btnName == "Barra" && control == 0) //para cuando el botón del mouse se presiona sobre la barra
                {
                    posicion_raton_inicial = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
                    control = 1;
                    //Debug.Log("Se está señalando la barra, se hizo click. Y la posición es : " + posicion_raton_inicial);
                }
                if(btnName == "Punto_de_torque"){ //para cuando el botón del ratón se presiona sobre el punto de torque
                posicion_punto_torque = new Vector3(currentPosition.x,-0.03618544f, -1.46f);
                punto_torque.gameObject.GetComponent<Transform>().position = posicion_punto_torque;
                }
            }
            isDrage = true;
        }
        else
        {
            isDrage = false;//En el instante en que se suelta el botón del ratón se almacena la última posición del puntero 
            //para calcular la componente Y de la fuerza 
            if(control == 1){
            posicion_raton_final = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
            //Debug.Log("Se soltó. Y la posición es : " + posicion_raton_final + " Una incial de : " + posicion_raton_inicial);
            control = 2;
            }
        }
        //finaliza arrastre
    }
}
