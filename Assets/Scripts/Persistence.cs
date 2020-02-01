using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence {

    public static void Save<T>(T data, string filename) {
        string json = JsonUtility.ToJson(data);
        Debug.Log($"Save data {json}");

        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + filename;
        Debug.Log($"Saving in {path}");

        File.WriteAllText(path, json);
    }

    public static T Load<T>(string filename) {
        T data = default(T);
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + filename;
        Debug.Log($"Loading from {path}");
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            Debug.Log($"Load data {json}");

            data = JsonUtility.FromJson<T>(json);
        }


        return data;
    }
}