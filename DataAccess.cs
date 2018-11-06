using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// This is the assumed class that would handle data interaction for this legacy WebForms application. 
    /// </summary>
    public class DataAccess
        
    {
        /// <summary>
        /// Flag to know if there is a concurrency issue  
        /// </summary>
        public bool HasConcurrencyIssue { get; set; }
        public string ConnectionString { get; set; }

        /// <summary>
        /// Contructor Method
        /// </summary>
        /// <param name="connectionString"></param>
        public DataAccess(string connectionString) {

            //Set defaul behavior to false, so that existing methods calls that don't check concurrancy don't fail. 
            HasConcurrencyIssue = false;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Function to save database using a Dataset. Assuming that the infastructure to use table adapters has been implemented
        /// </summary>
        /// <param name="dsToSave">Dataset passed in to Save.</param>
        /// <param name="checkConcurrency">If true, will check ds for concurrency</param>
        /// <returns></returns>
        public bool SaveData(DataSet dsToSave, bool checkConcurrency = false)
        {


            bool saveSuccessfull = false;

            try
            {

                if (checkConcurrency)
                {
                    Int64 id = Convert.ToInt64(dsToSave.Tables[0].Columns["ID"].ToString());
                    string tableName = dsToSave.Tables[0].TableName;
                    DateTime LastModifiedDate = Convert.ToDateTime(dsToSave.Tables[0].Columns["LastModifiedDate"].ToString());
                    if (HasRecordChanged(id, tableName, LastModifiedDate))
                    {

                        this.HasConcurrencyIssue = true;
                    }

                }
                if (!HasConcurrencyIssue)
                {
                    SaveDataSet(dsToSave);
                    saveSuccessfull = true;
                }


                
            }
            catch (Exception ex)
            {
                saveSuccessfull = false;
                throw ex;
            }

            return saveSuccessfull;



        }

        /// <summary>
        /// Method will use Table adapters to save the DataSet
        /// </summary>
        /// <param name="dsToSave"></param>
        private void SaveDataSet(DataSet dsToSave)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the record and returns a boolean to set <see cref="HasConcurrencyIssue"/> 
        /// </summary>
        /// <param name="id">Primary Key of record</param>
        /// <param name="tableName">Name of the Database Table</param>
        /// <param name="lastModifiedDate">DateTime value pulled from the Database originally</param>
        /// <returns></returns>
        private bool HasRecordChanged(long id, string tableName, DateTime lastModifiedDate)
        {
            throw new NotImplementedException();
        }

    
    }
}