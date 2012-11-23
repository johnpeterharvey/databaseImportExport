using System;
using System.Collections;

namespace databaseImportExport
{
	//Represents a database table and specifies which columns you want to export
	public class DBTable
	{
		private String tableName;
		private ArrayList tableColumns;

		public DBTable(String tableName, ArrayList tableColumns)
		{
			this.tableName = tableName;
			this.tableColumns = tableColumns;
		}

		public String getTableName ()
		{
			return this.tableName;
		}

		public ArrayList getTableColumns()
		{
			return this.tableColumns;
		}
	}
}

