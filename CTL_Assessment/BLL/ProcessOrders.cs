using CsvHelper;
using CTL_Assessment.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CTL_Assessment.BLL
{
    public static class ProcessOrders
    {
        public static async Task<List<Order>> ReadOrders(IFormFile file)
        {
            Startup.Progress = 0;
            long totalBytes = file.Length;            

            string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            filename =EnsureCorrectFilename(filename);

            byte[] buffer = new byte[16 * 1024];
            var filePath = Path.GetTempFileName();
            using (FileStream output = System.IO.File.Create(filePath))
            {
                using (Stream input = file.OpenReadStream())
                {
                    long totalReadBytes = 0;
                    int readBytes;

                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalReadBytes += readBytes;
                        Startup.Progress = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
                        await Task.Delay(10); // It is only to make the process slower
                    }
                }
            }
            using (FileStream fileStream = System.IO.File.OpenRead(filePath))
            {
                return getList(fileStream);
            }
        }
        private static string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1); return filename;
        }

        private static List<Order> getList(FileStream fileStream)
        {
            using (var reader = new StreamReader(fileStream))
            {

                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.ShouldSkipRecord = (records) => records.All(field => string.IsNullOrEmpty(field));
                    try { 
                    List<Order> orders = csv.GetRecords<Order>().ToList();
                        return orders;
                    } catch (Exception e)
                    {
                        Debug.Print(e.ToString());
                        return null;
                    }
                                      
                }
            }
        }
    }
}
