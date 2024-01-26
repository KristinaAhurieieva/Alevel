using System;
using HomeWorkLoggerJSON.Models;
using HomeWorkLoggerJSON.Services.Abstractions;
using HomeWorkLoggerJSON.Enums;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace HomeWorkLoggerJSON.Services
{
    public class FileService
    {
        private readonly string directoryPath;

        public FileService(string directoryPath)
        {
            this.directoryPath = directoryPath;

            string logsDirectory = Path.Combine(directoryPath, "Logs");
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }
        }

        public void WriteFile(Exception exception)
        {
            string fileName = $"{DateTime.Now:MM_dd_yyyy_hh_mm_ss_fff_tt}.txt";

            string logFilePath = Path.Combine(directoryPath, "Logs", fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath))
                {
                    string errorJson = JsonConvert.SerializeObject(exception, Formatting.Indented);
                    writer.WriteLine(errorJson);
                }

                Console.WriteLine($"Wrote to file: {logFilePath}");

                using (StreamWriter consoleWriter = new StreamWriter(logFilePath, true))
                {
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        Console.SetOut(stringWriter);
                        Console.WriteLine("");
                        consoleWriter.WriteLine(stringWriter.ToString());
                    }
                }

                DeleteFolder();
            }
            catch (Exception ex)
            {
                Console.WriteLine("File write error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine(" Finally block.");
            }
        }

        private void DeleteFolder()
        {
            string logsDirectory = Path.Combine(directoryPath, "Logs");
            string[] files = Directory.GetFiles(logsDirectory);

            if (files.Length > 3)
            {
                Array.Sort(files);
                File.Delete(files[0]);
            }
        }
    }
}