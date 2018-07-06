using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public static class XMLManager {

    public static void Save<T>(T obj, string filelocation) {
        CreateXML(SerializeObject<T>(obj), filelocation);        //呼叫34行 
    }

    public static bool TryLoad<T>(string filelocation, out T ret) where T : class {  //嘗試讀檔
        if (File.Exists(filelocation)) {
            ret = DeserializeObject<T>(LoadXML(filelocation));
            return true;
        } else {
            ret = null;
            return false;
        }
    }
    public static T Load<T>(string filelocation) where T : class {
        if (File.Exists(filelocation)) {
            return DeserializeObject<T>(LoadXML(filelocation));
        } else {
            return null;
        }
    }

    private static string SerializeObject<T>(T pObject) {                           //轉成字串   
        string XmlizedString = null;          //T can be anything
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(T));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xs.Serialize(xmlTextWriter, pObject);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }
    private static T DeserializeObject<T>(string pXmlizedString) {
        XmlSerializer xs = new XmlSerializer(typeof(T));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        return (T)xs.Deserialize(memoryStream);
    }

    private static string UTF8ByteArrayToString(byte[] characters) {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    private static byte[] StringToUTF8ByteArray(string pXmlString) {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    private static void CreateXML(string data, string fileLocation) {       // 輸出檔案  資料寫入文件

        StreamWriter writer;
        FileInfo t = new FileInfo(fileLocation);
        if (!t.Exists) {
            writer = t.CreateText();
        } else {
            t.Delete();
            writer = t.CreateText();
        }
        writer.Write(data);
        writer.Close();

        /*  using (BinaryWriter writer = new BinaryWriter(File.Open(fileLocation, FileMode.Create))) {
              writer.Write(encode(data));
          }*/
    }

    private static string LoadXML(string fileLocation) {

        if (File.Exists(fileLocation)) {

            StreamReader r = File.OpenText(fileLocation);
            string _info = r.ReadToEnd();
            r.Close();

            return _info;
        }



        //  Debug.Log("file not found");
        /*  if (File.Exists(fileLocation)) {

            using (BinaryReader reader = new BinaryReader(File.Open(fileLocation, FileMode.Open))) {
                string _info = reader.ReadString();
                return decode(_info);
            }
        }*/
        return "";
    }
    public static string encode(String strData) {
        return strData;
        // return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(strData));
    }
    public static string decode(String strData) {
        return strData;
        //  return UTF8Encoding.UTF8.GetString(Convert.FromBase64String(strData));
    }
}
