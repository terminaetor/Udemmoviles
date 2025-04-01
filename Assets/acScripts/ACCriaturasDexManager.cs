using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ACCriaturasDexManager : MonoBehaviour
{
    private string filePath;
    public ACListCriaturas acListCriaturas;

    void Start()
    {
        filePath = Application.persistentDataPath + "/Dex.json";//Determina direccion en donde se guarda el json que tiene los datos guardados
        CargarDex();
    }

    public void CargarDex()
    {
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);//si existe el archivo se lee la informacion
            acListCriaturas = JsonUtility.FromJson<ACListCriaturas>(json);//Recoger info json
        }
        else
        {
            acListCriaturas = new ACListCriaturas();
            GuardarDex();
        }
    }

    public void GuardarDex()
    {
        string json = JsonUtility.ToJson(acListCriaturas, true);//Convertir informacion a json
        File.WriteAllText(filePath, json);//Funcion que guarda el json
    }

}
