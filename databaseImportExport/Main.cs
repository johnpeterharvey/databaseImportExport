using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Oracle.DataAccess.Client;

namespace databaseImportExport
{
	class MainClass
	{
		private static OracleConnection dbConn;

		public static void Main (string[] args)
		{
			Dictionary<String, String> availableDBs = getDBList();



			Console.WriteLine("Please specify database to connect to:");
			Console.WriteLine("\t");
			Console.ReadLine();
		}

		public static void getDBConnection ()
		{

		}

		public static Dictionary<String, String> getDBList ()
		{
			XDocument doc = XDocument.Load ("DatabaseConfig.xml");

			var data = from item in doc.Descendants ("database")
						select new {
							name = item.Element ("name").Value,
							connString = item.Element ("connectionString").Value
			};

			Dictionary<String, String> results = new Dictionary<String, String> ();
			foreach (var val in data)
			{

			}

			return results;
		}
	}
}
