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

		public static void Main (string[] args)
		{
			OracleConnection dbConn = askUserForDatabase();


		}

		public static OracleConnection askUserForDatabase ()
		{
			Dictionary<String, String> availableDBs = getDBList();

			Console.WriteLine ("Please specify database to connect to:");

			String[] dbNames = (String[]) availableDBs.Keys.ToArray();
			int count = 0;
			foreach (String name in dbNames)
			{
				Console.WriteLine("\t" + count.ToString() + " - " + name);
				count++;
			}
			Console.WriteLine();
			String enteredVal = Console.ReadLine();

			int enteredValInt = int.Parse(enteredVal);
			if (enteredValInt < 0 || enteredValInt > dbNames.Length - 1)
				return null;
			String connString = null;
			availableDBs.TryGetValue(dbNames[enteredValInt], out connString);

			return getDBConnection(connString);
		}

		public static OracleConnection getDBConnection (String connectionString)
		{
			OracleConnection dbConn = new OracleConnection(connectionString);
			dbConn.Open();
			return dbConn;
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
			//TODO lambda?
			foreach (var val in data)
			{
				results.Add (val.name, val.connString);
			}
			return results;
		}
	}
}
