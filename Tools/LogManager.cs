

namespace Tools;

public static class LogManager
{
    private static readonly string log = "Log";

    // ניתוב תקיית לוג
    private static string GetDirectory()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, log);
    }

    //ניתוב תיקיית הקובץ

    private static string GetFolder()
    {
        string yearMonth = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
        string path = Path.Combine(GetDirectory(), yearMonth);
        if (Directory.Exists(path))
            return path;
        Directory.CreateDirectory(path);
        return path;

    }

    //ניתוב לקובץ עצמו
    private static string GetFile()
    {
        string path = Path.Combine(GetFolder(), DateTime.Now.Day.ToString());
        if (File.Exists(path))
            return path;
        File.Create(path);
        return path;
    }

    public static void WriteToLog(String project, String func, String msg)
    {
        using (StreamWriter writer = new StreamWriter(GetFile(), true))
        {
            writer.WriteLine($"{DateTime.Now}\t{project}.{func}:\t{msg}");
        }
    }

<<<<<<< HEAD
    public static void ClearLog()
=======
    private static void ClearLog()
>>>>>>> 132c9cfc781ae973869a48004eb5c388bc192fa9
    {
        string[] arr = Directory.GetDirectories(GetDirectory());
        foreach (string dir in arr)
        {
            string[] thisDir = (dir.Split('-'));
<<<<<<< HEAD
            if ((int.Parse(thisDir[0]) + 1 == DateTime.Now.Year && DateTime.Now.Month > 2))
            {
                if (DateTime.Now.Month == 1 && int.Parse(thisDir[1]) < 11)
                    Directory.Delete(dir, true);
                if (DateTime.Now.Month == 2 && int.Parse(thisDir[1]) < 12)
                    Directory.Delete(dir, true);
            }

            if ((int.Parse(thisDir[0]) < DateTime.Now.Year) ||
              (int.Parse(thisDir[1]) + 2 < DateTime.Now.Month)
              )
                Directory.Delete(dir, true);
        }
    }


=======
            if ((int.Parse(thisDir[0]) + 1 == DateTime.Now.Year && DateTime.Now.Month > 2) ||
                (int.Parse(thisDir[0]) < DateTime.Now.Year)||
                (int.Parse(thisDir[1])+2<DateTime.Now.Month)
                )
             Directory.Delete(dir, true);       
        }
    }

>>>>>>> 132c9cfc781ae973869a48004eb5c388bc192fa9
}
