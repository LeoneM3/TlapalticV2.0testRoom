using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesJ : MonoBehaviour
{
    //creo instancian de la clase controlador
    private Controladorj jugador;

    //variable tipo animator
    private Animator animjugador;

    //la misma funcion que Start pero se ejecuta mas rapido
    void Awake()
    {
        //debe encontrar el tipo de objeto Controladorjugador para almacenar la conexion con el codigo principal del jugador
        jugador = FindObjectOfType<Controladorj>();

        //aceder al componente animator atravez del get component
        animjugador = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        AnimacionCorrer();
        AnimacionSaltar();
        AnimacionAtacar();
        AnimacionBailaaar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //metodo para activar la animacion
    void AnimacionCorrer()
    {
        //validamos los estados de la variables para activar las animaciones
        if (jugador.movimientoJugador)
        {
            animjugador.SetBool("Correr", true);
        }
        else
        {
            animjugador.SetBool("Correr", false);
        }
    }

    void AnimacionSaltar()
    {
        //validamos los estados de la variables para activar las animaciones
        if (jugador.tocando == false)
        {
            animjugador.SetBool("Saltar", true);
            animjugador.SetBool("Correr", false);
        }
        else
        {
            animjugador.SetBool("Saltar", false);
        }
    }

    void AnimacionAtacar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animjugador.SetTrigger("Atacar");
            jugador.AtaqueJugador();
        }
    }

    void AnimacionBailaaar()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animjugador.SetTrigger("Bailar");

        }
    }
}
