using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class Tracer{
    private const string directoryName = "./Trace/";
    private const string fileName = "";
    private const string extension = ".txt";

    public const string Delimiter = ",";

    private List<string> memory = new List<string>();
    private StreamWriter writer = null;

    public Tracer() {
    }

    ~Tracer() {
        if(!Directory.Exists(directoryName)) {
            Directory.CreateDirectory(directoryName);
        }
        using(StreamWriter writer = new StreamWriter(directoryName + getDateString() + fileName + extension)) {
            foreach(string str in memory) {
                writer.Write(str);
            }
        }
    }

    public static string GetLog(params object[] args) {
        string log = "";
        foreach(object arg in args) {
            log += arg + Delimiter;
        }
        return log.Substring(0, log.Length - 1);
    }

    public static string GetLogRaw(params object[] args) {
        string log = "";
        foreach(object arg in args) {
            log += arg;
        }
        return log;
    }

    public void Trace(params object[] args) {
        string log = GetLog(args);
        memory.Add(log + Environment.NewLine);
        Debug.Log(log);
    }

    public void TraceLine(params object[] args) {
        foreach(object arg in args) {
            memory.Add(arg.ToString() + Environment.NewLine);
            Debug.Log(arg.ToString());
        }
    }

    public void TraceRaw(params object[] args) {
        string log = GetLogRaw(args);
        memory.Add(log);
        Debug.Log(log);
    }

    public void NewLine() {
        memory.Add(Environment.NewLine);
    }

    public static void Print(params object[] args) {
        Debug.Log(GetLog(args));
    }

    public static void PrintLine(params object[] args) {
        foreach(object arg in args) {
            Debug.Log(arg.ToString());
        }
    }

    public static void PrintRaw(params object[] args) {
        Debug.Log(GetLogRaw(args));
    }

    private string getDateString() {
        DateTime date = DateTime.Now;
        return date.Year.ToString() + date.Month.ToString("00") + date.Day.ToString("00") + date.Hour.ToString("00") + date.Minute.ToString("00") + date.Second.ToString("00");
    }
}
