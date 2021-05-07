using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesE : MonoBehaviour
{
    //creo instancian de la clase controlador
    private ControladorE enemigo;

    //variable tipo animator
    private Animator animEnemigo;

    void Awake()
    {
        //debe encontrar el tipo de objeto Controladorjugador para almacenar la conexion con el codigo principal del enemigo
        enemigo = FindObjectOfType<ControladorE>();

        //aceder al componente animator atravez del get component
        animEnemigo = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AnimacionCorrer();
        AnimacionMorir();
    }

    void AnimacionCorrer()
    {
        //validamos los estados de la variables para activar las animaciones
        if (enemigo.movEnemigo)
        {
            animEnemigo.SetBool("Correr", true);
        }
        else
        {
            animEnemigo.SetBool("Correr", false);
        }
    }

    void AnimacionMorir()
    {

        if (enemigo.vida <= 0)
        {
            animEnemigo.SetBool("Morir", true);

        }

    }
}
