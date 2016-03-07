using UnityEngine;
using System.Collections;

public class Tracer {
    public const string Delimiter = ",";

    public static void Print(params object[] args) {
        string str = "";
        foreach(object arg in args) {
            str+=arg+Delimiter;
        }
        UnityEngine.Debug.Log(str.Substring(0, str.Length-1));
    }

    public static void PrintLine(params object[] args) {
        foreach(object arg in args) {
            UnityEngine.Debug.Log(arg.ToString());
        }
    }

    public static void PrintRaw(params object[] args) {
        string str = "";
        foreach(object arg in args) {
            str+=arg;
        }
        UnityEngine.Debug.Log(str);
    }
}
