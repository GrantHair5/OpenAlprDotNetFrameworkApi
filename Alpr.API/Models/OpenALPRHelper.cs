﻿using openalprnet;

namespace EnginDotNet.Models
{
    public class OpenAlprHelper
    {
        private static string OpenALPRConfigPath = "bin/openalpr.conf";
        private static string OpenALPRRuntimeDataPath = "bin/runtime_data";

        public static AlprResultsNet Recognize(string imageFilePath, string country = "eu")
        {
            try
            {
                // Initialize OpenALPR Library
                var alpr = new openalprnet.AlprNet(country, GetMapPath(OpenALPRConfigPath), GetMapPath(OpenALPRRuntimeDataPath));
                if (!alpr.IsLoaded())
                {
                    // OpenALPR failed to load!
                    return null;
                }

                //Recognize the image (if it exists)
                if (System.IO.File.Exists(imageFilePath))
                {
                    var results = alpr.Recognize(imageFilePath);
                    return results;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string GetMapPath(string path)
        {
            return System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + path;
        }
    }
}