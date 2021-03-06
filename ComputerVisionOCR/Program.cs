﻿using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ComputerVisionOCR
{

    // 文档地址：https://docs.microsoft.com/zh-cn/azure/cognitive-services/computer-vision/


    /// <summary>
    /// OCR图片文字识别
    /// </summary>

    static class Program
    {


        // Replace <Subscription Key> with your valid subscription key.
        const string apiKey = "";
        // api 地址
        const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/ocr";

        static void Main()
        {

            string imageFilePath = @"imgs/1.jpg";
            string imgUrl = "https://leizhangstorage.blob.core.chinacloudapi.cn/azureblog/ocr.jpg";


            HttpClient client = new HttpClient();
            var result = string.Empty;


            Console.WriteLine("从文件识别:");

            result = AzureOcrHelper.OcrFromFile(client, uriBase, apiKey, imageFilePath, "zh-Hans").Result;
            Console.WriteLine("\r\n响应:\n\n{0}\n", JToken.Parse(result).ToString());
            result = AzureOcrHelper.SimpleFormattedText(result);
            Console.WriteLine("\r\n格式化输出结果:\n\n{0}\n", result);

            Console.WriteLine("\r\n===================================\r\n");


            //Console.WriteLine("从url识别:");

            //result = AzureOcrHelper.OcrFromUrl(client, uriBase, apiKey, imgUrl).Result;
            //Console.WriteLine("\r\n响应:\n\n{0}\n", JToken.Parse(result).ToString());



            //result = AzureOcrHelper.SimpleFormattedText(result);
            //Console.WriteLine("\r\n格式化输出结果:\n\n{0}\n", result);



            Console.WriteLine("\n按任意键退出...");
            Console.ReadLine();
        }
    }
}
