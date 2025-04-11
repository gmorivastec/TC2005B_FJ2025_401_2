using System;
using System.IO;
using UnityEngine;

public class SaveExample : MonoBehaviour
{

    // Serialización
    // proceso para transformar un objeto en un string
    [Serializable]
    public class Alumno
    {
        public string nombre;
        public int edad;
    }


    [SerializeField]
    private Alumno _alumnoPrueba;

    [SerializeField]
    private Alumno[] _alumnos;

    private string _json;
    private Alumno _objeto;

    private string SAVE_PATH;

    // 2 ways to save data into your hard drive
    // 1. player prefs (this actually saves a file also)
    // 2. actually saving a file into the file system

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SAVE_PATH = Application.persistentDataPath + "/savefile.save"; 
        print(SAVE_PATH);
    }

    // Update is called once per frame
    void Update()
    {

        // player prefs (preferences)
        // - a simple way to save simple data
        // - atomic info only

        if(Input.GetKeyDown(KeyCode.Q))
        {
            // save value into playerprefs at runtime
            PlayerPrefs.SetString("example1", "HEY GUYS!");

            // actually save file
            // IO operation
            PlayerPrefs.Save();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            print(PlayerPrefs.GetString("example1", "NO VALUE ON THAT KEY"));

            if(PlayerPrefs.HasKey("example1"))
                print("KEY EXISTS! :)");
            else
                print("KEY DOESN'T EXIST! :(");

        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            print("REMOVING KEY");
            PlayerPrefs.DeleteKey("example1");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            print("REMOVING EVERYTHING");
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            // parsers
            // interprete / traductor de texto
            _json = JsonUtility.ToJson(_alumnoPrueba);
            print(_json);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            _objeto = JsonUtility.FromJson<Alumno>(_json);
            print("alumno: " + _objeto.nombre + " " + _objeto.edad);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            print("GUARDANDO...");
            File.WriteAllText(SAVE_PATH, _json);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(File.Exists(SAVE_PATH))
            {
                string loadedString = File.ReadAllText(SAVE_PATH);
                print("ARCHIVO CARGADO");
                print(loadedString);
            }
        }
    }
}
