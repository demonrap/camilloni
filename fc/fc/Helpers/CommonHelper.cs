using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using fc.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;

namespace fc.Helpers
{
    public static class CommonHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static string getImgArt(ma_articoli x, string url)
        {
            var model = x.ma_articoli_img.FirstOrDefault().id_img_articolo;
            return model != null ? url + "/" + model : url + "/" + "no_img.jpg";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static string getImg(mc_cat_merc x, string url)
        {
            var model = x.ma_articoli.FirstOrDefault().ma_articoli_img.FirstOrDefault().id_img_articolo;
            return model != null ? url + "/" + model : url + "/" + "no_img.jpg";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="livello"></param>
        /// <returns></returns>
        internal static short setInt(short? livello = 0)
        {
            return Convert.ToInt16(livello);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="likeString"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        internal static IQueryable<T> LikeResult<T>(IQueryable<T> query, string likeString, string target)
        {
            MethodInfo method = typeof(SqlFunctions).GetMethod("PatIndex");
            var arg = Expression.Constant(likeString);
            var item = Expression.Parameter(typeof(T), "item");
            var prop = Expression.Property(item, target);

            MethodCallExpression resultExp = Expression.Call(method, arg, prop);
            var value = Expression.Constant(0, typeof(int?));
            var greaterThan = Expression.GreaterThan(resultExp, value);
            var lambda = Expression.Lambda<Func<T, bool>>(greaterThan, item);

            return query.Where(lambda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valore"></param>
        /// <returns></returns>
        internal static decimal setDecimal(decimal? valore = 0)
        {
            return Convert.ToDecimal(valore);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name_it"></param>
        /// <param name="name_en"></param>
        /// <param name="currentCulture"></param>
        /// <returns></returns>
        internal static string getConf(string name_it, string name_en, string currentCulture)
        {
            string sql = currentCulture == "en" ?  "select " + name_en + " from dbo.sy_config where id_config='001';" : "select " + name_it + " from dbo.sy_config where id_config='001';";
            string value = string.Empty;

            using (var con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, con);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        value = reader[0].ToString();
                    }
                }

                con.Close();
            }
            return value;
        }
    }
}