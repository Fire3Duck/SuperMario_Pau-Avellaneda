using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    //Variables
    public int numeroEntero = 5; //variables para numeros enteros
    private float numeroDecimal = 7.5f; //variable para numeros con decimales

    bool boleana = true; // variable verdadero o falso;
    string cadenatexto = "Hola, Mundo";



    // Start is called before the first frame update
    void Start()
    {
        Calculos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Calculos()
    {
    Debug.Log(numeroEntero);
        numeroEntero = 17;
        Debug.Log(numeroEntero);

        numeroEntero = 7 + 5;

        numeroEntero++; //Esto hace que se sume de uno en uno

        numeroEntero += 2; //Esto hace que se sume de dos en dos (Si cambias el numero sumara dicho numero)
    }
}
