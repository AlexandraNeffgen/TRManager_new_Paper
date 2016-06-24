using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRManager_new_Client.Model;

namespace TRManager_new_Client
{
    class configuration_store
    {
        public static Teacher logged_user;

        public static string backend_address="";
        public static string backend_port="";
        public static string backend_entry_endpoint="";

        public static string school_begin_time="";
        public static int lesson_length=0;
        public static List<school_break> breaks = new List<school_break>();

        public static String dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public static String dateTimeFormatShort = @"hh\:mm\:ss";

        public static int returnee_age_threshold = 7;

        public static bool read_config(String path)
        {
            StreamReader config_file = new StreamReader(path);
            List<String> lines = Utility.readDataFromFile(config_file);

            foreach(String line in lines)
            {
                String[] x = line.Split('=');
                switch (x[0])
                {
                    case "backend_address": backend_address = x[1];
                        break;
                    case "backend_port": backend_port = x[1];
                        break;
                    case "backend_entry_endpoint": backend_entry_endpoint = x[1];
                        break;
                    case "break": callAddBreak(x[1]);
                        break;
                    case "school_begin_time": school_begin_time = x[1];
                        break;
                    case "lesson_length": int.TryParse(x[1], out lesson_length);
                        break;
                    default:
                        break;
                }

            }

            return false;
        }
        public static void callAddBreak(String conf)
        {

        }
        public static void addBreak(int before, int after, int length)
        {
            breaks.Add(new school_break(before, after, length));
        }

        public static void config_writeback()
        {
            int conf_line_cnt = breaks.Count;
            String[] conf_lines = new String[5 + conf_line_cnt];

            conf_lines[0] = "backend_address=" + backend_address;
            conf_lines[1] = "backend_port=" + backend_port;
            conf_lines[2] = "backend_entry_endpoint=" + backend_entry_endpoint;
            conf_lines[3] = "school_begin_time=" + school_begin_time;
            conf_lines[4] = "lesson_length=" + lesson_length.ToString();
            int cur = 5;
            foreach (school_break s in breaks)
            {
                conf_lines[cur] = s.ToString();
                cur++;
            }
            if(File.Exists("trmanager.conf"))File.Delete("trmanager.conf");
            File.WriteAllLines("trmanager.conf", conf_lines);
        }
        public static void reload_config()
        {
            RepositoryUtility.incidentRepository = new TRManager_http_client<Incident>("http", configuration_store.backend_entry_endpoint, configuration_store.backend_address + ":" + configuration_store.backend_port, "incident", "addbulk");
            RepositoryUtility.formRepository = new TRManager_http_client<Model.Form>("http", configuration_store.backend_entry_endpoint, configuration_store.backend_address + ":" + configuration_store.backend_port, "form", "addbulk");
            RepositoryUtility.studentRepository = new TRManager_http_client<Student>("http", configuration_store.backend_entry_endpoint, configuration_store.backend_address + ":" + configuration_store.backend_port, "student", "addbulk");
            RepositoryUtility.teacherRepository = new TRManager_http_client<Teacher>("http", configuration_store.backend_entry_endpoint, configuration_store.backend_address + ":" + configuration_store.backend_port, "teacher", "addbulk");
            RepositoryUtility.commentRepository = new TRManager_http_client<Comment>("http", configuration_store.backend_entry_endpoint, configuration_store.backend_address + ":" + configuration_store.backend_port, "comment", "addbulk");
        }
    }
}
