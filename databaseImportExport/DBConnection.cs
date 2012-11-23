using System;
using System.Collections;

namespace databaseImportExport
{
	//Represents a database connection, with its Oracle connection string
	//Contains a list of which tables / entailing columns are required to export
	public class DBConnection
	{
		private String dbName;
		private String dbConn;
		private ArrayList dbTables;

		public DBConnection(String dbName, String dbConn)
		{
			this.dbName = dbName;
			this.dbConn = dbConn;
		}

		public DBConnection(String dbName, String dbConn, ArrayList dbTables)
		{
			this.dbName = dbName;
			this.dbConn = dbConn;
			this.dbTables = dbTables;
		}

		public void setTables(ArrayList dbTables)
		{
			this.dbTables = dbTables;
		}

		public String getName()
		{
			return this.dbName;
		}

		public String getConnectionString ()
		{
			return this.dbConn;
		}

		public ArrayList getTables ()
		{
			return this.dbTables;
		}


	}
}

