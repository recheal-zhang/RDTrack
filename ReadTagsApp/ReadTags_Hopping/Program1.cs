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
                //settings.ReaderMode = ReaderMode.AutoSetDenseReader;
                settings.ReaderMode = ReaderMode.DenseReaderM8;
                //settings.ReaderMode = ReaderMode.MaxThroughput;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;

                //settings.TxFrequenciesInMhz.Add(921.875);
                settings.TxFrequenciesInMhz.Add(920.625);
                //settings.TxFrequenciesInMhz.Add(922.875);
                //settings.TxFrequenciesInMhz.Add(923.375);
                //settings.TxFrequenciesInMhz.Add(923.875);
                //settings.TxFrequenciesInMhz.Add(924.375);

                // Enable antenna #1. Disable all others.
                settings.Antennas.DisableAll();
                settings.Antennas.GetAntenna(1).IsEnabled = true;
                settings.Antennas.GetAntenna(2).IsEnabled = true;
                settings.Antennas.GetAntenna(3).IsEnabled = true;
                settings.Antennas.GetAntenna(4).IsEnabled = true;

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
                //获取时间
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                int year = currentTime.Year;
                int month = currentTime.Month;
                int data = currentTime.Day;
                int hour = currentTime.Hour;
                int minute = currentTime.Minute;
                int second = currentTime.Second;
                int millisecond = currentTime.Millisecond;
                int black = 0;

                String currentTimeStr;

                if (hour < 10) //将0自动不全 小时是两位数字
                {
                    currentTimeStr = black.ToString();
                    currentTimeStr += hour.ToString();
                }
                else
                {
                    currentTimeStr = hour.ToString();
                }
                if (minute < 10) //将0自动不全 分钟是两位数字
                {
                    currentTimeStr += black.ToString();
                }
                currentTimeStr += minute.ToString();
                if (second < 10) //将0自动不全 秒是两位数字
                {
                    currentTimeStr += black.ToString();
                }
                currentTimeStr += second.ToString();

                if (millisecond < 10) //将0自动不全 毫秒是三位数字
                {
                    currentTimeStr += black.ToString();
                    currentTimeStr += black.ToString();
                }
                else if (millisecond >= 10 && millisecond < 100)
                {
                    currentTimeStr += black.ToString();
                }
                currentTimeStr += millisecond.ToString();


                //将标签1的值存入Antenna1.txt中
                if (tag.AntennaPortNumber.ToString() == "1")
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
                    //加入时间


                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count1++, tag.Epc, currentTimeStr);
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

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count2++, tag.Epc, currentTimeStr);
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
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count3++, tag.Epc, currentTimeStr);
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

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count4++, tag.Epc, currentTimeStr);
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
                /*        Console.WriteLine("Antenna : {0}, DopplerFrequency : {1} ",
                                            tag.AntennaPortNumber, tag.RfDopplerFrequency);
                               Console.WriteLine("Antenna : {0}, GpsCoodinates.Latitude : {1}, GpsCoodinates.Longitude : {2} , {3}",
                                                      tag.AntennaPortNumber, tag.GpsCoodinates.Latitude, tag.GpsCoodinates.Longitude, tag.GpsCoodinates.ToString());
                */

                Console.WriteLine("Antenna1 count : {0}", count1);
                Console.WriteLine("Antenna2 count : {0}", count2);
                Console.WriteLine("Antenna3 count : {0}", count3);
                Console.WriteLine("Antenna4 count : {0}", count4);
            }
        }
    }
}
