using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyTest.Utilities
{
    class Log2Txt
    {
        public static void PrintLine()
        {
            using (FileStream fs = new FileStream(@"d:\Debugg.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(Environment.NewLine
                    + "---------------------------------------------------------------------"
                    + Environment.NewLine);
            }
        }

        public static void PrintResultToFile(String TestDesc, String Expected, String Actual)
        {
            using (FileStream fs = new FileStream(@"d:\Debugg.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(TestDesc + Expected + Actual);

            }
        }
        //Print the test results into a .TXT file(V.2)
        public static void PrintToFileV2(String InputString)
        {
            using (FileStream fs = new FileStream(@"d:\Debugg.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(InputString);
            }
        }
        //Open the file when the execution ended
        public static void OpenFile()
        {
            System.Diagnostics.Process.Start(@"d:\Debugg.txt");
        }
        //Print the Execution Start/End time
        public static void Start_And_End_of_the_Execution(int StartOrEnd)
        {
            switch (StartOrEnd)
            {
                //The START time of the test execution
                case 0:
                    PrintToFileV2("---------------------------------------------------------------------");
                    PrintToFileV2("Test Execution is started |  Start Time : " + DateTime.Now.ToString());
                    PrintToFileV2("---------------------------------------------------------------------");
                    break;
                //The END time of the test execution
                case 1:
                    PrintToFileV2("Test Execution is Ended     |  End Time" + DateTime.Now.ToString());
                    PrintToFileV2("---------------------------------------------------------------------");
                    break;
                default:
                    break;
            }
        }
    }
}
