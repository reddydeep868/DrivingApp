using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace BusinessLayer
{
    public class LearnerBusinessLayer
    {
        public IEnumerable<Learner> Learners
        {
            get{


                string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        List<Learner> learners = new List<Learner>();
        using(MySqlConnection con = new MySqlConnection(connectionstring))
    {
        MySqlCommand cmd = new MySqlCommand("spgetalllearners",con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
        {
            Learner learner = new Learner();
            learner.Name = rdr["Name"].ToString();
            learner.Username = rdr["Username"].ToString();
            learner.Password = rdr["Password"].ToString();
            learner.gender = rdr["gender"].ToString();
            learner.dateofbirth = rdr["dateofbirth"].ToString();
            learners.Add(learner);
        }
        }

            return Learners;
            }
        }

        public void AddLearner(Learner learner)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spAddAllLearners", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter paramName = new MySqlParameter();
                paramName.ParameterName = "Name";
                paramName.Value = learner.Name;
                cmd.Parameters.Add(paramName);

                MySqlParameter paramUsername = new MySqlParameter();
                paramUsername.ParameterName = "Username";
                paramUsername.Value = learner.Username;
                cmd.Parameters.Add(paramUsername);

                MySqlParameter paramPassword = new MySqlParameter();
                paramPassword.ParameterName = "Password";
                paramPassword.Value = learner.Password;
                cmd.Parameters.Add(paramPassword);

                MySqlParameter paramGender = new MySqlParameter();
                paramGender.ParameterName = "gender";
                paramGender.Value = learner.gender;
                cmd.Parameters.Add(paramGender);

                

                MySqlParameter paramDateOfBirth = new MySqlParameter();
                paramDateOfBirth.ParameterName = "dateofbirth";
                paramDateOfBirth.Value = learner.dateofbirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
