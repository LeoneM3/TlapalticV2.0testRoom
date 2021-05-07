using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorE : MonoBehaviour
{
    public Transform objetivo; //fijar objetivo de ataque
    public bool movEnemigo; //cuando se movera y cuando no
    public NavMeshAgent navEnemy;  //hacer uso de instrucciones para mover

    public LayerMask enemyLayers;
    public Transform puntoAtaque;
    public float rangoAtaque;
    public int vida= 5;

    private string cosa;
    
    void Awake()
    {
        navEnemy = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //metodos que da Unity 

    void OnTriggerStay(Collider other)//detecta cuando el jugador este dentro del collider y hara que el enemigo lo persiga
    {
        if (other.CompareTag("Jugador"))//validar si el jugador esta dentro del collider
        {
            navEnemy.destination = objetivo.position; //dirigimos al enemigo hacia nosotros
            navEnemy.isStopped = false; //nuestro enemigo no se detenga si el jugador se mueve pero esta en el rango 
            movEnemigo = true; //se mueve y activar animacion...
        }
    }

    void OnTriggerExit(Collider other)//detecta cuando el jugador este fuera del collider y hara que el enemigo no lo persiga
    {
        if (other.CompareTag("Jugador"))//validar si el jugador esta fuera del collider
        {
            navEnemy.isStopped = true; //nuestro enemigo se detenga 
            movEnemigo = false; //no se mueve y activar animacion...
        }
    }

   public void DetectorDaño(int golpe)
    {
        print("Daño recivido");

        vida = vida - golpe;
        

        if(vida == 0)
        {
            print("Me moriii");
        }
        
    }



}
