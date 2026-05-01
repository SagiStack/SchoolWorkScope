using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace MasterPage1
{
    public class MySQLHelper
    {
        public MySQLHelper()
        {

        }
        public static SqlConnection ConnectToDb(string fileName)
        {
            string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד הנתונים בפרוייקט
            path = RemovePagesDirectory(path);// Remove the Pages Directory from the path (if exist).
            path += fileName;
            //path = "C:\\Users\\Drorseg\\source\\repos\\DrorApp1\\App_Data\\Users.mdf";
            string connString = @"Server = (localdb)\MSSQLLocalDB;AttachDbFilename=" +
                path +
                ";Integrated Security = True;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        /// <summary>
        /// To Execute update / insert / delete queries
        ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
        /// </summary>

        public static int DoQuery(string fileName, string sql)
        //הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
        //ומבצעת את הפקודה על המסד הפיזי
        // ומחזירה כמה רשומות הושפעו
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            int RowAffected = com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();
            return RowAffected;
        }
        /// <summary>
        /// To Execute update / insert / delete queries
        ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
        /// </summary>
        public static int RowsAffected(string fileName, string sql)
        //הפעולה מקבלת מסלול מסד נתונים ופקודת עדכון
        //ומבצעת את הפקודה על המסד הפיזי
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            int rowsA = com.ExecuteNonQuery();
            conn.Close();
            return rowsA;
        }
        /// <summary>
        /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
        /// </summary>
        public static bool IsExist(string fileName, string sql)
        //הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader data = com.ExecuteReader();
            bool found;
            found = (bool)data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
            conn.Close();
            return found;
        }
        public static DataTable ExecuteDataTable(string fileName, string sql)
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            return dt;
        }
        public static void ExecuteNonQuery(string fileName, string sql)
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static object GetScalar(string fileName, string sql)
        //פעולה המקבלת שם קובץ ומשפט בחירה ומחזירה ערך בודד מסוג אובייקט
        //עליו נבצע המרה לטיפוס המתאים
        {
            // התחברות למסד הנתונים
            SqlConnection conn = ConnectToDb(fileName);
            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(sql, conn);
            // ביצוע השאילתא
            conn.Open();
            object scalar = cmd.ExecuteScalar();
            conn.Close();

            return scalar;
        }

        public static string printDataTable(string fileName, string sql)//הפעולה מדפיסה טבלה כולל כותרת ומחזירה את המחרוזת שתציג אותה
        {
            DataTable dt = ExecuteDataTable(fileName, sql);
            string printStr = "";

            //printStr += "<table border='1' align = \"center \" style = \"padding:10px; margin:20px\"class=\"redclr\"\">";

            printStr = "<table border='1'>";

            //הדפסת הכותרת
            //printStr += "<tr>" +
            //    "<td> Id </td>" +
            //    "<td> First Name </td>" +
            //    "<td> Last Name </td>" +

            //    "<td> Password </td>" +// לשים בהערה אם רוצים להעלים את הסיסמה
            //    "<td> birthYear </td>" +
            //    "<td> gender </td>" +
            //    "<td> IsAdmin? </td>" +
            //    "</tr>";
            printStr +=
               "<thead>" +
               "<tr>" +
               "<td> -Id- </td>" +
               "<td> First Name </td>" +
               "<td> Last Name </td>" +

               "<td> Password </td>" +// לשים בהערה אם רוצים להעלים את הסיסמה
               "<td> birthYear </td>" +
               "<td> gender </td>" +
               "<td> IsAdmin? </td>" +
               "<tr>" +
               "</thead>";

            foreach (DataRow row in dt.Rows)
            {
                printStr += "<tr>";

                foreach (object myItemArray in row.ItemArray)
                {

                    printStr += "<td>" + myItemArray.ToString() + "</td>";
                }
                printStr += "</tr>";
            }
            printStr += "</table>"; //Closing the table form
            return printStr;
        }

        static string RemovePagesDirectory(string path)
        {
            // Ensure the path is properly formatted
            path = Path.GetFullPath(path);

            // Define the directory to be removed
            string directoryToRemove = "Pages";

            // Split the path into its parts
            string[] pathParts = path.Split(Path.DirectorySeparatorChar);

            // Create a list to hold the new path parts
            var newPathParts = new System.Collections.Generic.List<string>();

            // Loop through each part of the path
            foreach (string part in pathParts)
            {
                // Add part to the new path if it's not the directory to remove
                if (!string.Equals(part, directoryToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    newPathParts.Add(part);
                }
            }
            // Combine the new path parts back into a single path
            string newPath = string.Join(Path.DirectorySeparatorChar.ToString(), newPathParts);
            return newPath;
        }
    }
}