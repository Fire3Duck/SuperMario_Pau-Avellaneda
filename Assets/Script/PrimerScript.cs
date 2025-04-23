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

    private int[] numeros = {75, 1, 3};
    
    public int[] numeros2;

    private int[,] numeros3 = {{7, 8, 98},{9, 22, 45},{74, 5, 6}}; //Cada parte azul de aqui es un acolumna y se empieza con el 0, siendo la columna 1.

    List<int> listaDeNumeros = new List<int> {3, 5, 8, 9, 88, 12};


    // Start is called before the first frame update
    void Start()
    {
        foreach(int numero in listaDeNumeros)
        {
            Debug.Log(numero);
        }

        listaDeNumeros.Add(22); //para añadir un numero mas en la lista al final.
        listaDeNumeros.Remove(5); //me elimina el numero marcado.
        listaDeNumeros.RemoveAt(0); //me elimina el numero de la posicion (Ejemplo: 0 quita el primer numero.)
        listaDeNumeros.RemoveAt(listaDeNumeros.Count - 1); //para eliminar el ultimo de la lista.
        //listaDeNumeros.Clear(); //Te borra la lista para que puedas hacer otra.
        listaDeNumeros.Sort();
        listaDeNumeros.Reverse();


        //Debug.Log(numeros[0]);
        //Debug.Log(numeros3[1,2]);

        //Calculos();

        /*foreach(int numero in numeros) //Variable temporal, almazena informacion.
        {
            Debug.Log(numero);
        }*/

        /*for(int i = 0; i < numeros.Length; i++)
        {
            Debug.Log(numeros[i]);
        }*/

        /*int i = 0;
        while(i < numeros.Length)
        {
            Debug.Log(numeros[i]);
            i++;
        }*/

        /*int i = 75;
        do 
        {
            Debug.Log("asfafs");
        }
        while (i < numeros.Length);*/
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
