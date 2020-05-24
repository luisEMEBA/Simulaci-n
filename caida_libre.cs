using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Código hecho por Luis Enrique Melo Barrera, se autoriza la libre distribución, modificación y estudio del mismo para fines académicos
//todo esto bajo el marco del software libre. GPL. 

public class caida_libre : MonoBehaviour {
	int inicio;
	public GameObject esfera_mercurio;
	public GameObject esfera_urano;
	public GameObject esfera_jupiter;
	public GameObject esfera_marte;
	public GameObject esfera_luna;
	public GameObject esfera_tierra;
    private float tiempo;
    private float tiempo0;
    float gravedad1=9.98f;
	float gravedad2=1.6f;
	float gravedad3=3.8f;
	float gravedad4=3.6f;
	float gravedad5=26f;
	float gravedad6=9.4f;
	float h1;
	float h2;
	float h3;
	float h4;
	float h5;
	float h6;
	float divisor=30f;
    Vector3 posicion1;
	Vector3 posicion2;
	Vector3 posicion3;
	Vector3 posicion4;
	Vector3 posicion5;
	Vector3 posicion6;
	void Start () {
      inicio = 0;
	  tiempo0 = Time.time;
      tiempo = Time.time;
	}
	
	public void iniciar(){
      inicio = 1; 
            esfera_tierra.gameObject.GetComponent<Transform>().position = new Vector3( -27.6f, 36.1f, -1.7f );
			esfera_luna.gameObject.GetComponent<Transform>().position = new Vector3( 9.1f, 36.1f, -1.7f );
			esfera_marte.gameObject.GetComponent<Transform>().position = new Vector3( 34.4f, 36.1f, -1.7f );
			esfera_mercurio.gameObject.GetComponent<Transform>().position = new Vector3( -3.4f, 36.1f, -1.7f );
			esfera_jupiter.gameObject.GetComponent<Transform>().position = new Vector3( 21.1f, 36.1f, -1.7f );
			esfera_urano.gameObject.GetComponent<Transform>().position = new Vector3( -16.1f, 36.1f, -1.7f );
	}
	public void lento(){

           gravedad1=gravedad1/divisor;
		   gravedad2=gravedad2/divisor;
		   gravedad3=gravedad3/divisor;
		   gravedad4=gravedad4/divisor;
		   gravedad5=gravedad5/divisor;
		   gravedad6=gravedad6/divisor;
		 
	}	
	
	void Update () {

     posicion2 = esfera_luna.gameObject.GetComponent<Transform>().position;
	 posicion1 = esfera_tierra.gameObject.GetComponent<Transform>().position;
	 posicion3 = esfera_marte.gameObject.GetComponent<Transform>().position;
 	 posicion4 = esfera_mercurio.gameObject.GetComponent<Transform>().position;
	 posicion5 = esfera_jupiter.gameObject.GetComponent<Transform>().position;
	 posicion6 = esfera_urano.gameObject.GetComponent<Transform>().position;

	 if(inicio == 1){
        
            tiempo = Time.time;
            float h1 = gravedad1 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
			float h2 = gravedad2 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
			float h3 = gravedad3 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
			float h4 = gravedad4 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
			float h5 = gravedad5 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;
			float h6 = gravedad6 * Mathf.Pow(tiempo - tiempo0, 2) * 0.5f;   
            if(posicion1.y>=2){
			posicion1.y -= h1;
			}else{posicion1.y = 0;
			}
            if(posicion2.y>=2){
			posicion2.y -= h2;
			}else{posicion2.y = 0;
			}
			
			
            if(posicion3.y>=2){
			posicion3.y -= h3;
			}else{posicion3.y = 0;
			}
			
            if(posicion4.y>=2){
			posicion4.y -= h4;
			}else{posicion4.y = 0;
			}
			
            if(posicion5.y>=2){
			posicion5.y -= h5;
			}else{posicion5.y = 0;
			}
            if(posicion6.y>=2){
			posicion6.y -= h6;
			}else{posicion6.y = 0;
			}

            esfera_tierra.gameObject.GetComponent<Transform>().position = posicion1;
			esfera_luna.gameObject.GetComponent<Transform>().position = posicion2;
			esfera_marte.gameObject.GetComponent<Transform>().position = posicion3;
			esfera_mercurio.gameObject.GetComponent<Transform>().position = posicion4;
			esfera_jupiter.gameObject.GetComponent<Transform>().position = posicion5;
			esfera_urano.gameObject.GetComponent<Transform>().position = posicion6;
		
	 }	
	}
}


