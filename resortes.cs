using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resortes : MonoBehaviour
{
    public Text masaa;
    public Text uu;
    public Text kk;
    public Text xmax;
    public Text letrero;
    int ini = 0;
	public GameObject Runge_Kutta;
    float tiempoi;
    float tiempo;
    float vn1;
    float vn=0;
    float xn1;
    float xn = 4;
    float deltav=0.05f;
    float deltax=0.05f;
    string maxxs, masas, us, ks;
    float maxx;
    float masa;
    float u;
    float k;
	Vector3 posicion2;
	float k1, k2, k3, k4, vr=0,  vr1, xr=4, xr1;

    //¿QUÉ OTRAS VARIABLES NECESITA?
    void Start()
    {
        tiempoi = Time.time;
    }

    public void iniciar(){
        us = uu.text;
        ks = kk.text;
        maxxs = xmax.text;
        masas = masaa.text;
        if(masas == "" ||maxxs == "" ||us == "" ||ks == ""){
        letrero.text ="Por favor ingrese primero los datos necesarios.";
        }
        else{
        float.TryParse(us, out u);
        float.TryParse(ks,out k);
        float.TryParse(masas,out masa);
        float.TryParse(maxxs,out maxx);    
        ini = 1;
        Runge_Kutta.gameObject.GetComponent<Transform>().position = new Vector3(4.02f, 3.43f, -3.92f);
        letrero.text ="";
        }
    }

    void Update()
    {  

        if(ini != 0){
		posicion2 = Runge_Kutta.gameObject.GetComponent<Transform>().position;
        tiempo = tiempoi - Time.time;
        //ACCEDER A LA TRANSFORMADA DEL OBJETO
        tiempo = Mathf.Pow(tiempo, 2);

		//empieza RUNGE - KUTTA
		if(xr <= maxx){
        k1 = ((((-1 * u) * vr) - (k * xr)) / masa) * deltax;
		k2 = ((((-1 * u) * (vr+(k1/2))) - (k * (xr+(deltax/2)))) / masa) * deltax; 
		k3 = ((((-1 * u) * (vr+(k2/2))) - (k * (xr+(deltax/2)))) / masa) * deltax; 
        k4 = ((((-1 * u) * (vr+(k3))) - (k * (xr+(deltax)))) / masa) * deltax; 
        vr1 = vr + (k1/6) + (k2/3) + (k3/3) +(k4/6);
		vr = vr1;
		xr1 = xn + (vr*deltav);
		xr = xr1;
		posicion2.x = xr1;
		}
		else{
           vr = vr*-1;
		}
		Runge_Kutta.gameObject.GetComponent<Transform>().position = posicion2;
    }
    }
}
