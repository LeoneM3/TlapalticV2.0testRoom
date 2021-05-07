using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    private ControladorE enemigo;

    void Awake()
    {
        //debe encontrar el tipo de objeto Controladorjugador para almacenar la conexion con el codigo principal del jugador
        enemigo = FindObjectOfType<ControladorE>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemigo")) //si se coliciona con el jugador llama al metodo
        {
            enemigo.DetectorDaño(1);
        }
    }
}
