using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc
{
    class Program
    {
        private static string procc;
        public static List<string> cpus = new List<string>();
        public static List<string> usercpu = new List<string>();
        public static Char[] n;
        private static char[] convertedNumber;
         static   bool found = false;
        public static List<int> intList=new List<int>();

        static void Main(string[] args)
        {
         //  Process myProcess = Process.Start("NotePad.exe");
            
             found = FunctionforEnterNameofFile();
            Console.WriteLine($"your file is available  status {found} and the number of cpu's");
            //  Console.WriteLine("Enter the number of cpu's");
          usercpu= NumberofLogicalProcessors();



          intList=  FindSimilarityofbothList();

          
            

            convertedNumber = "0000000000000000".ToCharArray();
            //   int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            for (int j = 0; j < intList.Count; j++)
            {
                modifyBit(convertedNumber, intList[j] - 1);
            }

            string binary = new string(convertedNumber);

            string hex = BinaryStringToHexString(binary);


            //}
            FunctionFOrMapping(hex);
            
        }

        private static void FunctionFOrMapping(string hex)
        {
            Process[] processes = Process.GetProcessesByName(procc);
            long AffinityMask = (long)processes[0].ProcessorAffinity;
            long vOut = Convert.ToInt64(hex, 16);
          //  long vOut = Convert.ToInt64(hex);

            // use only any of the first 4 available processors
         //   processes[0].ProcessorAffinity = (System.IntPtr)AffinityMask;
           




          
            //int p = int.Parse(resu.ToString());
          
            //long vOut = (long)Convert.ToDouble(hex);

            // AffinityMask &= vOut;
            processes[0].ProcessorAffinity = (System.IntPtr)vOut;
            Console.Write(processes[0].ProcessorAffinity.ToString());
            Console.ReadLine();
            Console.ReadKey();
        }

        private static List<int> FindSimilarityofbothList()
        {
            Console.WriteLine("Similarity in the two lists...");
            var result = cpus.Union(usercpu).Where(w => (cpus.Contains(w) && usercpu.Contains(w))).ToList();
            intList = result.ConvertAll(int.Parse);
            return intList;
        }

        private static List<string> NumberofLogicalProcessors()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["NumberOfLogicalProcessors"].Value.ToString();
                //  break;
            }

            Console.WriteLine ("Total Number of CPUs " + strID);
            int a = Int16.Parse(strID);

            for (int i = 1; i <=a; i++)
            {
                cpus.Add(i.ToString());
                // MessageBox.Show("CPU" + i);

            }
            foreach (string color in cpus)
            {
               Console.WriteLine(color);
            }


            Console.WriteLine("HOW MANY of CPU");
            int Name = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[Name]; List<string> li = new List<string>();

            Console.WriteLine("Selected CPU's");
            for (int i = 1; i <= array.Length; i++)
            {
                //user list
                usercpu.Add(Console.ReadLine());

            }
            Console.WriteLine("Please enter  CPU in given list");
            foreach (string color in usercpu)
            {
                Console.WriteLine(color);
            }
            return usercpu;
        }

        private static bool FunctionforEnterNameofFile()
        {

            try
            {
Process[] processCollection = Process.GetProcesses();
                //  dataGridView1.DataSource = processCollection.ToList();
                var procs = Process.GetProcesses();

                Console.WriteLine("Enter file name:");
                string userName = Console.ReadLine();
                foreach (var proc in procs)
                {
                    if (userName == proc.ProcessName)
                    {
                        procc = proc.ProcessName;
                        found = true;
                        break;
                            

                    }

                }
               return found;
            }
            catch (Exception ex)
            {

                return false;
            } 
            } 
           
           
            
        

        public static char modifyBit(char[] n, int index)
        {
            return n[n.Length - index - 1] = '1';
        }

        static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
    }
}
//Console.WriteLine();




//  sum += sum + binary;

//    }


//Console.Write($"total number is=={sum}");








