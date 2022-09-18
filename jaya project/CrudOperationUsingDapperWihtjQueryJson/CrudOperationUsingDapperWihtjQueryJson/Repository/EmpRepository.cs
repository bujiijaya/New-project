using CrudOperationUsingDapperWihtjQueryJson.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace CrudOperationUsingDapperWihtjQueryJson.Repository
{
    public class EmpRepository
    {
         SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }
        //To Add Employee details
        public void AddEmployee(EmpModel objEmp)
        {
          
            try
            {
      
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Name", objEmp.Name);
                ObjParm.Add("@City", objEmp.City);
                ObjParm.Add("@Address", objEmp.Address);
                connection();
                con.Open();
                con.Execute("AddNewEmpDetails", ObjParm, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To view employee details 
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(
                                  con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To Update Employee details
        public void UpdateEmployee(EmpModel objUpdate)
        {
            try
            {
              

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("@EmpId", objUpdate.Id);
                objParam.Add("@Name", objUpdate.Name);
                objParam.Add("@City", objUpdate.City);
                objParam.Add("@Address", objUpdate.Address);
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objParam, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To delete Employee details
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", Id);
                connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need 
                throw ex;
            }
        }
    }
}