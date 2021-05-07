using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladorj : MonoBehaviour
{
    //VARIABLES PARA CAMINAR 
    public float velocidadJugador; //velocidad del personaje
    public float rotacionJugador;  //velocidad de rotacion del personaje
    public bool movimientoJugador = false; //movimiento del jugador
    private Rigidbody rb;
    private Vector3 desplazamiento;

    //VARIABLES PARA SALTAR
    public float velocidadSaltdo;  //velocidad del salto
    public bool tocando = true; //se esta tocando algo si o no 
    public Transform disparaR; //disparador del rayo

    //VARIABLES PARA ATACAR
    public Transform puntoAtaque;
    public float rangoAtaque;
    public LayerMask enemyLayers; //guarda las capas de las escenas donde esten enemigos

    private ControladorE enemigo;

    void Awake()
    {
        enemigo = FindObjectOfType<ControladorE>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        // se inicializa una variable e indicamos que le daremos valor con nuestro teclado
        float mh = Input.GetAxis("Horizontal");

        //llamamos nuestro metodo
        MovimientoJugador(mh);
        SaltoJugador();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MovimientoJugador(float mh)
    {
        desplazamiento.Set(mh, 0f, 0f);
        desplazamiento = desplazamiento.normalized * velocidadJugador * Time.deltaTime;
        rb.MovePosition(transform.position + desplazamiento);

        //validar caundo el movimiento horizontal sea diferente de 0 llame al metodo RotacionJugador
        if (mh != 0f)
        {
            RotacionJugador(mh);
        }

        //variable bool indicando que su valor es lo mismo que si movimiento es diferente de 0
        bool jugadorCorriendo = mh != 0f;

        //validamos el movimiento del jugador
        if (jugadorCorriendo)
        {
            movimientoJugador = true;
        }
        else
        {
            movimientoJugador = false;
        }
    }

    void RotacionJugador(float mh)
    {
        float interpolacion = rotacionJugador * Time.deltaTime;
        Vector3 targetDireccion = new Vector3(mh, 0f, 0f);
        Quaternion targetRotacion = Quaternion.LookRotation(targetDireccion, Vector3.right);
        Quaternion newRotacion = Quaternion.Lerp(rb.rotation, targetRotacion, interpolacion);
        rb.MoveRotation(newRotacion);

    }

    //crear metodo para saltar
    //utilizando raycast se entiende como un razo para fijar la direccion de algo en este caso validar si se esta tocando suelo 
    void SaltoJugador()
    {
        //variable direccion del rayo (a que direccion tienw que dirigir la variable) down para saber que el rayo va hacia abajo del object
        Vector3 direcRayo = transform.TransformDirection(Vector3.down);
        //variable para evaluar contra que esta chocando el rayo
        RaycastHit hit;

        if (Input.GetButton("Jump") && tocando)//validar si se esta tocando la barra espaciadora y si se esta tocando algo
        {
            rb.velocity = new Vector3(0f, velocidadSaltdo, 0f); //para que salte se usa la funcion velocity , se le asigna vector3 (en el eje y con una velocidad , )
            tocando = false; //decimos que no estas tocando nada
        }
        //se evalua en que momento el personaje toca el suelo y cuando no 
        //accedemos al rayo, tenemos que saber desde donde va salir(disparador, desde la posicion del gameobject, hacia donde, a que distancia tiene que tocar ) y verificar si coliciona
        if (Physics.Raycast(disparaR.position, direcRayo, out hit, 0.2f) && hit.collider.CompareTag("Suelo"))
        {
            tocando = true;
        }
        else
        {
            tocando = false;
        }
    }

    public void AtaqueJugador()
    {
        //nos valemos de la funcion OverlapSphere , recoge dentro de la escena apartir de un punto en especifico y dentro de un rango, la informcion de los collider con los que se interactua y se guarda en un arreglo
        Collider[] hitColliders = Physics.OverlapSphere(puntoAtaque.position, rangoAtaque, enemyLayers); //(punto de origen, rango, )

        //indicamos que cada collider que encuentre lo coloque en hitEnemy 
        foreach (Collider hitEnemy in hitColliders)
        {
            print("Atacaste a :" + hitEnemy.name);
            if (hitEnemy.name =="Enemigo")
            {
                enemigo.DetectorDaño(1);
            }
        }
    }
}
