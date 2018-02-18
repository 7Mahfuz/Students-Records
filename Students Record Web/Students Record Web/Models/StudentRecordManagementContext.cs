using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Students_Record_Web.Models
{
    public class StudentRecordManagementContext :DbContext
    {
          public DbSet<Student> Students { get; set; }
    }
}