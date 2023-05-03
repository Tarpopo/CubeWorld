using System.Collections.Generic;
using System.IO;
// using Constants;
using UnityEditor;

#if UNITY_EDITOR
public static class EnumGenerator
{
    // public static void GenerateEnum(IEnumerable<string> enumEntries, string enumName)
    // {
    //     var filePathAndName = PathConstants.GeneratedEnumsPath + enumName + ".cs";
    //     using (var streamWriter = new StreamWriter(filePathAndName))
    //     {
    //         streamWriter.WriteLine("public enum " + enumName);
    //         streamWriter.WriteLine("{");
    //         foreach (var enumItem in enumEntries) streamWriter.WriteLine("\t" + enumItem + ",");
    //         streamWriter.WriteLine("}");
    //     }
    //
    //     AssetDatabase.Refresh();
    // }

    public static void GenerateEnum(IEnumerable<string> enumEntries, string enumName, string enumPath)
    {
        var filePathAndName = enumPath + enumName + ".cs";
        using (var streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            foreach (var enumItem in enumEntries) streamWriter.WriteLine("\t" + enumItem + ",");
            streamWriter.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }
}
#endif