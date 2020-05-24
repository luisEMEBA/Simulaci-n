using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mov : MonoBehaviour
{
	public Text data;
	public GameObject object1;
	public GameObject object2;
	public GameObject object3;
	public GameObject object4;
	
	public float m_planeta1;
	public float m_planeta;
	public float m_tierra;
	float r;
	float r2;
	float Dt = 0.1f;
	float F1 = 0;
	float n;
	Vector3 av;
	Vector3 av2;
	Vector3 av3;
	Vector3 v = Vector3.zero;
	Vector3 posicion;

	//¿QUÉ OTRAS VARIABLES NECESITA?
	void Start()
	{
		
		av = (new Vector3(object2.gameObject.GetComponent<Transform>().position.x - object1.gameObject.GetComponent<Transform>().position.x, 0, object2.gameObject.GetComponent<Transform>().position.z - object1.gameObject.GetComponent<Transform>().position.z));
		r = av.magnitude;
		

		
		

	}

	void Update()
	{
		planeta();
		planeta1();
		posicion = object1.gameObject.GetComponent<Transform>().position;
		posicion = posicion + (v * Dt);
		object1.gameObject.GetComponent<Transform>().position = posicion;
		v = v - (av * Dt);
		float x = v.normalized.magnitude;
		av = (Mathf.Pow(x, 2) * posicion) / r;
		av = av + av2 + av3;
		r = new Vector3(object2.gameObject.GetComponent<Transform>().position.x - object1.gameObject.GetComponent<Transform>().position.x, 0, object2.gameObject.GetComponent<Transform>().position.z - object1.gameObject.GetComponent<Transform>().position.z).magnitude;

		Debug.Log(posicion + " " + av + " " + av2 + " " + F1);



	}

	void planeta()
	{
		av2 = (new Vector3(object3.gameObject.GetComponent<Transform>().position.x - object1.gameObject.GetComponent<Transform>().position.x, 0, object3.gameObject.GetComponent<Transform>().position.z - object1.gameObject.GetComponent<Transform>().position.z));
		r2 = av2.magnitude;
		F1 = 0.00000067f * m_tierra * m_planeta / (r2 * r2);
		av2 = av2.normalized;
		av2 = av2 * F1/m_tierra;


	}

	void planeta1()
	{
		av3 = (new Vector3(object4.gameObject.GetComponent<Transform>().position.x - object1.gameObject.GetComponent<Transform>().position.x, 0, object4.gameObject.GetComponent<Transform>().position.z - object1.gameObject.GetComponent<Transform>().position.z));
		r2 = av3.magnitude;
		F1 = 0.00000067f * m_tierra * m_planeta1 / (r2 * r2);
		av3 = av3.normalized;
		av3 = av3 * F1/ m_tierra;


	}

}