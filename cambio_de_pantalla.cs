using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambio_de_pantalla : MonoBehaviour {

    public void a_resortes(string nombredeescena)
    {

        SceneManager.LoadScene(1);
}
    public void a_particulas(string nombredeescena)
    {

        SceneManager.LoadScene(2);
}
    public void a_planetas(string nombredeescena)
    {

        SceneManager.LoadScene(3);
}
    public void a_caida(string nombredeescena)
    {

        SceneManager.LoadScene(0);
}
}