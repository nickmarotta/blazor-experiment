using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace blazor_experiment.Data
{
    public class StudentDataAccessLayer
    {
        private MongoDbClient db;

        public StudentDataAccessLayer(MongoDbClient _db)
        {
            db = _db;
        }

        //To Get all Students details       
        public List<Student> GetAllStudents()
        {
            try
            {
                return db.StudentRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Student> SearchStudents(string searchCriteria)
        {
            if (searchCriteria == "")
            {
                return null;
            }

            try
            {
                //THIS FUNCTION REQUIRES A TEXT INDEX! 
                //This can be created using the following command 
                // db.Students.createIndex( { FirstName: "text", LastName:"text", House:"text" } )

                return db.StudentRecord.Find(Builders<Student>.Filter.Text(searchCriteria)).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Student record       
        public void AddStudent(Student Student)
        {
            try
            {
                db.StudentRecord.InsertOne(Student);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular Student      
        public Student GetStudentData(string id)
        {
            try
            {
                FilterDefinition<Student> filterStudentData = Builders<Student>.Filter.Eq("Id", id);

                return db.StudentRecord.Find(filterStudentData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Student      
        public void UpdateStudent(Student Student)
        {
            try
            {
                db.StudentRecord.ReplaceOne(filter: g => g.Id == Student.Id, replacement: Student);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Student      
        public void DeleteStudent(string id)
        {
            try
            {
                FilterDefinition<Student> StudentData = Builders<Student>.Filter.Eq("Id", id);
                db.StudentRecord.DeleteOne(StudentData);
            }
            catch
            {
                throw;
            }
        }
    }
}
