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

namespace OctaneSdkExamples
{
    class Program
    {
        // Create an instance of the ImpinjReader class.
        static ImpinjReader reader = new ImpinjReader();
        static int count1 = 1;
        static int count2 = 1;
        static int count3 = 1;
        static int count4 = 1;
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
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;

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
     
            // This event handler is called asynchronously 
            // when tag reports are available.
            // Loop through each tag in the report 
            // and print the data.
            foreach (Tag tag in report)
            {
                //将标签1的值存入Antenna1.txt中
                if (tag.AntennaPortNumber.ToString()=="1")
                {
                    FileStream file = new FileStream("E:/Antenna1.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(file);//写入的文件           
                  // sw.WriteLine("-------------------Antenna : {0}-------------------",tag.AntennaPortNumber);
                  //  sw.WriteLine("EPC : {0} ",tag.Epc);             
                  //  sw.WriteLine("Phase : {0} ", tag.PhaseAngleInRadians);
                   // sw.WriteLine("RSSI : {0} ", tag.PeakRssiInDbm);
                  //  sw.WriteLine("DopplerFrequency : {0} ",tag.RfDopplerFrequency);
                  //  sw.WriteLine("Antenna1 : {0}", count1++);
                    sw.WriteLine("{0}，{1}，{2}，{3}，{4}", tag.PhaseAngleInRadians,tag.PeakRssiInDbm,tag.RfDopplerFrequency,count1++,tag.Epc);                           
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

                    sw.WriteLine("{0}，{1}，{2}，{3}，{4}", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count2++,tag.Epc);                           
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
                    sw.WriteLine("{0}，{1}，{2}，{3}，{4}", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count3++,tag.Epc);                           
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

                    sw.WriteLine("{0}，{1}，{2}，{3}，{4}", tag.PhaseAngleInRadians, tag.PeakRssiInDbm, tag.RfDopplerFrequency, count4++,tag.Epc); 
                    sw.Close();
                }

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

                Console.WriteLine("Antenna1 count : {0}", count1 - 1);
                Console.WriteLine("Antenna2 count : {0}", count2 - 1);
                Console.WriteLine("Antenna3 count : {0}", count3 - 1);
                Console.WriteLine("Antenna4 count : {0}", count4 - 1);
            }
        }
    }
}
