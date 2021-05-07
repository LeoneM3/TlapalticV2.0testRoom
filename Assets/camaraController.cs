using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Custom/Camara/Camara 2D")]
public class camaraController : MonoBehaviour
{

    public Transform ObjetivoCamara;
    public float distancia = 0.0f;
    public float altura = 0.0f;
    public float velocidadDesplazamiento = 1.0f;


    private float positionCamaraX = 0.0f;
    private float posicionPersonajeX = 0.0f;
    private Transform refTransform;




    void Start()
    {

            refTransform = this.GetComponent<Transform>();

            refTransform.position = new Vector3(ObjetivoCamara.position.x, altura, distancia);
            positionCamaraX = ObjetivoCamara.position.x;





    }

    void LateUpdate()
    {
        posicionPersonajeX = ObjetivoCamara.position.x;

        positionCamaraX = Mathf.Lerp(positionCamaraX, posicionPersonajeX, velocidadDesplazamiento * Time.deltaTime);
        
        refTransform.position = new Vector3 (positionCamaraX, altura, distancia);
    }
}
