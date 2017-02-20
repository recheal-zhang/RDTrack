////////////////////////////////////////////////////////////////////////////////
//
//    Read Tags
//
////////////////////////////////////////////////////////////////////////////////

using System;
using Impinj.OctaneSdk;
using System.IO;
using System.Collections.Concurrent;
using System.Text;

//添加EXCEL命名空间
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace OctaneSdkExamples
{
    class Program
    {
        // Create an instance of the ImpinjReader class.
        static ImpinjReader reader = new ImpinjReader();
        static int count1 = 0;
        static int count2 = 0;
        static int count3 = 0;
        static int count4 = 0;
        static int count5 = 0;
        static int count6 = 0;
        static int count7 = 0;
        static int count8 = 0;
        static int count9 = 0;
        static int count10 = 0;
        static int count11 = 0;
        static int count12 = 0;
        static int count13 = 0;
        static int count14 = 0;
        static int count15 = 0;
        static int count16 = 0;
        static int count17 = 0;
        static int count18 = 0;
        static int count19 = 0;
        static int count20 = 0;
        static int count21 = 0;
        static int count22 = 0;
        static int count23 = 0;
        static int count24 = 0;
        static int count25 = 0;
        static int count26 = 0;
        static int count27 = 0;
        static int count28 = 0;
        static int count29 = 0;
        static int count30 = 0;
        static int count31 = 0;
        static int count32 = 0;

        static object path1, path2, path3, path4; //文件路径变量
        static MSExcel.Application excelApp; //Excel应用程序变量
        static MSExcel.Workbook excelDoc; //Excel文档变量
 


        static void Main(string[] args)
        {          
            try
            {
                // Connect to the reader.
                // Change the ReaderHostname constant in SolutionConstants.cs 
                // to the IP address or hostname of your reader.
                reader.Connect(SolutionConstants.ReaderHostname);

                // Get the default settings
                // We'll use these as a starting point
                // and then modify the settings we're 
                // interested in.
                Settings settings = reader.QueryDefaultSettings();
                FeatureSet featureset = reader.QueryFeatureSet();

                // Tell the reader to include the antenna number
                // in all tag reports. Other fields can be added
                // to the reports in the same way by setting the 
                // appropriate Report.IncludeXXXXXXX property.
                settings.Report.IncludeAntennaPortNumber = true;

                //丁丁姐加入还有一个phaseRadian  是弧度值,不过无所谓了  可以互相转换
                settings.Report.IncludePhaseAngle = true;
                settings.Report.IncludeDopplerFrequency = true;
                settings.Report.IncludePeakRssi = true;
          
                // Set the reader mode, search mode and session
                settings.ReaderMode = ReaderMode.AutoSetDenseReader;
                //settings.ReaderMode = ReaderMode.DenseReaderM4;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;
                settings.TxFrequenciesInMhz.Clear();
                settings.TxFrequenciesInMhz.Add(920.875);

                Console.WriteLine("TxFrequency : {0}", "settings");
                               

                // Enable antenna #1. Disable all others.
                settings.Antennas.DisableAll();
                settings.Antennas.GetAntenna(1).IsEnabled = true;
                settings.Antennas.GetAntenna(2).IsEnabled = true;
                settings.Antennas.GetAntenna(3).IsEnabled = true;
                settings.Antennas.GetAntenna(4).IsEnabled = true;
                settings.Antennas.GetAntenna(5).IsEnabled = true;
                settings.Antennas.GetAntenna(6).IsEnabled = true;
                settings.Antennas.GetAntenna(7).IsEnabled = true;
                settings.Antennas.GetAntenna(8).IsEnabled = true;
                settings.Antennas.GetAntenna(9).IsEnabled = true;
                settings.Antennas.GetAntenna(10).IsEnabled = true;
                settings.Antennas.GetAntenna(11).IsEnabled = true;
                settings.Antennas.GetAntenna(12).IsEnabled = true;
                settings.Antennas.GetAntenna(13).IsEnabled = true;
                settings.Antennas.GetAntenna(14).IsEnabled = true;
                settings.Antennas.GetAntenna(15).IsEnabled = true;
                settings.Antennas.GetAntenna(16).IsEnabled = true;
                settings.Antennas.GetAntenna(17).IsEnabled = true;
                settings.Antennas.GetAntenna(18).IsEnabled = true;
                settings.Antennas.GetAntenna(19).IsEnabled = true;
                settings.Antennas.GetAntenna(20).IsEnabled = true;
                settings.Antennas.GetAntenna(21).IsEnabled = true;
                settings.Antennas.GetAntenna(22).IsEnabled = true;
                settings.Antennas.GetAntenna(23).IsEnabled = true;
                settings.Antennas.GetAntenna(24).IsEnabled = true;
                settings.Antennas.GetAntenna(25).IsEnabled = true;
                settings.Antennas.GetAntenna(26).IsEnabled = true;
                settings.Antennas.GetAntenna(27).IsEnabled = true;
                settings.Antennas.GetAntenna(28).IsEnabled = true;
                settings.Antennas.GetAntenna(29).IsEnabled = true;
                settings.Antennas.GetAntenna(30).IsEnabled = true;
                settings.Antennas.GetAntenna(31).IsEnabled = true;
                settings.Antennas.GetAntenna(32).IsEnabled = true;


                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(1).MaxTxPower = true;
                settings.Antennas.GetAntenna(1).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(2).MaxTxPower = true;
                settings.Antennas.GetAntenna(2).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(3).MaxTxPower = true;
                settings.Antennas.GetAntenna(3).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(4).MaxTxPower = true;
                settings.Antennas.GetAntenna(4).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(5).MaxTxPower = true;
                settings.Antennas.GetAntenna(5).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(6).MaxTxPower = true;
                settings.Antennas.GetAntenna(6).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(7).MaxTxPower = true;
                settings.Antennas.GetAntenna(7).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(8).MaxTxPower = true;
                settings.Antennas.GetAntenna(8).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(9).MaxTxPower = true;
                settings.Antennas.GetAntenna(9).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(10).MaxTxPower = true;
                settings.Antennas.GetAntenna(10).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(11).MaxTxPower = true;
                settings.Antennas.GetAntenna(11).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(12).MaxTxPower = true;
                settings.Antennas.GetAntenna(12).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(13).MaxTxPower = true;
                settings.Antennas.GetAntenna(13).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(14).MaxTxPower = true;
                settings.Antennas.GetAntenna(14).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(15).MaxTxPower = true;
                settings.Antennas.GetAntenna(15).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(16).MaxTxPower = true;
                settings.Antennas.GetAntenna(16).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(17).MaxTxPower = true;
                settings.Antennas.GetAntenna(17).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(18).MaxTxPower = true;
                settings.Antennas.GetAntenna(18).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(19).MaxTxPower = true;
                settings.Antennas.GetAntenna(19).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(20).MaxTxPower = true;
                settings.Antennas.GetAntenna(20).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(21).MaxTxPower = true;
                settings.Antennas.GetAntenna(21).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(22).MaxTxPower = true;
                settings.Antennas.GetAntenna(22).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(23).MaxTxPower = true;
                settings.Antennas.GetAntenna(23).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(24).MaxTxPower = true;
                settings.Antennas.GetAntenna(24).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(25).MaxTxPower = true;
                settings.Antennas.GetAntenna(25).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(26).MaxTxPower = true;
                settings.Antennas.GetAntenna(26).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(27).MaxTxPower = true;
                settings.Antennas.GetAntenna(27).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(28).MaxTxPower = true;
                settings.Antennas.GetAntenna(28).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(29).MaxTxPower = true;
                settings.Antennas.GetAntenna(29).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(30).MaxTxPower = true;
                settings.Antennas.GetAntenna(30).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(31).MaxTxPower = true;
                settings.Antennas.GetAntenna(31).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(32).MaxTxPower = true;
                settings.Antennas.GetAntenna(32).MaxRxSensitivity = true;

                // You can also set them to specific values like this...
                //settings.Antennas.GetAntenna(1).TxPowerInDbm = 20;
                //settings.Antennas.GetAntenna(1).RxSensitivityInDbm = -70;

                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.
                reader.TagsReported += OnTagsReported;

                // Start reading.
                reader.Start();

                // Wait for the user to press enter.
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();

                // Stop reading.
                reader.Stop();

                // Disconnect from the reader.
                reader.Disconnect();
            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                Console.WriteLine("Octane SDK exception: {0}", e.Message);
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }

        static void OnTagsReported(ImpinjReader sender, TagReport report)
        {
    //        path1 = @"E:\Antenna1.xlsx"; //路径
    //        path2 = @"E:\Antenna1.xlsx"; //路径
     //       path3 = @"E:\Antenna1.xlsx"; //路径
    //        path4 = @"E:\Antenna1.xlsx"; //路径
    //        excelApp = new MSExcel.Application(); //初始化
            //如果存在，则删除
        //    if (File.Exists((string)path1))
       //     {
       //         File.Delete((string)path1);
       //     }

            //由于使用的是COM库，因此有许多变量需要用Nothing代替
     //       Object nothing = Missing.Value;
     //       excelDoc = excelApp.Workbooks.Add(nothing);

            //使用第一个工作表作为插入数据的工作表
     //       MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];
     //       ws.Name = "Antenna1";



            // This event handler is called asynchronously 
            // when tag reports are available.
            // Loop through each tag in the report 
            // and print the data.
            foreach (Tag tag in report)
            {
                //将标签1的值存入Antenna1.txt中
                if (tag.AntennaPortNumber.ToString()=="1")
                {
                    


                    /*
                    *********************存数据部分********************

                    //为每个单元格赋值，写列标签
                    ws.Cells[1, 1] = "Phase";
                    ws.Cells[1, 2] = "RSSI";
                    ws.Cells[1, 3] = "DopplerFrequency";
                    ws.Cells[1, 4] = "Count";
                    ws.Cells[1, 5] = "EPC";

                    //写入数据条数
                    count1++;
                    ws.Cells[count1, 1] = tag.PhaseAngleInRadians.ToString();
                    ws.Cells[count1, 2] = tag.PeakRssiInDbm.ToString();
                    ws.Cells[count1, 3] = tag.RfDopplerFrequency.ToString();
                    ws.Cells[count1, 4] = count1.ToString();
                    ws.Cells[count1, 5] = tag.Epc.ToString();

                    //**********************存数据部分*******************
                     * */

            
                 
                    FileStream file = new FileStream("E:/Antenna1.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件           
                  // sw.WriteLine("-------------------Antenna : {0}-------------------",tag.AntennaPortNumber);
                  //  sw.WriteLine("EPC : {0} ",tag.Epc);             
                  //  sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                   
                  //  sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                  //  sw.WriteLine("DopplerFrequency : {0} ",tag.RfDopplerFrequency);
                  //  sw.WriteLine("Antenna1 : {0}", count1++);
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count1++, tag.Epc);                           
                    sw.Close();
                }
                //将标签2的值存入Antenna2.txt中
                else if (tag.AntennaPortNumber.ToString() == "2")
                {
                    FileStream file = new FileStream("E:/Antenna2.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                //    sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
               //     sw.WriteLine("EPC : {0} ", tag.Epc);
                //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                  //    sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                 //   sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
                 //   sw.WriteLine("Antenna2 : {0}", count2++);

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count2++, tag.Epc);                           
                    sw.Close();
                }
                //将标签3的值存入Antenna3.txt中
                else if (tag.AntennaPortNumber.ToString() == "3")
                {
                    FileStream file = new FileStream("E:/Antenna3.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                 //   sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
                //    sw.WriteLine("EPC : {0} ", tag.Epc);
                //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                //    sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                 //   sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
                 //   sw.WriteLine("Antenna3 : {0}", count3++);
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count3++, tag.Epc);                           
                    sw.Close();
                }
                //将标签4的值存入Antenna4.txt中
                else if (tag.AntennaPortNumber.ToString() == "4")
                {
                    FileStream file = new FileStream("E:/Antenna4.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
               //     sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
               //     sw.WriteLine("EPC : {0} ", tag.Epc);
                //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
               //     sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
               //     sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
               //     sw.WriteLine("Antenna4 : {0}", count4++);

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count4++, tag.Epc); 
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "5")
                {
                    FileStream file = new FileStream("E:/Antenna5.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    //     sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
                    //     sw.WriteLine("EPC : {0} ", tag.Epc);
                    //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                    //     sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                    //     sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
                    //     sw.WriteLine("Antenna4 : {0}", count4++);

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count5++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "6")
                {
                    FileStream file = new FileStream("E:/Antenna6.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    //     sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
                    //     sw.WriteLine("EPC : {0} ", tag.Epc);
                    //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                    //     sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                    //     sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
                    //     sw.WriteLine("Antenna4 : {0}", count4++);

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count6++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "7")
                {
                    FileStream file = new FileStream("E:/Antenna7.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    //     sw.WriteLine("-------------------Antenna : {0}-------------------", tag.AntennaPortNumber);
                    //     sw.WriteLine("EPC : {0} ", tag.Epc);
                    //    sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                    //     sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                    //     sw.WriteLine("DopplerFrequency : {0} ", tag.RfDopplerFrequency);
                    //     sw.WriteLine("Antenna4 : {0}", count4++);

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count7++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "8")
                {
                    FileStream file = new FileStream("E:/Antenna8.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count8++, tag.Epc);
                    sw.Close();
                }
                //将标签3的值存入Antenna3.txt中
                else if (tag.AntennaPortNumber.ToString() == "9")
                {
                    FileStream file = new FileStream("E:/Antenna9.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count9++, tag.Epc);
                    sw.Close();
                }
                //将标签4的值存入Antenna4.txt中
                else if (tag.AntennaPortNumber.ToString() == "10")
                {
                    FileStream file = new FileStream("E:/Antenna10.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count10++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "11")
                {
                    FileStream file = new FileStream("E:/Antenna11.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count11++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "12")
                {
                    FileStream file = new FileStream("E:/Antenna12.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count12++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "13")
                {
                    FileStream file = new FileStream("E:/Antenna13.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count13++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "14")
                {
                    FileStream file = new FileStream("E:/Antenna14.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count14++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "15")
                {
                    FileStream file = new FileStream("E:/Antenna15.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count15++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "16")
                {
                    FileStream file = new FileStream("E:/Antenna16.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count16++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "17")
                {
                    FileStream file = new FileStream("E:/Antenna17.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count17++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "18")
                {
                    FileStream file = new FileStream("E:/Antenna18.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count18++, tag.Epc);
                    sw.Close();
                }
                //将标签3的值存入Antenna3.txt中
                else if (tag.AntennaPortNumber.ToString() == "19")
                {
                    FileStream file = new FileStream("E:/Antenna19.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count19++, tag.Epc);
                    sw.Close();
                }
                //将标签4的值存入Antenna4.txt中
                else if (tag.AntennaPortNumber.ToString() == "20")
                {
                    FileStream file = new FileStream("E:/Antenna20.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count20++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "21")
                {
                    FileStream file = new FileStream("E:/Antenna21.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count21++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "22")
                {
                    FileStream file = new FileStream("E:/Antenna22.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count22++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "23")
                {
                    FileStream file = new FileStream("E:/Antenna23.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count23++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "24")
                {
                    FileStream file = new FileStream("E:/Antenna24.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count24++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "25")
                {
                    FileStream file = new FileStream("E:/Antenna25.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count25++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "26")
                {
                    FileStream file = new FileStream("E:/Antenna26.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count26++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "27")
                {
                    FileStream file = new FileStream("E:/Antenna27.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count27++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "28")
                {
                    FileStream file = new FileStream("E:/Antenna28.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count28++, tag.Epc);
                    sw.Close();
                }
                //将标签3的值存入Antenna3.txt中
                else if (tag.AntennaPortNumber.ToString() == "29")
                {
                    FileStream file = new FileStream("E:/Antenna29.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count29++, tag.Epc);
                    sw.Close();
                }
                //将标签4的值存入Antenna4.txt中
                else if (tag.AntennaPortNumber.ToString() == "30")
                {
                    FileStream file = new FileStream("E:/Antenna30.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count30++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "31")
                {
                    FileStream file = new FileStream("E:/Antenna31.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count31++, tag.Epc);
                    sw.Close();
                }
                else if (tag.AntennaPortNumber.ToString() == "32")
                {
                    FileStream file = new FileStream("E:/Antenna32.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count32++, tag.Epc);
                    sw.Close();
                }


                //WdSaveFormat为Excel文档的保存格式
       //         object format = MSExcel.XlFileFormat.xlWorkbookDefault;

                //将excelDoc文档对象的内容保存为XLSX文档
       //         excelDoc.SaveAs(path1, format, nothing, nothing, nothing, nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, nothing, nothing, nothing, nothing, nothing);

                //关闭excelDoc文档对象
       //         excelDoc.Close(nothing, nothing, nothing);

                //关闭excelApp组件对象
       //         excelApp.Quit();
       //         Console.WriteLine(path1 + "创建完毕！");


                Console.WriteLine("Antenna : {0},EPC : {1}",
                                           tag.AntennaPortNumber, tag.Epc);
                Console.WriteLine("Antenna : {0}, Phase : {1} ",
                                           tag.AntennaPortNumber, tag.PhaseAngleInRadians);             
                Console.WriteLine("Antenna : {0}, RSSI : {1} ",
                                           tag.AntennaPortNumber, tag.PeakRssiInDbm);
               /*         Console.WriteLine("Antenna : {0}, DopplerFrequency : {1} ",
                                           tag.AntennaPortNumber, tag.RfDopplerFrequency);
                              Console.WriteLine("Antenna : {0}, GpsCoodinates.Latitude : {1}, GpsCoodinates.Longitude : {2} , {3}",
                                                     tag.AntennaPortNumber, tag.GpsCoodinates.Latitude, tag.GpsCoodinates.Longitude, tag.GpsCoodinates.ToString());
               */
                

                Console.WriteLine("Antenna1 count : {0}", count1);
                Console.WriteLine("Antenna2 count : {0}", count2);
                Console.WriteLine("Antenna3 count : {0}", count3);
                Console.WriteLine("Antenna4 count : {0}", count4);
                Console.WriteLine("Antenna5 count : {0}", count5);
                Console.WriteLine("Antenna6 count : {0}", count6);
                Console.WriteLine("Antenna7 count : {0}", count7);
                Console.WriteLine("Antenna8 count : {0}", count8);
                Console.WriteLine("Antenna9 count : {0}", count9);
                Console.WriteLine("Antenna10 count : {0}", count10);
                Console.WriteLine("Antenna11 count : {0}", count11);
                Console.WriteLine("Antenna12 count : {0}", count12);
                Console.WriteLine("Antenna13 count : {0}", count13);
                Console.WriteLine("Antenna14 count : {0}", count14);
                Console.WriteLine("Antenna15 count : {0}", count15);
                Console.WriteLine("Antenna16 count : {0}", count16);
                Console.WriteLine("Antenna17 count : {0}", count17);
                Console.WriteLine("Antenna18 count : {0}", count18);
                Console.WriteLine("Antenna19 count : {0}", count19);
                Console.WriteLine("Antenna20 count : {0}", count20);
                Console.WriteLine("Antenna21 count : {0}", count21);
                Console.WriteLine("Antenna22 count : {0}", count22);
                Console.WriteLine("Antenna23 count : {0}", count23);
                Console.WriteLine("Antenna24 count : {0}", count24);
                Console.WriteLine("Antenna25 count : {0}", count25);
                Console.WriteLine("Antenna26 count : {0}", count26);
                Console.WriteLine("Antenna27 count : {0}", count27);
                Console.WriteLine("Antenna28 count : {0}", count28);
                Console.WriteLine("Antenna29 count : {0}", count29);
                Console.WriteLine("Antenna30 count : {0}", count30);
                Console.WriteLine("Antenna31 count : {0}", count31);
                Console.WriteLine("Antenna32 count : {0}", count32);
                }
        }
    }
}
